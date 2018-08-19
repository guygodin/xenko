#if XENKO_PLATFORM_ANDROID

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using Android.Opengl;
using OpenTK.Graphics;
using OpenTK.Platform;

namespace Xenko.Graphics
{
    [SuppressUnmanagedCodeSecurity]
    public class EglContext : IGraphicsContext
    {
        #region Fields
        private EGLDisplay _display;
        private EGLSurface _surface;
        #endregion

        #region Constructor
        public EglContext(IWindowInfo window, EGLContext shareContext = null)
        {
            Window = window;
            SwapInterval = 1;

            // Sucky Xamarin Interop!
            _display = EGL14.EglGetDisplay(EGL14.EglDefaultDisplay);
            var major = new int[1];
            var minor = new int[1];
            var result = EGL14.EglInitialize(_display, major, 0, minor, 0);

            var configs = new EGLConfig[128];
            var configCount = new int[1];
            EGL14.EglGetConfigs(_display, configs, 0, configs.Length, configCount, 0);
            var configAttribs = new[]
            {
                EGL14.EglRedSize, 8,
                EGL14.EglGreenSize, 8,
                EGL14.EglBlueSize, 8,
                EGL14.EglAlphaSize, 8,
                EGL14.EglDepthSize, 0,
                EGL14.EglStencilSize, 0,
                EGL14.EglSamples, 0,
                EGL14.EglNone
            };

            var value = new int[1];
            EGLConfig config = null;
            for (int i = 0; i < configCount[0]; i++)
            {
                value[0] = 0;

                EGL14.EglGetConfigAttrib(_display, configs[i], EGL14.EglRenderableType, value, 0);
                if ((value[0] & EGLExt.EglOpenglEs3BitKhr) != EGLExt.EglOpenglEs3BitKhr)
                {
                    continue;
                }

                // The pbuffer config also needs to be compatible with normal window rendering
                // so it can share textures with the window context.
                EGL14.EglGetConfigAttrib(_display, configs[i], EGL14.EglSurfaceType, value, 0);
                if ((value[0] & (EGL14.EglWindowBit | EGL14.EglPbufferBit)) != (EGL14.EglWindowBit | EGL14.EglPbufferBit))
                {
                    continue;
                }

                int j = 0;
                for (; configAttribs[j] != EGL14.EglNone; j += 2)
                {
                    EGL14.EglGetConfigAttrib(_display, configs[i], configAttribs[j], value, 0);
                    if (value[0] != configAttribs[j + 1])
                    {
                        break;
                    }
                }
                if (configAttribs[j] == EGL14.EglNone)
                {
                    config = configs[i];
                    break;
                }
            }

            var contextAttribs = new[] { EGL14.EglContextClientVersion, 3, EGL14.EglNone };
            Context = EGL14.EglCreateContext(_display, config, shareContext ?? EGL14.EglNoContext, contextAttribs, 0);

            var surfaceAttribs = new[]
            {
                EGL14.EglWidth, 1,
                EGL14.EglHeight, 1,
                EGL14.EglTextureTarget, EGL14.EglNoTexture,
                EGL14.EglTextureFormat, EGL14.EglNoTexture,
                EGL14.EglNone
            };

            _surface = EGL14.EglCreatePbufferSurface(_display, config, surfaceAttribs, 0);

            GraphicsMode = new GraphicsMode(32, 16, 0, 0, 0, 0, false);
            GraphicsMode.Index = config.Handle;
        }
        #endregion

        #region Static Properties
        public static IntPtr CurrentContext
        {
            get { return eglGetCurrentContext(); }
        }
        #endregion

        #region Properties
        public IWindowInfo Window { get; private set; }
        public EGLContext Context { get; }
        public bool IsCurrent
        {
            get { return eglGetCurrentContext() == Context.Handle; }
        }

        public bool IsDisposed { get; private set; }
        public bool VSync { get; set; }
        public int SwapInterval { get; set; }
        public GraphicsMode GraphicsMode { get; }
        public bool ErrorChecking { get; set; }
        #endregion

        #region Methods
        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
            }
        }

        public void LoadAll()
        {
        }

        public void MakeCurrent(IWindowInfo window)
        {
            var result = window != null ? EGL14.EglMakeCurrent(_display, _surface, _surface, Context) : EGL14.EglMakeCurrent(_display, EGL14.EglNoSurface, EGL14.EglNoSurface, EGL14.EglNoContext);
            if (!result)
            {
                throw new InvalidOperationException("Failed to make EglContext current");
            }
        }

        public void SwapBuffers()
        {
        }

        public void Update(IWindowInfo window)
        {
            Window = window;
        }
        #endregion

        #region External Methods
        [DllImport("libEGL")]
        private static extern IntPtr eglGetCurrentContext();
        #endregion
    }
}

#endif
