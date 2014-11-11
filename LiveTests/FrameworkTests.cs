/* 
TestLink API library
Copyright (c) 2014, Sebastian Mitterle <mathume@mathume.com>

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, 
publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/
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
            att.TestSuite = "TestName";
            att.ConfigFile = "testlinkfixture.xml";
            att.ConsiderConfigFile(".");
            var ad = new TestLinkAdaptor();
            ad.ConnectionData = att;
            
            Assert.That(ad.ConnectionValid);
        }
    }

    [TestLinkFixture(
        TestSuite="TestName",
        ConfigFile="testlinkfixture.xml")]
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
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
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
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
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
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
    [TestFixture]
    public class InheritsFromAndWithExplicitAttribute : SuperClassDefiningTestSuiteAndFixture
    {
        [Test]
        public void PassesInSubClass()
        {
            Assert.Pass();
        }
    }

    [TestLinkFixture(
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
    [TestFixture]
    public class ParameterizedTestCases
    {
        [Test]
        public void OneParameter(
            [Values("a", "b")] string some) 
        {
            Assert.Pass();
        }

        [Test, Sequential]
        public void TwoParametersSequential(
            [Values("a", "b")] string some1,
            [Values("c", "d")] string some2)
        {
            Assert.Pass();
        }

        [Test]
        public void TwoParametersPaired(
        [Values("a", "b")] string some1,
            [Values("c", "d")] string some2)
        {
            Assert.Pass();
        }

        static object[] _OneParameter = {
            "a",
            "b"
        };

        static object[] TwoParameters = {
            new object[]{"a", new string[]{"b"}},
            new object[]{"c", new string[]{"d"}}
        };

        [Test, TestCaseSource("_OneParameter")]
        public void OneParameterTCSource(string some)
        {
            Assert.Pass();
        }

        [Test, TestCaseSource("TwoParameters")]
        public void TwoParametersTCSource(object some1, object some2)
        {
            Assert.Pass();
        }
    }

    [TestLinkFixture(
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
    [TestFixture]
    public class ParamterizedTestsInSubclass:ParameterizedTestCases
    {
        static object[] _OneParameter = {
            "a",
            "b"
        };

        static object[] TwoParameters = {
            new object[]{"a", new string[]{"b"}},
            new object[]{"c", new string[]{"d"}}
        };

        static object[] ThreeParameters = {
                                              new object[]{"", 1, new string[]{"a"}},
                                              new object[]{"text", 1, new string[]{"b"}}
                                          };
        [Test, TestCaseSource("ThreeParameters")]
        public void ThreeParametersDefinedInSubclass(string a, int b, string[] c)
        {
            Assert.Pass();
        }
        
    }

    [TestLinkFixture(
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
    [TestFixture]
    public class ParameterizedWithDots
    {
        [Test]
        public void OneParameter(
            [Values("a.a")] string some)
        {
            Assert.Pass();
        }

        [Test]
        public void TwoParameters(
            [Values("a.a")] string some1,
            [Values("b.b")] string some2)
        {
            Assert.Pass();
        }
    }

    [TestLinkFixture(
        TestSuite = "TestName",
        ConfigFile = "testlinkfixture.xml")]
    [TestFixture]
    public class InheritsDots : ParameterizedWithDots { }
}
