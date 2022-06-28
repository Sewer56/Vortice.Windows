// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.DXGI;

public partial class IDXGISurface2
{
    public T GetResource<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out int subresourceIndex) where T : ComObject
    {
        GetResource(typeof(T).GUID, out IntPtr nativePtr, out subresourceIndex).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result GetResource<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out int subresourceIndex, out T? parentResource) where T : ComObject
    {
        Result result = GetResource(typeof(T).GUID, out IntPtr nativePtr, out subresourceIndex);
        if (result.Failure)
        {
            parentResource = default;
            return result;
        }

        parentResource = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
}
