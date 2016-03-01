#Purpose
This is a sample Windows Forms project demonstrating the use of Zoiper SDK for the Common Language Runtime.
Note that the intent is not to show how to build a softphone, but rather the required interactions with the Zoiper SDK for basic use - i.e. create and register a SIP account and create an outgoing call.

#Native Zoiper SDK and the CLR
Zoiper SDK is exposed to the CLR via the CliWrapper class in the  CliWrapper assembly which is added as a reference to the ZoiperWinForms project.
Don't forget that the Zoiper SDK is a **native dll**.

#Points of interest
All of the SDK interactions are done in the ZoiperManager class in ZoiperManager.cs.
ZoiperManager.Initialize covers the necessary steps to start using CliWrapper.

```
public bool Initialize(String certUserName, String certPassword)
{
	zoiper = CliWrapper.CliWrapper.GetWrapperInstance();
	var result = zoiper.InitializeWrapperContext(30000, 40000, 60000);

	if (result == 0)
	{
		result = zoiper.StartActivationSDK(null, "some user", "some password", null);
	}

	return result == 0;
}
```

Note that the method StartActivationSDK is non blocking and the result is returned via the OnActivationCompleted event. 