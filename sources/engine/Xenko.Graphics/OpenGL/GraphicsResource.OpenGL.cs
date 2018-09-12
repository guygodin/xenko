// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

#if XENKO_GRAPHICS_API_OPENGL 

#if XENKO_GRAPHICS_API_OPENGLES
using OpenTK.Graphics.ES31;
using PixelFormatGl = OpenTK.Graphics.ES31.PixelFormat;
using PixelInternalFormat = OpenTK.Graphics.ES31.TextureComponentCount;
#else
using OpenTK.Graphics.OpenGL;
using PixelFormatGl = OpenTK.Graphics.OpenGL.PixelFormat;
#endif

namespace Xenko.Graphics
{
    /// <summary>
    /// GraphicsResource class
    /// </summary>
    public partial class GraphicsResource
    {
        internal bool DiscardNextMap; // Used to internally force a WriteDiscard (to force a rename) with the GraphicsResourceAllocator

        // Shaader resource view (Texture or Texture Buffer)
        internal int TextureId;
        internal TextureTarget TextureTarget;
        internal PixelInternalFormat TextureInternalFormat;
        internal PixelFormatGl TextureFormat;
        internal PixelType TextureType;
        internal int TexturePixelSize;

        // GG: This is needed when creating TextureSwapChains with the Oculus Mobile SDK
        public int GetTextureId()
        {
            return TextureId;
        }

        // GG: This is needed when creating TextureSwapChains with the Oculus Mobile SDK
        public int GetInternalPixelFormat()
        {
            return (int)TextureInternalFormat;
        }
    }
}
 
#endif
