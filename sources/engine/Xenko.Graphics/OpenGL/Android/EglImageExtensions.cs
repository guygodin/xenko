// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

#if XENKO_PLATFORM_ANDROID

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Xenko.Graphics.OpenGL.Android
{
    /// <summary>
    /// EGL and OpenGL ES extension interop for AHardwareBuffer texture binding.
    /// Provides access to EGLImage extensions required for binding AHardwareBuffer to GL textures.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public unsafe static class EglImageExtensions
    {
        // EGL constants
        public const int EGL_NATIVE_BUFFER_ANDROID = 0x3140;
        public const int EGL_IMAGE_PRESERVED_KHR = 0x30D2;
        public const int EGL_TRUE = 1;
        public const int EGL_NONE = 0x3038;
        public const int EGL_NO_CONTEXT = 0;

        // GL_TEXTURE_2D constant (matches OpenTK.Graphics.ES31.TextureTarget.Texture2D)
        public const int GL_TEXTURE_2D = 0x0DE1;

        /// <summary>
        /// Handle to an EGLImage (pointer-sized).
        /// </summary>
        public struct EGLImageKHR
        {
            public IntPtr Handle;
            public static readonly EGLImageKHR None = new EGLImageKHR { Handle = IntPtr.Zero };
            public bool IsValid { get { return Handle != IntPtr.Zero; } }
        }

        /// <summary>
        /// Handle to an EGL client buffer.
        /// </summary>
        public struct EGLClientBuffer
        {
            public IntPtr Handle;
            public bool IsValid { get { return Handle != IntPtr.Zero; } }
        }

        // Delegate types for extension functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr EglGetNativeClientBufferANDROIDDelegate(IntPtr buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr EglCreateImageKHRDelegate(IntPtr display, IntPtr context, int target, IntPtr buffer, int* attribs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int EglDestroyImageKHRDelegate(IntPtr display, IntPtr image);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GlEGLImageTargetTexture2DOESDelegate(int target, IntPtr image);

        // Cached delegate instances (created once in Initialize)
        private static EglGetNativeClientBufferANDROIDDelegate _getNativeClientBuffer;
        private static EglCreateImageKHRDelegate _createImageKHR;
        private static EglDestroyImageKHRDelegate _destroyImageKHR;
        private static GlEGLImageTargetTexture2DOESDelegate _imageTargetTexture2D;

        // P/Invoke for EGL functions
        [DllImport("libEGL.so")]
        private static extern IntPtr eglGetProcAddress(string procname);

        [DllImport("libEGL.so")]
        private static extern int eglGetError();

        [DllImport("libEGL.so")]
        private static extern IntPtr eglGetCurrentDisplay();

        /// <summary>
        /// Gets the current EGL display. Use this instead of a cached display handle.
        /// </summary>
        public static IntPtr GetCurrentDisplay()
        {
            return eglGetCurrentDisplay();
        }

        /// <summary>
        /// Gets whether all required EGLImage extensions are supported.
        /// </summary>
        public static bool IsSupported { get; private set; }

        /// <summary>
        /// Initializes the extension function pointers. Must be called after EGL context creation.
        /// </summary>
        public static void Initialize()
        {
            IntPtr pGetNativeClientBuffer = eglGetProcAddress("eglGetNativeClientBufferANDROID");
            IntPtr pCreateImageKHR = eglGetProcAddress("eglCreateImageKHR");
            IntPtr pDestroyImageKHR = eglGetProcAddress("eglDestroyImageKHR");
            IntPtr pImageTargetTexture2D = eglGetProcAddress("glEGLImageTargetTexture2DOES");

            IsSupported = pGetNativeClientBuffer != IntPtr.Zero
                       && pCreateImageKHR != IntPtr.Zero
                       && pDestroyImageKHR != IntPtr.Zero
                       && pImageTargetTexture2D != IntPtr.Zero;

            if (IsSupported)
            {
                _getNativeClientBuffer = Marshal.GetDelegateForFunctionPointer<EglGetNativeClientBufferANDROIDDelegate>(pGetNativeClientBuffer);
                _createImageKHR = Marshal.GetDelegateForFunctionPointer<EglCreateImageKHRDelegate>(pCreateImageKHR);
                _destroyImageKHR = Marshal.GetDelegateForFunctionPointer<EglDestroyImageKHRDelegate>(pDestroyImageKHR);
                _imageTargetTexture2D = Marshal.GetDelegateForFunctionPointer<GlEGLImageTargetTexture2DOESDelegate>(pImageTargetTexture2D);
            }
        }

        /// <summary>
        /// Converts an AHardwareBuffer to an EGLClientBuffer.
        /// </summary>
        /// <param name="ahardwareBuffer">Native pointer to AHardwareBuffer.</param>
        /// <returns>EGLClientBuffer that can be used with eglCreateImageKHR.</returns>
        /// <exception cref="NotSupportedException">If the extension is not available.</exception>
        public static EGLClientBuffer GetNativeClientBuffer(IntPtr ahardwareBuffer)
        {
            if (_getNativeClientBuffer == null)
                throw new NotSupportedException("eglGetNativeClientBufferANDROID extension not available");

            return new EGLClientBuffer { Handle = _getNativeClientBuffer(ahardwareBuffer) };
        }

        /// <summary>
        /// Creates an EGLImage from an EGLClientBuffer (backed by AHardwareBuffer).
        /// </summary>
        /// <param name="eglDisplay">The EGL display handle.</param>
        /// <param name="clientBuffer">The client buffer from GetNativeClientBuffer.</param>
        /// <returns>An EGLImage handle that can be bound to a GL texture.</returns>
        /// <exception cref="NotSupportedException">If the extension is not available.</exception>
        /// <exception cref="InvalidOperationException">If EGLImage creation fails.</exception>
        public static EGLImageKHR CreateImageFromNativeBuffer(IntPtr eglDisplay, EGLClientBuffer clientBuffer)
        {
            if (_createImageKHR == null)
                throw new NotSupportedException("eglCreateImageKHR extension not available");

            // Attributes: preserve image contents, terminate with EGL_NONE
            var attribs = stackalloc int[] { EGL_IMAGE_PRESERVED_KHR, EGL_TRUE, EGL_NONE };

            // EGL_NO_CONTEXT (IntPtr.Zero) is required for EGL_NATIVE_BUFFER_ANDROID target
            IntPtr result = _createImageKHR(eglDisplay, IntPtr.Zero, EGL_NATIVE_BUFFER_ANDROID, clientBuffer.Handle, attribs);

            if (result == IntPtr.Zero)
            {
                int error = eglGetError();
                throw new InvalidOperationException("eglCreateImageKHR failed with error: 0x" + error.ToString("X"));
            }

            return new EGLImageKHR { Handle = result };
        }

        /// <summary>
        /// Destroys an EGLImage and releases associated resources.
        /// </summary>
        /// <param name="eglDisplay">The EGL display handle.</param>
        /// <param name="image">The EGLImage to destroy.</param>
        public static void DestroyImage(IntPtr eglDisplay, EGLImageKHR image)
        {
            if (_destroyImageKHR == null || !image.IsValid)
                return;

            _destroyImageKHR(eglDisplay, image.Handle);
        }

        /// <summary>
        /// Binds an EGLImage to the currently bound GL texture.
        /// The texture must be bound to GL_TEXTURE_2D before calling this function.
        /// </summary>
        /// <param name="textureTarget">GL texture target (typically GL_TEXTURE_2D = 0x0DE1).</param>
        /// <param name="image">The EGLImage to bind.</param>
        /// <exception cref="NotSupportedException">If the extension is not available.</exception>
        public static void BindImageToTexture(int textureTarget, EGLImageKHR image)
        {
            if (_imageTargetTexture2D == null)
                throw new NotSupportedException("glEGLImageTargetTexture2DOES extension not available");

            _imageTargetTexture2D(textureTarget, image.Handle);
        }
    }
}

#endif
