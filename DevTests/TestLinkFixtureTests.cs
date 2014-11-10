using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DevTests
{
    [TestFixture]
    public class TestLinkFixtureTests
    {
        [Test]
        public void PlatformName()
        {
            var att = new Meyn.TestLink.TestLinkFixtureAttribute();
            att.PlatformName = "somePlatform";
            Assert.That(att.PlatformName, Is.EqualTo("somePlatform"));
        }

        [Test]
        public void PlatformNameFromConfig()
        {
            var att = new Meyn.TestLink.TestLinkFixtureAttribute();
            att.ConfigFile = "testlinkfixture.xml";
            att.ConsiderConfigFile(".");
            Assert.That(att.PlatformName, Is.EqualTo("somePlatform"));
        }

        [Test]
        public void PlatformId()
        {
            var att = new Meyn.TestLink.TestLinkFixtureAttribute();
            att.PlatformId = 1;
            Assert.That(att.PlatformId, Is.EqualTo(1));
        }

        [Test]
        public void PlatformIdFromConfig()
        {
            var att = new Meyn.TestLink.TestLinkFixtureAttribute();
            att.ConfigFile = "testlinkfixture.xml";
            att.ConsiderConfigFile(".");
            Assert.That(att.PlatformId, Is.EqualTo(1));
        }
    }
}
