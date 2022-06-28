// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.DXGI;

public partial class IDXGIDeviceSubObject
{
    public T GetDevice<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>() where T : IDXGIDevice
    {
        GetDevice(typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result GetDevice<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? device) where T : IDXGIDevice
    {
        Result result = GetDevice(typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            device = default;
            return result;
        }

        device = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
}
