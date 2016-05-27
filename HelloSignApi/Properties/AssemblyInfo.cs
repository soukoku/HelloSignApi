using HelloSignApi;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("HelloSignApi")]
[assembly: AssemblyDescription("Simple task-based HelloSign api lib for FX4.0+ with intellisense doc.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("HelloSignApi")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("0a75d835-4e68-40a1-9c47-a418fc0e987b")]


[assembly: AssemblyCompany("Yin-Chun Wang")]
[assembly: AssemblyCopyright("Copyright © Yin-Chun Wang 2016")]

[assembly: AssemblyVersion(VersionInfo.MajorVersion)]
[assembly: AssemblyFileVersion(VersionInfo.BuildVersion)]
[assembly: AssemblyInformationalVersion(VersionInfo.BuildVersion)]

namespace HelloSignApi
{
    static class VersionInfo
    {
        // keep this same in major releases
        public const string MajorVersion = "1.0.0.0";
        // change this for each nuget release
        public const string BuildVersion = "1.0.0";
    }
}