using ClaimsAreUs.Tests.Dto.Data;
using FluentAssertions;

namespace ClaimsAreUs.Tests.Dto
{
    public class SwaggerSufficiencyTests
    {
        [Theory]
        [ClassData(typeof(AllDtoPocoAndPropertiesAndDocumentationCommentsClassData))]
        public void Given_Dto_Poco_Public_Property_Has_Xml_Documentation_Comment(string typeName, string propertyName,
            string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(AllDtoDocumentationCommentsClassData))]
        public void Given_Dto_Poco_Has_Xml_Documentation_Comment(string typeName, string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }
    }
}