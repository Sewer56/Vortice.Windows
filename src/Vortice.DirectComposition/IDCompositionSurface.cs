// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using Vortice.Mathematics;

namespace Vortice.DirectComposition;

public partial class IDCompositionSurface
{
    public T BeginDraw<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(RawRect? updateRect, out Int2 updateOffset) where T : ComObject
    {
        BeginDraw(updateRect, typeof(T).GUID, out IntPtr updateObjectPtr, out updateOffset).CheckError();
        return MarshallingHelpers.FromPointer<T>(updateObjectPtr);
    }

    public Result BeginDraw<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(RawRect? updateRect, out T? updateObject, out Int2 updateOffset) where T : ComObject
    {
        Result result = BeginDraw(updateRect, typeof(T).GUID, out IntPtr updateObjectPtr, out updateOffset);
        if (result.Failure)
        {
            updateObject = default;
            return result;
        }

        updateObject = MarshallingHelpers.FromPointer<T>(updateObjectPtr);
        return result;
    }
}
