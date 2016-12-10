# Xamarin With WebService Template

## Introduction

This solution is newly created from the blank Xamarin Forms (XAML) template. Only difference is that Microsoft ASP.NET
Web API 2.2 Client Libraries (Microsoft.AspNet.WebApi.Client 5.2.3) NuGet package has been installed in the PCL project
and all native projects.

## Explanation

The reason for creating this template is that the NuGet developers decided that the hundreds of thousands or possibly
millions of developers that use NuGet in their daily life had it too easy. So they took something that worked but may
have been hacky and broke it: https://github.com/NuGet/Home/issues/1707

Result is that the Web API client cannot be installed into Xamarin.Droid or Xamarin.iOS projects with newer versions of
the NuGet extension for Visual Studio or Xamarin Studio.

Of course, this would not be a problem if Microsoft did their part and made a slight fix to the NuGet setup for the
project. But several months is apparently not enough for a poor tiny corporation such as Microsoft.

So here we are, stuck in a world where the Web API client won't work for Xamarin projects. Thank you NuGet developers
and thank you Microsoft!

## Fix

Fire up a Visual Studio 2013 installation or an ancient version of Xamarin Studio (good luck finding a download link
for the old versions of XS). If you have an up-to-date version of the NuGet VS 2013 plugin, it will be too new and
won't work. So do this:

1. Download a suitably-ancient version of the NuGet Visual Studio plugin. Old versions must be gotten from
 [Codeplex](https://nuget.codeplex.com/releases) whereas newer versions (too new for our purposes) reside on GitHub.
2. Uninstall the current plugin. This can be done from within Visual Studio in Tools -> Extensions and Updates ->
 Installed. Then find NuGet in the list, select it and press the Uninstall button.
3. Close Visual Studio.
4. Run the installer.
5. Voìla! You can now install the package in the usual way. When you are done, you can re-upgrade to the most recent
 NuGet plugin. Remember that some newer NuGet packages won't work in older versions of the plugin!

## Alternative Fix

Clone this repository and copy this solution out into a new folder and use it as a start for your app. This way you can
be on your merry way in no time!
