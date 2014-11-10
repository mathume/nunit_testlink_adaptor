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
        PlatformName="Any",
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

    [TestLinkFixture(
        ProjectName="LiveTestProject",
        TestPlan="LiveTestPlan",
        TestSuite = "TestName",
        PlatformName = "Any",
        Url="http://mathume.com/testing/testlink-1.9.11/lib/api/xmlrpc/v1/xmlrpc.php",
        UserId = "automation",
        DevKey = "16c4f9ae0383e5989923756dc71f76d4"
        )]
    [TestFixture]
    public abstract class SuperClassDefiningTestSuiteAndFixture
    {
        [Test]
        public void PassesInSuperClass()
        {
            Assert.Pass();
        }
    }

    //this class will not be reported: custom attributes are only searched on the class itself
    //not inherited ones. if inherited once were searched this might lead to multiple reporting.
    //this might be investigated later. if you want to avoid writing out parameters on each
    //subclass, use configuration file.
    public class InheritsWithoutExplicitAttribute:SuperClassDefiningTestSuiteAndFixture
    {
        [Test]
        public void PassesInSubClass()
        {
            Assert.Pass();
        }
    }

    [TestFixture]
    public abstract class SuperClassNotDefiningTestSuite
    {
        [Test]
        public void PassesInSuperClass()
        {
            Assert.Pass();
        }
    }

    [TestLinkFixture(
        ProjectName = "LiveTestProject",
        TestPlan = "LiveTestPlan",
        TestSuite = "TestName",
        PlatformName = "Any",
        Url = "http://mathume.com/testing/testlink-1.9.11/lib/api/xmlrpc/v1/xmlrpc.php",
        UserId = "automation",
        DevKey = "16c4f9ae0383e5989923756dc71f76d4"
        )]
    [TestFixture]
    public class InheritsWithExplicitAttribute : SuperClassNotDefiningTestSuite
    {
        [Test]
        public void PassesInSubClass()
        {
            Assert.Pass();
        }
    }

    [TestLinkFixture(
        ProjectName = "LiveTestProject",
        TestPlan = "LiveTestPlan",
        TestSuite = "TestName",
        PlatformName = "Any",
        Url = "http://mathume.com/testing/testlink-1.9.11/lib/api/xmlrpc/v1/xmlrpc.php",
        UserId = "automation",
        DevKey = "16c4f9ae0383e5989923756dc71f76d4"
        )]
    [TestFixture]
    public class InheritsFromAndWithExplicitAttribute : SuperClassDefiningTestSuiteAndFixture
    {
        [Test]
        public void PassesInSubClass()
        {
            Assert.Pass();
        }
    }
}
