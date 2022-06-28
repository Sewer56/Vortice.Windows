// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.DXGI;

public partial class IDXGIFactory4
{
    /// <summary>
    /// Gets the default warp adapter.
    /// </summary>
    /// <typeparam name="T">An instance of <see cref="IDXGIAdapter"/></typeparam>
    /// <param name="adapter">The adapter instance of <see cref="IDXGIAdapter"/>, make sure to dispose the instance.</param>
    /// <returns>The warp adapter.</returns>
    public Result EnumWarpAdapter<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? adapter) where T : IDXGIAdapter
    {
        Result result = EnumWarpAdapter(typeof(T).GUID, out IntPtr nativePtr);
        if (result.Success)
        {
            adapter = MarshallingHelpers.FromPointer<T>(nativePtr);
            return result;
        }

        adapter = null;
        return result;
    }

    /// <summary>
    /// Gets the default warp adapter.
    /// </summary>
    /// <typeparam name="T">An instance of <see cref="IDXGIAdapter"/> class.</typeparam>
    /// <returns>The adapter instance of <see cref="IDXGIAdapter"/>, make sure to dispose the instance.</returns>
    public T EnumWarpAdapter<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>() where T : IDXGIAdapter
    {
        EnumWarpAdapter(typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }

    /// <summary>
    /// Gets the adapter for the specified LUID.
    /// </summary>
    /// <param name="adapterLuid">A unique value that identifies the adapter.</param>
    /// <param name="adapter">The adapter instance of <see cref="IDXGIAdapter"/>, make sure to dispose the instance.</param>
    /// <returns>The <see cref="Result"/>.</returns>
    public Result EnumAdapterByLuid<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Luid adapterLuid, out T? adapter) where T : IDXGIAdapter
    {
        Result result = EnumAdapterByLuid(adapterLuid, typeof(T).GUID, out IntPtr nativePtr);
        if (result.Success)
        {
            adapter = MarshallingHelpers.FromPointer<T>(nativePtr);
            return result;
        }

        adapter = null;
        return result;
    }

    /// <summary>
    ///  Gets the adapter for the specified LUID.
    /// </summary>
    /// <typeparam name="T">An instance of <see cref="IDXGIAdapter"/> class.</typeparam>
    /// <param name="adapterLuid">A unique value that identifies the adapter.</param>
    /// <returns>The adapter instance of <see cref="IDXGIAdapter"/>, make sure to dispose the instance.</returns>
    public T EnumAdapterByLuid<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Luid adapterLuid) where T : IDXGIAdapter
    {
        EnumAdapterByLuid(adapterLuid, typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }
}
