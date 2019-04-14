using System;
using CleanText;
using Xunit;
using System.Linq;

namespace Tests
{
    public class RemoveRepeatedValuesServiceTests
    {
        private const string Stage = "stage";
        private const string Development = "development";
        private const string Production = "production";

        [Theory(DisplayName = "Repeated Values")]
        [InlineData("stage;development;production")]
        [InlineData("stage;stage;development;development;production;production")]
        [InlineData("stage;stage;stage;development;development;development;production;production;production")]
        public void RemoveRepeatedValuesService_FromString_GetStringWithoutRepeatedValues(string envNames)
        {
            var envNamesWithoutRepeatedValues = RemoveRepeatedValuesService.FromString(envNames, ';');
            var words = envNamesWithoutRepeatedValues.Split(';');
            Assert.Equal(1, words.Count(x => x == Stage));
            Assert.Equal(1, words.Count(x => x == Development));
            Assert.Equal(1, words.Count(x => x == Production));
        }

        [Fact]
        public void RemoveRepeatedValuesService_FromString_GetNullString()
        {
            var envNamesWithoutRepeatedValues = RemoveRepeatedValuesService.FromString(null, ';');
            Assert.Null(envNamesWithoutRepeatedValues);
        }

        [Fact]
        public void RemoveRepeatedValuesService_FromString_GetEmptyString()
        {
            var envNamesWithoutRepeatedValues = RemoveRepeatedValuesService.FromString(string.Empty, ';');
            Assert.True(string.Empty == envNamesWithoutRepeatedValues);
        }
    }
}
