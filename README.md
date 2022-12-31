# DropboxSignApi
This is an unofficial Dropbox Sign (previously HelloSign) API lib for dotnet 4.6.2+ and core versions.
It uses HttpClient to do the API calls and supports the async operations out of the box, unlike the
official SDK.

## How to get it
This lib is available via the NuGet package 
[DropboxSignApi](https://www.nuget.org/packages/dropboxsignapi).


## Using the library
All API access is done through an instance of the `DropboxSignClient`.

```cs
// all examples later will make use of this 'client' object
var client = new DropboxSignClient("your apiKey here");
```

### Request models
This library defines tailored models for different requests parameters,
so it's easy to see what are the supported properties for each 
request type.

```cs
var sigRequest = new SendSignatureRequestRequest();
// ...
// set various request properties here
// ...
SignatureRequestResponseWrap response = await client.SendSignatureRequestAsync(sigRequest);
```

#### Files in requests
For any requests that support file uploads you can use either the `FileUrls` or `Files` property.
Use them either for remote http files or local files, but not both in a single request.

```cs
// remote file
sigRequest.FileUrls.Add(new Uri("http://path-to-remote-file"));

// or local file path
sigRequest.Files.Add(new PendingFile("path\to\local\file", "file name here"));

// or local file bytes
byte[] fileData = ...// some how get file data
sigRequest.Files.Add(new PendingFile(fileData, "file name here"));

// or local file stream
Stream fileData = ...// some how get file stream
sigRequest.Files.Add(new PendingFile(fileData, "file name here"));
```

Note that for local files, you will be responsible in disposing the request object
to clean up the streams. It's best to just wrap the request in a using

```cs
using (var sigRequest = new SendSignatureRequestRequest()) {
  // do things with it
}
```


### Response models
All API calls will return the `ApiResponse` class and its sub-classes.
The `ApiResponse` contains all the returned information from the API call,
including any error, warnings, and rate-limiting information.

This means that, assuming the parameters are valid and there are no network errors, 
all API calls will not throw an `Exception` and you will need to handle the returned response
as appropriate based on the error and http status code.

```cs
SignatureRequestResponseWrap response = await client.SendSignatureRequestAsync(sigRequest);

// maybe check rate limits
if (response.RateLimitRemaining < 10)
{
    // do something about it
}

// handle result
if (response.Error == null) 
{
    SignatureRequest finalRequest = response.SignatureRequest;
    // do work ...
} 
else 
{
    // handle error
}


```

### Magic string values
Many of the models contain string properties that have pre-defined values.
Where applicable, the property doc (intellisense) will indicate where you can find those values.
They are usually defined as string constants in a similarly-named static class. 

For example, the `ErrorNames` class contains the possible values for the `Error.Name` property

```cs
// handle error in a response
switch(response.Error.Name)
{
    case ErrorNames.ExceededRate:
        // handle it
        break;
    case ErrorNames.InvalidRecipient:
        // handle it
        break;
    // more cases
}


```



### Event model
This lib can also be used to parse the webhook event callback data:

```cs
string jsonData = ...;// somehow get the event callback json content
Event theEvent = client.ParseEvent(jsonData);
// handle the event
switch(theEvent.EventType)
{
    case EventTypes.SignatureRequestSigned:
        // do something
        break;
    case EventTypes.SignatureRequestEmailBounce:
        // do something
        break;
    // more cases
}
```
