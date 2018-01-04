using System;
using Xunit;

namespace Mapper.Tests
{
    public class IgnoreMapTest
    {
        [Fact]
        public void WhenIgnoringMapThenPropertyShouldBeUnchanged()
        {
            var source = new TestClass { Value = 5 };
            var target = new TestClass { Value = 8 };
            var mapper = new IgnorantMapper();

            mapper.Map(source, target);

            Assert.Equal(8, target.Value);
        }

        private class IgnorantMapper : BaseMap<TestClass, TestClass>
        {
            public IgnorantMapper()
            {
                this.Ignore(t => t.Value);
            }
        }

        private class TestClass
        {
            public int Value { get; set; }
        }
    }
}