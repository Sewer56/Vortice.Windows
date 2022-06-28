// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace Vortice.DXGI;

public unsafe partial class IDXGIObject
{
    /// <summary>
    /// Gets or sets the debug-name for this object.
    /// </summary>
    public string DebugName
    {
        get
        {
            byte* pname = stackalloc byte[1024];
            int size = 1024 - 1;
            if (GetPrivateData(CommonGuid.DebugObjectName, ref size, new IntPtr(pname)).Failure)
            {
                return string.Empty;
            }

            pname[size] = 0;
            return Marshal.PtrToStringAnsi(new IntPtr(pname));
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                SetPrivateData(CommonGuid.DebugObjectName, 0, IntPtr.Zero);
            }
            else
            {
                IntPtr namePtr = Marshal.StringToHGlobalAnsi(value);
                SetPrivateData(CommonGuid.DebugObjectName, value.Length, namePtr);
            }
        }
    }

    public Result GetParent<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>(out T? @object) where T : ComObject
    {
        Result result = GetParent(typeof(T).GUID, out IntPtr nativePtr);
        if (result.Failure)
        {
            @object = default;
            return result;
        }

        @object = MarshallingHelpers.FromPointer<T>(nativePtr);
        return result;
    }

    public T GetParent<
#if NET6_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
#endif
    T>() where T : ComObject
    {
        GetParent(typeof(T).GUID, out IntPtr nativePtr).CheckError();
        return MarshallingHelpers.FromPointer<T>(nativePtr);
    }
}
