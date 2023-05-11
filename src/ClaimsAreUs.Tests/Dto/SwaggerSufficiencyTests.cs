using ClaimsAreUs.Tests.Dto.Data;
using FluentAssertions;

namespace ClaimsAreUs.Tests.Dto
{
    public class SwaggerSufficiencyTests
    {
        /// <summary>
        ///     Tests the properties of DTOs for XML Documentation Comments
        ///     typeName and propertyName are both unused in the test, but by being present and supplied by the ClassData
        ///     object they provide context to the test output
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="propertyName"></param>
        /// <param name="xmlDocumentation"></param>
        [Theory]
        [ClassData(typeof(AllDtoPropertyDocumentationCommentsClassData))]
        public void Given_Dto_Poco_Public_Property_Has_Xml_Documentation_Comment(string typeName, string propertyName,
            string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }

        /// <summary>
        ///     Tests the DTO objects themselves for XML Documentation comments
        ///     typeName is unused in the test, but by being present and supplied by the ClassData
        ///     object it provides context to the test output
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="xmlDocumentation"></param>
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