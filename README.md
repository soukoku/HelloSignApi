# HelloSignApi
This is an unofficial task-based HelloSign API lib for dotnet 4.5.2+ and core versions.
It aims to support all of the non-deprecated HelloSign's v3 API operations.


## How to get it
This lib is available via the NuGet package 
[HelloSignApi](https://www.nuget.org/packages/hellosignapi).


## Using the library
All API access is done through an instance of the `HelloSignClient`.

```cs
// all examples later will make use of this 'client' object
var client = new HelloSignClient("your apiKey here");
```

### Request models
This library defines tailored models for different requests parameters,
so it's easy to see what are the supported properties for each 
request type.

```cs
var sigRequest = new NewSignatureRequest();
// ...
// set various request properties here
// ...
SignatureRequestResponse response = await client.SendSignatureRequestAsync(sigRequest);
```

#### Files in requests
Any request parameters that take a file to upload to HelloSign will have the `Files` property.
Either remote http files or local file are supported, though not both in a single request.

```cs
// remote file
sigRequest.Files.Add(new PendingFile(new Uri("http://path-to-remote-file")));

// or local file path
sigRequest.Files.Add(new PendingFile("path\to\local\file", "file name here"));

// or local file bytes
byte[] fileData = ...// some how get file data
sigRequest.Files.Add(new PendingFile(fileData, "file name here"));

// or local file stream
Stream fileData = ...// some how get file stream
sigRequest.Files.Add(new PendingFile(fileData, "file name here"));
```

Note that for stream data, the stream will be disposed after the API call is made.


### Response models
All API calls will return the `ApiResponse` class and its sub-classes.
The `ApiResponse` contains all the returned information from the API call,
including any error, warnings, and rate-limiting information.
This means that, assuming the parameters are valid and there are no network errors, 
all API calls will not throw an `Exception` and you will need to handle the returned response
as appropriate based on the error (if not null) and http status code.

```cs
SignatureRequestResponse response = await client.SendSignatureRequestAsync(sigRequest);

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
If this lib is used in an http server, 
then it can be used to parse the event callback data from HelloSign as well:

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
