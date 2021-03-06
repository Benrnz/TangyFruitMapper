﻿using Rees.TangyFruitMapper.UnitTest.TestData;
using Xunit;
using Xunit.Abstractions;

namespace Rees.TangyFruitMapper.UnitTest
{
    public class Scenario2_PropertiesWithPrivateAutoSettersTest : MappingGeneratorScenarios<DtoType2, ModelType2_PrivateSet>
    {
        public Scenario2_PropertiesWithPrivateAutoSettersTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Generate_ShouldOutputCode()
        {
            Assert.NotEmpty(this.GeneratedCode);
        }

        [Fact]
        public void Generate_ShouldSuccessfullyMapToDto()
        {
            var mapper = CreateMapperFromGeneratedCode();
            var result = mapper.ToDto(new ModelType2_PrivateSet(410, 3.1415M, "Pie Constant"));

            Assert.Equal(410, result.Age);
            Assert.Equal(3.1415M, result.MyNumber);
            Assert.Equal("Pie Constant", result.Name);
        }

        [Fact]
        public void Generate_ShouldSuccessfullyMapToModel()
        {
            var mapper = CreateMapperFromGeneratedCode();
            var result = mapper.ToModel(new DtoType2
            {
                Age = 410,
                MyNumber = 3.1415M,
                Name = "Pie Constant"
            });

            Assert.Equal(410, result.Age);
            Assert.Equal(3.1415M, result.MyNumber);
            Assert.Equal("Pie Constant", result.Name);
        }
    }
}