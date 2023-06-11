using CodeBytes.Reader.Codewars.Models;
using CodeBytes.Reader.Codewars.Mapping;
using System;
using Xunit;
using System.Collections.Generic;
using Mapster;
using CodeBytes.Domain.Model;

namespace CodeBytes.Reader.Codewars.Testcases
{
    public class CodeWarsReaderTests
    {
        private Dictionary<int, Rank> Ranks = new Dictionary<int, Rank>()
        {
            {-8,  new Rank(-8, "Empty1", "Blue") },
            {-7,  new Rank(-7, "Empty2", "Blue") },
            {-6,  new Rank(-6, "Empty3", "Blue") },
            {-5,  new Rank(-5, "Empty4", "Blue") },
            {-4,  new Rank(-4, "Empty5", "Blue") },
            {-3,  new Rank(-3, "Empty6", "Blue") },
            {-2,  new Rank(-2, "Empty7", "Blue") },
            {-1,  new Rank(-1, "Empty8", "Blue") },
            {1,  new Rank(1, "Master1", "Blue") },
            {2,  new Rank(2, "Master2", "Blue") },
            {3,  new Rank(3, "Master3", "Blue") },
            {4,  new Rank(4, "Master4", "Blue") },
        };

        [Theory]
        [InlineData("Title1")]
        [InlineData("Title2")]
        [InlineData("")]
        public void TestTitleMapping(string title)
        {
            //Arrange
            Kata kata = new Kata();
            kata.Name = title;
            kata.Tags = new List<string>() { "GenericTag1" };
            kata.Description = "";
            kata.KataLevel = this.Ranks[-8];

            //Act
            Problem problem = kata.Adapt<Problem>(KataMapsterConfig.KataMapsterConfiguration);

            //Assert
            Assert.Equal(title, problem.Title);
        }

        [Theory]
        [InlineData(1, 3, "Hard")]
        [InlineData(2, 3, "Hard")]
        [InlineData(3, 3, "Hard")]
        [InlineData(4, 3, "Hard")]
        public void TestMasterDifficultyMapping(int ind, int expectedDifficultyInd, string expectedDifficulty)
        {
            //Arrange
            Kata kata = new Kata();
            kata.Name = "Generic1";
            kata.Tags = new List<string>() { "GenericTag1" };
            kata.Description = "";
            kata.KataLevel = this.Ranks[ind];

            //Act
            Problem problem = kata.Adapt<Problem>(KataMapsterConfig.KataMapsterConfiguration);

            //Assert
            Assert.Equal(expectedDifficultyInd, problem.Difficulty);
            Assert.Equal(expectedDifficulty, problem.GetDifficulty);
        }

        [Theory]
        [InlineData(-8, 1, "Easy")]
        [InlineData(-7, 1, "Easy")]
        [InlineData(-6, 2, "Medium")]
        [InlineData(-5, 2, "Medium")]
        [InlineData(-4, 2, "Medium")]
        [InlineData(-3, 3, "Hard")]
        [InlineData(-2, 3, "Hard")]
        [InlineData(-1, 3, "Hard")]
        public void TestStartDifficultyMapping(int ind, int expectedDifficultyInd, string expectedDifficulty)
        {
            //Arrange
            Kata kata = new Kata();
            kata.Name = "Generic1";
            kata.Tags = new List<string>() { "GenericTag1" };
            kata.Description = "";
            kata.KataLevel = this.Ranks[ind];

            //Act
            Problem problem = kata.Adapt<Problem>(KataMapsterConfig.KataMapsterConfiguration);

            //Assert
            Assert.Equal(expectedDifficultyInd, problem.Difficulty);
            Assert.Equal(expectedDifficulty, problem.GetDifficulty);
        }
    }
}
