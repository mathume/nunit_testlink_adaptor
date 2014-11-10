NUnit to TestLink addin/adaptor from https://code.google.com/p/gallio-testlink-adapter/ by Stephan Meyn (MIT License).
This repository only contains projects for NUnit and TestLink, not the gallio adaptor.

Known bugs:
1.)	Test cases cannot be added to test plan (TestLinkAdaptor.cs, l. 134).
2.)	Inherited classes are not reported correctly:
	a.) Super:Sub, then Sub will need to public override tests from Super public virtual.
	b.) Super:Sub1, Super:Sub2: test cases will be overwritten if Sub1 and Sub2 have the same top level test link suite.
Possible solutions:
1'.)	Use PlatformId: must be introduced on TestLinkFixtureAttribute, can be viewed in Platform Management in TestLink.
2'.)	Use test class name in test name (for b.)).

Currently there's also a dependency to CookComputing.XmlRpcV2 wich is handled as nuget package. It might make sense to save source, too.