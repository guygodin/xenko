// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

#if XENKO_PLATFORM_ANDROID

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Xenko.Graphics.OpenGL.Android
{
    /// <summary>
    /// Interop for Android NDK AHardwareBuffer functions.
    /// Requires Android API level 26+ (Android 8.0 Oreo).
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static class AHardwareBufferInterop
    {
        // AHardwareBuffer format constants (from hardware_buffer.h)
        public const uint AHARDWAREBUFFER_FORMAT_R8G8B8A8_UNORM = 1;
        public const uint AHARDWAREBUFFER_FORMAT_R8G8B8X8_UNORM = 2;
        public const uint AHARDWAREBUFFER_FORMAT_R8G8B8_UNORM = 3;
        public const uint AHARDWAREBUFFER_FORMAT_R5G6B5_UNORM = 4;
        public const uint AHARDWAREBUFFER_FORMAT_R16G16B16A16_FLOAT = 0x16;
        public const uint AHARDWAREBUFFER_FORMAT_R10G10B10A2_UNORM = 0x2B;
        public const uint AHARDWAREBUFFER_FORMAT_BLOB = 0x21;
        public const uint AHARDWAREBUFFER_FORMAT_D16_UNORM = 0x30;
        public const uint AHARDWAREBUFFER_FORMAT_D24_UNORM = 0x31;
        public const uint AHARDWAREBUFFER_FORMAT_D24_UNORM_S8_UINT = 0x32;
        public const uint AHARDWAREBUFFER_FORMAT_D32_FLOAT = 0x33;
        public const uint AHARDWAREBUFFER_FORMAT_D32_FLOAT_S8_UINT = 0x34;
        public const uint AHARDWAREBUFFER_FORMAT_S8_UINT = 0x35;
        public const uint AHARDWAREBUFFER_FORMAT_Y8Cb8Cr8_420 = 0x23;

        // AHardwareBuffer usage flags (from hardware_buffer.h)
        public const ulong AHARDWAREBUFFER_USAGE_CPU_READ_NEVER = 0UL;
        public const ulong AHARDWAREBUFFER_USAGE_CPU_READ_RARELY = 2UL;
        public const ulong AHARDWAREBUFFER_USAGE_CPU_READ_OFTEN = 3UL;
        public const ulong AHARDWAREBUFFER_USAGE_CPU_WRITE_NEVER = 0UL << 4;
        public const ulong AHARDWAREBUFFER_USAGE_CPU_WRITE_RARELY = 2UL << 4;
        public const ulong AHARDWAREBUFFER_USAGE_CPU_WRITE_OFTEN = 3UL << 4;
        public const ulong AHARDWAREBUFFER_USAGE_GPU_SAMPLED_IMAGE = 1UL << 8;
        public const ulong AHARDWAREBUFFER_USAGE_GPU_FRAMEBUFFER = 1UL << 9;
        public const ulong AHARDWAREBUFFER_USAGE_GPU_DATA_BUFFER = 1UL << 24;
        public const ulong AHARDWAREBUFFER_USAGE_VIDEO_ENCODE = 1UL << 16;
        public const ulong AHARDWAREBUFFER_USAGE_SENSOR_DIRECT_DATA = 1UL << 23;
        public const ulong AHARDWAREBUFFER_USAGE_PROTECTED_CONTENT = 1UL << 14;

        /// <summary>
        /// Description of an AHardwareBuffer (matches AHardwareBuffer_Desc in hardware_buffer.h).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct AHardwareBuffer_Desc
        {
            /// <summary>Width in pixels.</summary>
            public uint Width;
            /// <summary>Height in pixels.</summary>
            public uint Height;
            /// <summary>Number of layers (for texture arrays).</summary>
            public uint Layers;
            /// <summary>Pixel format (AHARDWAREBUFFER_FORMAT_*).</summary>
            public uint Format;
            /// <summary>Usage flags (AHARDWAREBUFFER_USAGE_*).</summary>
            public ulong Usage;
            /// <summary>Row stride in bytes (only valid after lock).</summary>
            public uint Stride;
            /// <summary>Reserved for future use.</summary>
            public uint Rfu0;
            /// <summary>Reserved for future use.</summary>
            public ulong Rfu1;
        }

        // Note: These functions are only available on Android API 26+
        // The library is "libandroid.so" (accessed as "android")

        /// <summary>
        /// Retrieves the description of an AHardwareBuffer.
        /// </summary>
        /// <param name="buffer">Native pointer to AHardwareBuffer.</param>
        /// <param name="outDesc">Output description struct.</param>
        [DllImport("android", EntryPoint = "AHardwareBuffer_describe")]
        public static extern void Describe(IntPtr buffer, out AHardwareBuffer_Desc outDesc);

        /// <summary>
        /// Acquires a reference to the AHardwareBuffer (increments ref count).
        /// Call this before storing a reference to prevent the buffer from being destroyed.
        /// </summary>
        /// <param name="buffer">Native pointer to AHardwareBuffer.</param>
        [DllImport("android", EntryPoint = "AHardwareBuffer_acquire")]
        public static extern void Acquire(IntPtr buffer);

        /// <summary>
        /// Releases a reference to the AHardwareBuffer (decrements ref count).
        /// When ref count reaches zero, the buffer is destroyed.
        /// </summary>
        /// <param name="buffer">Native pointer to AHardwareBuffer.</param>
        [DllImport("android", EntryPoint = "AHardwareBuffer_release")]
        public static extern void Release(IntPtr buffer);

        /// <summary>
        /// Maps AHardwareBuffer format to Xenko PixelFormat.
        /// </summary>
        /// <param name="ahardwareBufferFormat">AHardwareBuffer format constant.</param>
        /// <returns>Corresponding Xenko PixelFormat.</returns>
        public static PixelFormat ToPixelFormat(uint ahardwareBufferFormat)
        {
            switch (ahardwareBufferFormat)
            {
                case AHARDWAREBUFFER_FORMAT_R8G8B8A8_UNORM:
                    return PixelFormat.R8G8B8A8_UNorm;
                case AHARDWAREBUFFER_FORMAT_R8G8B8X8_UNORM:
                    return PixelFormat.R8G8B8A8_UNorm; // X channel treated as opaque alpha
                case AHARDWAREBUFFER_FORMAT_R16G16B16A16_FLOAT:
                    return PixelFormat.R16G16B16A16_Float;
                case AHARDWAREBUFFER_FORMAT_R10G10B10A2_UNORM:
                    return PixelFormat.R10G10B10A2_UNorm;
                case AHARDWAREBUFFER_FORMAT_R5G6B5_UNORM:
                    return PixelFormat.B5G6R5_UNorm; // Note: may need swizzle
                case AHARDWAREBUFFER_FORMAT_D16_UNORM:
                    return PixelFormat.D16_UNorm;
                case AHARDWAREBUFFER_FORMAT_D24_UNORM_S8_UINT:
                    return PixelFormat.D24_UNorm_S8_UInt;
                case AHARDWAREBUFFER_FORMAT_D32_FLOAT:
                    return PixelFormat.D32_Float;
                case AHARDWAREBUFFER_FORMAT_D32_FLOAT_S8_UINT:
                    return PixelFormat.D32_Float_S8X24_UInt;
                case AHARDWAREBUFFER_FORMAT_Y8Cb8Cr8_420:
                    // YUV format - typically needs conversion shader
                    // Return RGBA as placeholder; actual handling depends on use case
                    return PixelFormat.R8G8B8A8_UNorm;
                default:
                    return PixelFormat.R8G8B8A8_UNorm; // Safe fallback
            }
        }

    }
}

#endif
