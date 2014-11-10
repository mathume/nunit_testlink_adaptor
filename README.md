NUnit to TestLink addin/adaptor from https://code.google.com/p/gallio-testlink-adapter/ by Stephan Meyn (MIT License).
This repository only contains projects for NUnit and TestLink, not the gallio adaptor.

Known bugs:
1.)	Test cases cannot be added to test plan (TestLinkAdaptor.cs, l. 134).
Possible solution:
1'.)	Use PlatformId: must be introduced on TestLinkFixtureAttribute, can be viewed in Platform Management in TestLink.

Currently there's also a dependency to CookComputing.XmlRpcV2 wich is handled as nuget package. It might make sense to save source, too.

Build:
I use VS 2010 and NuGet (dependencies to XmlRpcV2, NUnit and NUnit.Runners).
I run LiveTests with the NUnit runner in $SolutionDir\packages\NUnit.Runners.2.6.3\tools. Add &lt;supportedRuntime version=&quot;v4.0.30319&quot; /&gt; to nunit.exe.config.

