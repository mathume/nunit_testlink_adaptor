NUnit to TestLink addin/adaptor from https://code.google.com/p/gallio-testlink-adapter/ by Stephan Meyn (MIT License).
This repository only contains projects for NUnit and TestLink, not the gallio adaptor.

NuGet:
The TestLinkFixture and NUnitTestLinkAddOn are available on nuget http://www.nuget.org/packages?q=testlink

Dependencies:
NUnit 2.6.3
.NET 4.0
TestLink [DEV] 1.9.13

Currently there's a dependency to CookComputing.XmlRpcV2 wich is handled as nuget package. It might make sense to save source, too.

Build:
I use VS 2010 and NuGet (dependencies to XmlRpcV2, NUnit and NUnit.Runners).
I run LiveTests with the NUnit runner in $SolutionDir\packages\NUnit.Runners.2.6.3\tools. Add &lt;supportedRuntime version=&quot;v4.0.30319&quot; /&gt; to nunit.exe.config.

News:
PlatformId for TestLinkAttribute has been introduced (also in config file). The parameter is required in order to link test cases with test plans. The test plan doesn't need to be assigned the platform. Results will still be recorded.
Also note that in order to work, user rights are necessary (mine works with a copy plus all rights relevant for platform, execution, test case, test plan modifications).
The PlatformId can be viewed on the Platform Management page (button/text field over the first column of the table shows/hides it).

Tests:
DevTests: don't require real testlink instance.
LiveTests: work with real instance and mainly run on it to be later checked manually. For this we have: (LiveTestProject(LiveTestPlan, top level test suite: LiveTestProject(TestName), platform: Any, build: LiveTestBuild).
