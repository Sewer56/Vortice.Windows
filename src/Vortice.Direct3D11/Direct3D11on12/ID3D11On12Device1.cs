﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.Direct3D11on12;

public partial class ID3D11On12Device1
{
    public Result GetD3D12Device<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? device) where T : ComObject
    {
        Result result = GetD3D12Device(typeof(T).GUID, out IntPtr devicePtr);
        if (result.Failure)
        {
            device = default;
            return result;
        }

        device = MarshallingHelpers.FromPointer<T>(devicePtr);
        return result;
    }

    public T GetD3D12Device<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>() where T : ComObject
    {
        GetD3D12Device(typeof(T).GUID, out IntPtr devicePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(devicePtr);
    }
}
