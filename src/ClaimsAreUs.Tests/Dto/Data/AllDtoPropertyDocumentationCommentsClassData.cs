using System.Collections;
using System.Reflection;
using ClaimsAreUs.Domain.Support;
using Swashbuckle.AspNetCore.SwaggerGen;
using Towel;

namespace ClaimsAreUs.Tests.Dto.Data
{
    /// <summary>
    ///     Uses reflection to return any DTO types
    /// </summary>
    public class AllDtoPropertyDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllDtoPropertyDocumentationCommentsClassData()
        {
            // Get the assembly of the following controller
            _assembly = DomainAssemblyReference.Assembly;
            _assembly.LoadXmlDocumentation();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            // Grab types from assembly 
            var types = _assembly
                .GetExportedTypes();

            // Limit to those ending with Dto
            foreach (var type in types.Where(x => x.Name.EndsWith("Dto", StringComparison.InvariantCultureIgnoreCase)))
            {
                var properties = type.GetProperties()
                    .Where(propertyInfo => propertyInfo.IsPubliclyReadable());

                // Typename, property and any documentation comment Towel finds 
                foreach (var propertyInfo in properties)
                    yield return new object[]
                    {
                        type.Name,
                        propertyInfo.Name,
                        propertyInfo.GetDocumentation()?.Trim()!
                    };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}