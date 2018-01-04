using System;
using Xunit;

namespace Mapper.Tests
{
    public class MapTest
    {
        [Fact]
        public void WhenWrongTypeThenShouldThrowException()
        {
            var mapper = new IrrelevantMapper();
            Assert.Throws<InvalidCastException>(() => mapper.Map(new object(), new TestClass()));
            Assert.Throws<InvalidCastException>(() => mapper.Map(new TestClass(), new object()));
        }

        [Fact]
        public void WhenMapperDoesNotMapOrIgnoreAllPropertiesThenValidateShouldFail()
        {
            var mapper = new IrrelevantMapper();
            Assert.Throws<MissingMappingException>(() => mapper.ValidateMapping());
        }

        private class IrrelevantMapper : BaseMap<TestClass, TestClass>
        {
            public IrrelevantMapper()
            {
            }
        }

        private class TestClass
        {
            public int Value { get; set; }

            private int PrivateValue { get; set; }
        }
    }
}