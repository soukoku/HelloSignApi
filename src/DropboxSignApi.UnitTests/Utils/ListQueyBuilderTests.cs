using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Soukoku.DropboxSignApi.Utils
{
    [TestClass]
    public class ListQueyBuilderTests
    {
        [TestMethod]
        public void Build_WithNoFieldBeforeChain_DontIncludeChainKeyword()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .Chain.And()
                .IsComplete();

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("complete:true", result); // AND is not included
        }


        [TestMethod]
        public void Build_WithNoFieldAfterChain_DontIncludeChainKeyword()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .HasSubject("howdy neighbor")
                .Or();

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("subject:howdy+neighbor", result); // OR is not included
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatedBetween_WithReversedRange_ThrowsArgumentException()
        {
            var builder = new ListQueyBuilder()
                .CreatedBetween(DateTime.Parse("2012/1/1"), DateTime.Parse("2000/1/1"));
        }

        [TestMethod]
        public void CreatedBetween_WithInclusiveFlag_UsesBrackets()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .CreatedBetween(DateTime.Parse("2000/1/1"), DateTime.Parse("2012/1/1"), true);

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("created:[2000-01-01+TO+2012-01-01]", result);
        }

        [TestMethod]
        public void CreatedBetween_WithExclusiveFlag_UsesBraces()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .CreatedBetween(DateTime.Parse("2001/2/3"), DateTime.Parse("2014/5/6"), false);

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("created:{2001-02-03+TO+2014-05-06}", result);
        }

        [TestMethod]
        public void MultipleFields_WithAND_MatchesExpected()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .CreatedBetween(DateTime.Parse("2000/1/1"), DateTime.Parse("2012/1/1"), true)
                .And().IsTest();

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("created:[2000-01-01+TO+2012-01-01]+AND+test_mode:true", result);
        }

        [TestMethod]
        public void MultipleFields_WithOR_MatchesExpected()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .HasSubject("howdy neighbor")
                .Or().HasMessage("some message here");

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("subject:howdy+neighbor+OR+message:some+message+here", result);
        }

        [TestMethod]
        public void MultipleFields_WithMixedChain_MatchesExpected()
        {
            //Arrange
            var builder = new ListQueyBuilder()
                .IsFrom("me")
                .And().SentTo("somebody")
                .Or().SentTo("another person");

            //Act
            var result = builder.ToString();

            //Assert
            Assert.AreEqual("from:me+AND+to:somebody+OR+to:another+person", result);
        }
    }
}
