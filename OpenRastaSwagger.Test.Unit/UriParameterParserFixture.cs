﻿using NUnit.Framework;

namespace OpenRastaSwagger.Test.Unit
{
    [TestFixture]
    public class UriParameterParserFixture
    {
        [Test]
        public void CanParseQueryParam()
        {
            var parser = new UriParameterParser("simple?name={Name}");
            Assert.IsTrue(parser.HasQueryParam("name"));
        }

        [Test]
        public void CanParseMultipleQueryParams()
        {
            var parser = new UriParameterParser("simple?name={Name}&something={someThing}");
            Assert.IsTrue(parser.HasQueryParam("name"));
            Assert.IsTrue(parser.HasQueryParam("something"));
        }

        [Test]
        public void CanParsePathParam()
        {
            var parser = new UriParameterParser("simple/{Name}");
            Assert.IsTrue(parser.HasPathParam("name"));
        }

        [Test]
        public void CanParsePathAndQueryParam()
        {
            var parser = new UriParameterParser("simple/{Name}?id={ID}");
            Assert.IsTrue(parser.HasPathParam("name"));
            Assert.IsTrue(parser.HasQueryParam("id"));
        }

        [Test]
        public void CanParseParamsThatDoNotMatchSignature()
        {
            var parser = new UriParameterParser("parameterized/?f={messageFormat}&p={parameter}");
            Assert.IsTrue(parser.HasQueryParam("messageFormat"));
            Assert.IsTrue(parser.HasQueryParam("parameter"));
        }
    }
}