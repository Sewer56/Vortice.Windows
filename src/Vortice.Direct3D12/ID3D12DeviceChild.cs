﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.Direct3D12;

public partial class ID3D12DeviceChild
{
    public Result GetDevice<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? device) where T : ID3D12Device
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

    public T GetDevice<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>() where T : ID3D12Device
    {
        GetDevice(typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }
}
