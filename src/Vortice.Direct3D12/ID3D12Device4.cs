// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.Direct3D12;

public partial class ID3D12Device4
{
    #region CreateCommandList1
    public T CreateCommandList1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(CommandListType type, CommandListFlags commandListFlags = CommandListFlags.None) where T : ID3D12GraphicsCommandList1
    {
        CreateCommandList1(0, type, commandListFlags, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public T CreateCommandList1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(int nodeMask, CommandListType type, CommandListFlags commandListFlags = CommandListFlags.None) where T : ID3D12GraphicsCommandList1
    {
        CreateCommandList1(nodeMask, type, commandListFlags, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result CreateCommandList1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(CommandListType type, CommandListFlags commandListFlags, out T? commandList) where T : ID3D12GraphicsCommandList1
    {
        return CreateCommandList1<T>(0, type, commandListFlags, out commandList);
    }

    public Result CreateCommandList1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(int nodeMask, CommandListType type, CommandListFlags commandListFlags, out T? commandList) where T : ID3D12GraphicsCommandList1
    {
        Result result = CreateCommandList1(nodeMask, type, commandListFlags, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            commandList = default;
            return result;
        }

        commandList = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
    #endregion

    #region CreateCommittedResource1
    public T CreateCommittedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(
        HeapProperties heapProperties,
        HeapFlags heapFlags,
        ResourceDescription description,
        ResourceStates initialResourceState,
        ID3D12ProtectedResourceSession protectedSession,
        ClearValue? optimizedClearValue = null) where T : ID3D12Resource1
    {
        CreateCommittedResource1(ref heapProperties, heapFlags,
            ref description,
            initialResourceState,
            optimizedClearValue,
            protectedSession,
            typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result CreateCommittedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(
        HeapProperties heapProperties,
        HeapFlags heapFlags,
        ResourceDescription description,
        ResourceStates initialResourceState,
        ID3D12ProtectedResourceSession protectedSession,
        out T? resource) where T : ID3D12Resource1
    {
        Result result = CreateCommittedResource1(ref heapProperties, heapFlags,
            ref description,
            initialResourceState,
            null,
            protectedSession,
            typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            resource = default;
            return result;
        }

        resource = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    public Result CreateCommittedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(
        HeapProperties heapProperties,
        HeapFlags heapFlags,
        ResourceDescription description,
        ResourceStates initialResourceState,
        ID3D12ProtectedResourceSession protectedSession,
        ClearValue optimizedClearValue,
        out T? resource) where T : ID3D12Resource1
    {
        Result result = CreateCommittedResource1(ref heapProperties, heapFlags,
            ref description,
            initialResourceState,
            optimizedClearValue,
            protectedSession,
            typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            resource = default;
            return result;
        }

        resource = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
    #endregion

    #region CreateHeap1
    public T CreateHeap1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(HeapDescription description, ID3D12ProtectedResourceSession protectedSession) where T : ID3D12Heap1
    {
        CreateHeap1(ref description, protectedSession, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result CreateHeap1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(HeapDescription description, ID3D12ProtectedResourceSession protectedSession, out T? heap) where T : ID3D12Heap1
    {
        Result result = CreateHeap1(ref description, protectedSession, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            heap = default;
            return result;
        }

        heap = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
    #endregion

    #region CreateProtectedResourceSession
    public T CreateProtectedResourceSession<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(ProtectedResourceSessionDescription description) where T : ID3D12ProtectedResourceSession
    {
        CreateProtectedResourceSession(description, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result CreateProtectedResourceSession<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(ProtectedResourceSessionDescription description, out T? resource) where T : ID3D12ProtectedResourceSession
    {
        Result result = CreateProtectedResourceSession(description, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            resource = default;
            return result;
        }

        resource = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
    #endregion

    #region CreateReservedResource1
    public T CreateReservedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(ResourceDescription description, ResourceStates initialState, ClearValue clearValue, ID3D12ProtectedResourceSession protectedResourceSession) where T : ID3D12Resource1
    {
        CreateReservedResource1(ref description, initialState, clearValue, protectedResourceSession, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result CreateReservedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(ResourceDescription description, ResourceStates initialState, ClearValue clearValue, ID3D12ProtectedResourceSession protectedResourceSession, out T? resource) where T : ID3D12Resource1
    {
        Result result = CreateReservedResource1(ref description, initialState, clearValue, protectedResourceSession, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            resource = default;
            return result;
        }

        resource = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    public T CreateReservedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(ResourceDescription description, ResourceStates initialState, ID3D12ProtectedResourceSession protectedResourceSession) where T : ID3D12Resource1
    {
        CreateReservedResource1(ref description, initialState, null, protectedResourceSession, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    public Result CreateReservedResource1<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(ResourceDescription description, ResourceStates initialState, ID3D12ProtectedResourceSession protectedResourceSession, out T? resource) where T : ID3D12Resource1
    {
        Result result = CreateReservedResource1(ref description, initialState, null, protectedResourceSession, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            resource = default;
            return result;
        }

        resource = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
    #endregion
}
