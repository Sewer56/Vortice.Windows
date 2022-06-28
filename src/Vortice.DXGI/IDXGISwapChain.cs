// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.DXGI;

public partial class IDXGISwapChain
{
    public bool IsFullscreen
    {
        get
        {
            GetFullscreenState(out RawBool fullscreen, out _).CheckError();
            return fullscreen;
        }
    }

    public IDXGIOutput GetContainingOutput()
    {
        GetContainingOutput(out IDXGIOutput output).CheckError();
        return output;
    }

    public Result GetContainingOutput<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? output) where T : IDXGIOutput
    {
        Result result = GetContainingOutput(out IDXGIOutput outputTemp);
        if (result.Failure)
        {
            output = default;
            return result;
        }

        output = outputTemp.QueryInterfaceOrNull<T>();
        outputTemp.Dispose();
        return result;
    }

    public T GetBuffer<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(int index) where T : ComObject
    {
        GetBuffer(index, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result GetBuffer<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(int index, out T? surface) where T : ComObject
    {
        Result result = GetBuffer(index, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            surface = default;
            return result;
        }

        surface = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    public Result GetFullscreenState(out RawBool fullscreen) => GetFullscreenState(out fullscreen, out _);

    public Result SetFullscreenState(bool fullscreen, IDXGIOutput? target = default) => SetFullscreenState(new RawBool(fullscreen), target);

    public Result ResizeTarget(ModeDescription newTargetParameters) => ResizeTarget(ref newTargetParameters);

    public Result ResizeBuffers(int bufferCount, int width, int height, Format newFormat = Format.Unknown)
    {
        return ResizeBuffers(bufferCount, width, height, newFormat, SwapChainFlags.None);
    }

    public Result Present(int syncInterval)
    {
        return Present(syncInterval, PresentFlags.None);
    }
}
