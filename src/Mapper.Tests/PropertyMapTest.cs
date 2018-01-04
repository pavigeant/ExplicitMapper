using Xunit;

namespace Mapper.Tests
{
    public class PropertyMapTest
    {
        [Fact]
        public void WhenMappingPropertyThenPropertyShouldBeSet()
        {
            var mapper = new PropertyMapper();

            var s = new Source { Name = "Bob", Age = 18 };
            var t = mapper.Map(s);

            Assert.Equal("Bob18", t.Id);
        }

        [Fact]
        public void WhenMappingFieldThenFieldShouldBeSet()
        {
            var mapper = new PropertyMapper();

            var s = new Source { NameField = "Bob", AgeField = 18 };
            var t = mapper.Map(s);

            Assert.Equal("Bob18", t.IdField);
        }

        private class PropertyMapper : Map<Source, Target>
        {
            public PropertyMapper()
            {
                this.For(t => t.Id, s => $"{s.Name}{s.Age}");
                this.For(t => t.IdField, s => $"{s.NameField}{s.AgeField}");
            }
        }

        private class Source
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string NameField;

            public int AgeField;
        }

        private class Target
        {
            public string IdField;

            public string Id { get; set; }
        }
    }
}