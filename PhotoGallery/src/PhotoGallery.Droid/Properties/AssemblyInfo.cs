using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PhotoGallery.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Atom")]
[assembly: AssemblyProduct("PhotoGallery.Android")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]

// Needed for Picking photo/video
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

// Needed for Taking photo/video
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]

// Biometrics
[assembly: UsesPermission(Android.Manifest.Permission.UseBiometric)]

// Geolocation
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesFeature("android.hardware.location", Required = false)]
[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
[assembly: UsesFeature("android.hardware.location.network", Required = false)]

// Add these properties if you would like to filter out devices that do not have cameras, or set to false to make them optional
[assembly: UsesFeature("android.hardware.camera", Required = true)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = true)]

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.ForegroundService)]
[assembly: UsesPermission(Android.Manifest.Permission.WakeLock)]
[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]