using System;
using System.Collections.Generic;
using System.Text;
using crm_pattern.core;
using Xunit;

namespace carm_pattern.tests
{

    public class EntityFieldMetaDataTests
    {
        [Fact]
        public void Test_FieldMetaData()
        {
            var sut = new EntityFieldMetaData<Person>(z => z.Name);

            Assert.Equal(typeof(string), sut.Type);
            Assert.Equal("Name", sut.Name);

            var name = sut.GetExpression.Compile()(new Person()
            {
                Name = "Tim",
                Age = 35
            });
            Assert.Equal("Tim", name);
        }


        public class Person : Entity
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
