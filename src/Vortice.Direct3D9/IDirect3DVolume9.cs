// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using Vortice.Mathematics;

namespace Vortice.Direct3D9;

public unsafe partial class IDirect3DVolume9
{
    public T GetContainer<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(Guid guid) where T : ComObject
    {
        var containerPtr = GetContainer(guid);
        return MarshallingHelpers.FromPointer<T>(containerPtr);
    }

    /// <summary>
    /// Locks a box on a volume resource.
    /// </summary>
    /// <param name="flags">The lock flags.</param>
    /// <returns>The locked region of this resource.</returns>
    public DataBox LockBox(LockFlags flags)
    {
        var lockedBox = LockBox(IntPtr.Zero, flags);
        return new DataBox(lockedBox.Bits, lockedBox.RowPitch, lockedBox.SlicePitch);
    }

    /// <summary>
    /// Locks a box on a volume resource.
    /// </summary>
    /// <param name="box">The box.</param>
    /// <param name="flags">The flags.</param>
    /// <returns>The locked region of this resource</returns>
    public DataBox LockBox(Box box, LockFlags flags)
    {
        var lockedBox = LockBox(new IntPtr(&box), flags);
        return new DataBox(lockedBox.Bits, lockedBox.RowPitch, lockedBox.SlicePitch);
    }
}
