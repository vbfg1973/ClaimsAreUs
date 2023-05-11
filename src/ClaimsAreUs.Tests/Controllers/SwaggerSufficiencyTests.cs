using ClaimsAreUs.Tests.Controllers.Data;
using FluentAssertions;

namespace ClaimsAreUs.Tests.Controllers
{
    public class SwaggerSufficiencyTests
    {
        /// <summary>
        ///     Tests controller methods decorated with HTTP Verb attributes for XML Documentation Comments
        ///     typeName and methodName are both unused in the test, but by being present and supplied by the ClassData
        ///     object they provide context to the test output
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="methodName"></param>
        /// <param name="xmlDocumentation"></param>
        [Theory]
        [ClassData(typeof(AllControllersVerbMethodsAndDocumentationCommentsClassData))]
        public void Given_Public_Controller_Http_Method_Has_Xml_Documentation_Comment(string typeName,
            string methodName,
            string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }
    }
}