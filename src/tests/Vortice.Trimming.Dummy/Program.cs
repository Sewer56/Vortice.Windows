// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

/*
    [Notes Originally written by Sewer56]

    == About ==

    This is a dummy for testing Assembly Trimming in supported libraries.
    To use me, publish me as self contained application. That's where the trimmer analyzer works best.

    i.e. `dotnet publish -r win-x64 --self-contained -p:PublishTrimmed=true`
    Docs: https://docs.microsoft.com/en-us/dotnet/core/deploying/trimming/prepare-libraries-for-trimming

    Note: For best results, use the latest .NET Preview SDK.

    == About: SharpGenTools ==

    We can ignore SharpGen.Runtime warnings.

    The justification for this lies in how IL Trimming works:

    - Target file: https://github.com/dotnet/sdk/blob/a546725e4b4e9a06b9b7e07ec62882613bf740b2/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.ILLink.targets#L297
    - IL Linker code: https://github.com/dotnet/linker/blob/4f0d349e43a71d44ef71339293701fcfc2da997e/src/linker/Linker.Steps/ProcessReferencesStep.cs#L30

    Unless overwritten, `TrimmerDefaultAction` is copy.
    As long as SharpGen.Runtime is not marked as trimmable, the IL Linker will apply the copy action.  

    When the copy action is applied, the entire assembly is rooted.
    The linker code above demonstrates that.
    (I found the .NET docs not to explicitly mention that fact, was only kind of implied, so I had to make sure by having a dig through linker code.)

    == About: COM == 

    I've went though the entire solution to find all uses of COM related functionality.  
    The extent of usage boils down to `GetIUnknownForObject`, which effectively exposes a managed object to the native COM world.  

    This does not affect the trimmability of our libraries.

    [Note: If anyone is silly enough however to create classes that implement the native interfaces;
           then they should probably mark their classes with `RequiresUnreferencedCode`.]

    This also applies to SharpGenTools generated code, `GetIUnknownForObject` is only used inside classes that inherit from
    `SharpGen.Runtime.ComObject` and these are wrappers for the native objects from e.g. DirectX which of course wouldn't be trimmed.

    == Miscellaneous ==

    The inclusion of global.json here is ignoring the forced SDK version used for the rest of the project.
    Anyway we look for trim warnings in our libraries; once all warnings are resolved, we mark the library as trimmable.
    Consider also looking inside .csproj file.
 */

Console.WriteLine("Hello World!");
