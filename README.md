# Sparkol

### To Build

1. Open a terminal in the root folder
2. Make _./build.sh_ executable - type ```chmod +x build.sh```
3. Run the build script - type ```./build.sh```

The script will:
* Get nuget packages
* Clean _Debug_ and _Release_ configurations
* Build the _Debug_ configuration
* Run the unit tests against the _Debug_ configuration
* Build and package an Android apk from the _Release_ configuration

After the script has run, you can install the apk on your phone by running:
```adb install Sparkol.Android/bin/Release/petermajor.sparkol-Signed.apk```
