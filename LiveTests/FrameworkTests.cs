using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meyn.TestLink;
using NUnit.Framework;
using NUnit.Core;

namespace LiveTests
{
    [TestFixture]
    public class FrameworkTests
    {
        [Test]
        public void ValidConnection()
        {
            var att = new TestLinkFixtureAttribute();
            att.ProjectName = "LiveTestProject";
            att.TestPlan = "LiveTestPlan";
            att.TestSuite = "TestName";
            att.Url = "http://mathume.com/testing/testlink-1.9.11/lib/api/xmlrpc/v1/xmlrpc.php";
            att.UserId = "automation";
            att.DevKey = "16c4f9ae0383e5989923756dc71f76d4";
            var ad = new TestLinkAdaptor();
            ad.ConnectionData = att;
            Assert.That(ad.ConnectionValid);
        }
    }

    [TestLinkFixture(
        ProjectName="LiveTestProject",
        TestPlan="LiveTestPlan",
        TestSuite="TestName",
        Url="http://mathume.com/testing/testlink-1.9.11/lib/api/xmlrpc/v1/xmlrpc.php",
        UserId = "automation",
        DevKey = "16c4f9ae0383e5989923756dc71f76d4"
        )]
    [TestFixture]
    public class NoInheritance
    {
        [Test]
        public void TestName()
        {
            Assert.Pass();
        }
    }
}
