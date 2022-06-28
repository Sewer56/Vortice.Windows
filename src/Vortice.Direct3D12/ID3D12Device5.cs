﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using Vortice.Direct3D;

namespace Vortice.Direct3D12;

public partial class ID3D12Device5
{
    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <returns>An instance of <see cref="ID3D12MetaCommand"/>.</returns>
    public T CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId) where T : ID3D12MetaCommand
    {
        CreateMetaCommand(commandId, 0, IntPtr.Zero, 0, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="metaCommand">An instance of <see cref="ID3D12MetaCommand"/>.</param>
    /// <returns>The result of operation.</returns>
    public Result CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, out T? metaCommand) where T : ID3D12MetaCommand
    {
        Result result = CreateMetaCommand(commandId, 0, IntPtr.Zero, 0, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            metaCommand = default;
            return result;
        }

        metaCommand = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="nodeMask">For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the device's physical adapters) to which the meta command applies. 
    /// Each bit in the mask corresponds to a single node. Only one bit must be set. </param>
    /// <returns>An instance of <see cref="ID3D12MetaCommand"/>.</returns>
    public T CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, int nodeMask) where T : ID3D12MetaCommand
    {
        CreateMetaCommand(commandId, nodeMask, IntPtr.Zero, 0, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="nodeMask">For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the device's physical adapters) to which the meta command applies. 
    /// Each bit in the mask corresponds to a single node. Only one bit must be set. </param>
    /// <param name="metaCommand">An instance of <see cref="ID3D12MetaCommand"/>.</param>
    /// <returns>The result of operation.</returns>
    public Result CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, int nodeMask, out T? metaCommand) where T : ID3D12MetaCommand
    {
        Result result = CreateMetaCommand(commandId, nodeMask, IntPtr.Zero, 0, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            metaCommand = default;
            return result;
        }

        metaCommand = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="blob">Blob containing the values of the parameters for creating the meta command.</param>
    /// <returns>An instance of <see cref="ID3D12MetaCommand"/>.</returns>
    public T CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, Blob blob) where T : ID3D12MetaCommand
    {
        CreateMetaCommand(commandId, 0, blob.BufferPointer, blob.BufferSize, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="blob">Blob containing the values of the parameters for creating the meta command.</param>
    /// <param name="metaCommand">An instance of <see cref="ID3D12MetaCommand"/>.</param>
    /// <returns>The result of operation</returns>
    public Result CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, Blob blob, out T? metaCommand) where T : ID3D12MetaCommand
    {
        Result result = CreateMetaCommand(commandId, 0, blob.BufferPointer, blob.BufferSize, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            metaCommand = default;
            return result;
        }

        metaCommand = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="nodeMask">For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the device's physical adapters) to which the meta command applies. 
    /// Each bit in the mask corresponds to a single node. Only one bit must be set. </param>
    /// <param name="blob">Blob containing the values of the parameters for creating the meta command.</param>
    /// <returns>An instance of <see cref="ID3D12MetaCommand"/>.</returns>
    public T CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, int nodeMask, Blob blob) where T : ID3D12MetaCommand
    {
        CreateMetaCommand(commandId, nodeMask, blob.BufferPointer, blob.BufferSize, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    /// <summary>
    /// Creates an instance of the specified meta command.
    /// </summary>
    /// <param name="commandId">A <see cref="Guid"/> of the meta command that you wish to instantiate.</param>
    /// <param name="nodeMask">For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the device's physical adapters) to which the meta command applies. 
    /// Each bit in the mask corresponds to a single node. Only one bit must be set. </param>
    /// <param name="blob">Blob containing the values of the parameters for creating the meta command.</param>
    /// <param name="metaCommand">An instance of <see cref="ID3D12MetaCommand"/>.</param>
    /// <returns>The result of the operation.</returns>
    public Result CreateMetaCommand<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid commandId, int nodeMask, Blob blob, out T? metaCommand) where T : ID3D12MetaCommand
    {
        Result result = CreateMetaCommand(commandId, nodeMask, blob.BufferPointer, blob.BufferSize, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            metaCommand = default;
            return result;
        }

        metaCommand = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    #region CreateStateObject
    /// <summary>
    /// Creates a <see cref="ID3D12StateObject"/>.
    /// </summary>
    /// <param name="description">The description of the state object to create.</param>
    /// <returns>An instance of <see cref="ID3D12StateObject"/>.</returns>
    public T CreateStateObject<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(StateObjectDescription description) where T : ID3D12StateObject
    {
        CreateStateObject(description, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    /// <summary>
    /// Creates a <see cref="ID3D12StateObject"/>.
    /// </summary>
    /// <param name="description">The description of the state object to create.</param>
    /// <param name="stateObject">An instance of <see cref="ID3D12StateObject"/>.</param>
    /// <returns>The result of operation.</returns>
    public Result CreateStateObject<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(StateObjectDescription description, out T? stateObject) where T : ID3D12StateObject
    {
        Result result = CreateStateObject(description, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            stateObject = default;
            return result;
        }

        stateObject = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }
    #endregion
}
