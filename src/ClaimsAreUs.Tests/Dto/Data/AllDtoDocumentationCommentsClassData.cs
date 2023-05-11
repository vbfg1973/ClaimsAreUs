using System.Collections;
using System.Reflection;
using ClaimsAreUs.Domain.Support;
using Towel;

namespace ClaimsAreUs.Tests.Dto.Data
{
    public class AllDtoDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllDtoDocumentationCommentsClassData()
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

            // Limit to those ending with Dtp
            foreach (var type in types.Where(x => x.Name.EndsWith("Dto", StringComparison.InvariantCultureIgnoreCase)))
                yield return new object[]
                {
                    type.Name,
                    type.GetDocumentation()?.Trim()!
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}