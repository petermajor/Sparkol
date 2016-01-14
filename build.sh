#!/bin/sh
set -e

echo Get packages from nuget
/Library/Frameworks/Mono.framework/Versions/Current/bin/nuget restore Sparkol.sln -Source https://www.nuget.org/api/v2/
echo Cleaning solution
xbuild Sparkol.sln /p:Configuration=Debug /t:Clean
xbuild Sparkol.sln /p:Configuration=Release /t:Clean
echo Building solution
xbuild Sparkol.sln /p:Configuration=Debug /t:Build
echo Running unit tests
mono packages/NUnit.Runners.2.6.4/tools/nunit-console.exe Sparkol.Core.Test/bin/Debug/Sparkol.Core.Test.dll
echo Build the Android apk
/Library/Frameworks/Mono.framework/Commands/xbuild /t:SignAndroidPackage /p:Configuration=Release Sparkol.Android/Sparkol.Android.csproj