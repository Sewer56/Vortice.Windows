// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.



// This is a dummy for testing Assembly Trimming in supported libraries.
// To use me, publish me as self contained application. That's where the trimmer analyzer works best.

// i.e. `dotnet publish -r win-x64 --self-contained -p:PublishTrimmed=true`
// Docs: https://docs.microsoft.com/en-us/dotnet/core/deploying/trimming/prepare-libraries-for-trimming

// Note: For best results, use the latest .NET Preview SDK.
// The inclusion of global.json here is ignoring the forced SDK version used for the rest of the project.
// Anyway we look for trim warnings in our libraries; once all warnings are resolved, we mark the library as trimmable.
// Consider also looking inside .csproj file.

Console.WriteLine("Hello World!");

// We can ignore SharpGen.Runtime warnings.
// https://github.com/dotnet/sdk/blob/a546725e4b4e9a06b9b7e07ec62882613bf740b2/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.ILLink.targets#L297

// The reason is, unless overwritten, `TrimmerDefaultAction` is copy.  
// When 'copy' is used, the entire assembly is rooted, and should be safe to use.

// Note: I (Sewer56) found the documentation on this aspect a bit lacking, so I had a look through the linker, to verify this
// Relevant linker code: https://github.com/dotnet/linker/blob/4f0d349e43a71d44ef71339293701fcfc2da997e/src/linker/Linker.Steps/ProcessReferencesStep.cs#L30
