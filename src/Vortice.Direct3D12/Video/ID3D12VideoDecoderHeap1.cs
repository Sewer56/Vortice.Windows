// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.Direct3D12.Video;

public partial class ID3D12VideoDecoderHeap1
{
    public Result GetProtectedResourceSession<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? protectedSession) where T : ID3D12ProtectedResourceSession
    {
        Result result = GetProtectedResourceSession(typeof(T).GUID, out IntPtr protectedSessionPtr);
        if (result.Failure)
        {
            protectedSession = default;
            return result;
        }

        protectedSession = MarshallingHelpers.FromPointer<T>(protectedSessionPtr);
        return result;
    }

    public T GetProtectedResourceSession<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>() where T : ID3D12ProtectedResourceSession
    {
        GetProtectedResourceSession(typeof(T).GUID, out IntPtr protectedSessionPtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(protectedSessionPtr);
    }
}
