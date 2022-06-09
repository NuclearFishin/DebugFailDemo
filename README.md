# Debugger step-over issue: ClearScript + VS Code + .NET Core MacOS/arm64

This is a minimal reproduction for an issue whereby attempting to step-over the
ClearScript engine execution crashes the VS Code debugger with no error
information.

It's possible this is a .NET Core  MacOS / Linux specific issue, based on issues
I've found that look similar:

https://github.com/OmniSharp/omnisharp-vscode/issues/3655

https://github.com/dotnet/runtime/issues/12739

This repo contains a minimal console app that executes the ClearScript engine
over a JS file that renders a `<div>` via React. 

The console app excutes without issue when executed via `dotnet run`:

```
% dotnet run
Hello, World!
<div>Hello world</div>
Finished. Press enter
```

Likewise the script also runs when invoking directly via node:

```
% node --version
v16.14.0
% node webpack-output.js 
<div>Hello world</div>
```

However, when attaching the VS Code debugger, and attempting to step-over line
15 in `DemoConsoleApp/Program.cs`, namely

```csharp
engine.ExecuteDocument(@"webpack-output.js");
```

...the app terminates with the following output in the debug console:

```
The program '[22971] DemoConsoleApp.dll' has exited with code 0 (0x0).
```

There is no other information output via the debug console, so I cannot
determine how to fix this issue. Hence this repo!

## System Info

Operating system: 

```
Macos Monterey 12.4 (21F79)
```

CPU:

```
Apple M1 Pro
```

VS Code version:
```
Version: 1.67.2 (Universal)
Commit: c3511e6c69bb39013c4a4b7b9566ec1ca73fc4d5
Date: 2022-05-17T18:20:57.384Z
Electron: 17.4.1
Chromium: 98.0.4758.141
Node.js: 16.13.0
V8: 9.8.177.13-electron.0
OS: Darwin arm64 21.5.0
```

.NET Core version:
```
% dotnet --info
.NET SDK (reflecting any global.json):
 Version:   6.0.201
 Commit:    ef40e6aa06

Runtime Environment:
 OS Name:     Mac OS X
 OS Version:  12.4
 OS Platform: Darwin
 RID:         osx.12-arm64
 Base Path:   /usr/local/share/dotnet/sdk/6.0.201/

Host (useful for support):
  Version: 6.0.3
  Commit:  c24d9a9c91

.NET SDKs installed:
  6.0.201 [/usr/local/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.3 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.3 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]

To install additional .NET runtimes or SDKs:
  https://aka.ms/dotnet-download
```