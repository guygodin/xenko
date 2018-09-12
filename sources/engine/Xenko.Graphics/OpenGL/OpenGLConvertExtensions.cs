// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
#if XENKO_GRAPHICS_API_OPENGL 
using System;
using OpenTK.Graphics;
#if XENKO_GRAPHICS_API_OPENGLES
using OpenTK.Graphics.ES31;
using ES30 = OpenTK.Graphics.ES31;
using PixelFormatGl = OpenTK.Graphics.ES31.PixelFormat;
using PixelInternalFormat = OpenTK.Graphics.ES31.TextureComponentCount;
using PrimitiveTypeGl = OpenTK.Graphics.ES31.PrimitiveType;
#else
using OpenTK.Graphics.OpenGL;
using PixelFormatGl = OpenTK.Graphics.OpenGL.PixelFormat;
using PrimitiveTypeGl = OpenTK.Graphics.OpenGL.PrimitiveType;
#endif

namespace Xenko.Graphics
{
    internal static class OpenGLConvertExtensions
    {
        public static ErrorCode GetErrorCode()
        {
            return GL.GetError();
        }

        public static unsafe Color4 ToOpenGL(Core.Mathematics.Color4 color)
        {
            return *(Color4*)&color;
        }

        public static PrimitiveTypeGl ToOpenGL(this PrimitiveType primitiveType)
        {
            switch (primitiveType)
            {
                case PrimitiveType.PointList:
                    return PrimitiveTypeGl.Points;
                case PrimitiveType.LineList:
                    return PrimitiveTypeGl.Lines;
                case PrimitiveType.LineStrip:
                    return PrimitiveTypeGl.LineStrip;
                case PrimitiveType.TriangleList:
                    return PrimitiveTypeGl.Triangles;
                case PrimitiveType.TriangleStrip:
                    return PrimitiveTypeGl.TriangleStrip;
                default:
                    // Undefined
                    return PrimitiveTypeGl.Triangles;
            }
        }

        public static BufferAccessMask ToOpenGLMask(this MapMode mapMode)
        {
            switch (mapMode)
            {
                case MapMode.Read:
                    return BufferAccessMask.MapReadBit;
                case MapMode.Write:
                    return BufferAccessMask.MapWriteBit;
                case MapMode.ReadWrite:
                    return BufferAccessMask.MapReadBit | BufferAccessMask.MapWriteBit;
                case MapMode.WriteDiscard:
                    return BufferAccessMask.MapWriteBit | BufferAccessMask.MapInvalidateBufferBit;
                case MapMode.WriteNoOverwrite:
                    return BufferAccessMask.MapWriteBit | BufferAccessMask.MapUnsynchronizedBit;
                default:
                    throw new ArgumentOutOfRangeException("mapMode");
            }
        }

#if XENKO_GRAPHICS_API_OPENGLES
        public static ES30.PrimitiveType ToOpenGLES(this PrimitiveType primitiveType)
        {
            switch (primitiveType)
            {
                case PrimitiveType.PointList:
                    return ES30.PrimitiveType.Points;
                case PrimitiveType.LineList:
                    return ES30.PrimitiveType.Lines;
                case PrimitiveType.LineStrip:
                    return ES30.PrimitiveType.LineStrip;
                case PrimitiveType.TriangleList:
                    return ES30.PrimitiveType.Triangles;
                case PrimitiveType.TriangleStrip:
                    return ES30.PrimitiveType.TriangleStrip;
                default:
                    throw new NotImplementedException();
            }
        }
#else
        public static BufferAccess ToOpenGL(this MapMode mapMode)
        {
            switch (mapMode)
            {
                case MapMode.Read:
                    return BufferAccess.ReadOnly;
                case MapMode.Write:
                case MapMode.WriteDiscard:
                case MapMode.WriteNoOverwrite:
                    return BufferAccess.WriteOnly;
                case MapMode.ReadWrite:
                    return BufferAccess.ReadWrite;
                default:
                    throw new ArgumentOutOfRangeException("mapMode");
            }
        }
#endif

        public static TextureWrapMode ToOpenGL(this TextureAddressMode addressMode)
        {
            switch (addressMode)
            {
                case TextureAddressMode.Border:
#if !XENKO_GRAPHICS_API_OPENGLES
                    return TextureWrapMode.ClampToBorder;
#endif
                case TextureAddressMode.Clamp:
                    return TextureWrapMode.ClampToEdge;
                case TextureAddressMode.Mirror:
#if XENKO_GRAPHICS_API_OPENGLES
                    return (TextureWrapMode)EsVersion20.MirroredRepeat;
#else
                    return TextureWrapMode.MirroredRepeat;
#endif
                case TextureAddressMode.Wrap:
                    return TextureWrapMode.Repeat;
                default:
                    throw new NotImplementedException();
            }
        }

        public static DepthFunction ToOpenGLDepthFunction(this CompareFunction function)
        {
            switch (function)
            {
                case CompareFunction.Always:
                    return DepthFunction.Always;
                case CompareFunction.Equal:
                    return DepthFunction.Equal;
                case CompareFunction.GreaterEqual:
                    return DepthFunction.Gequal;
                case CompareFunction.Greater:
                    return DepthFunction.Greater;
                case CompareFunction.LessEqual:
                    return DepthFunction.Lequal;
                case CompareFunction.Less:
                    return DepthFunction.Less;
                case CompareFunction.Never:
                    return DepthFunction.Never;
                case CompareFunction.NotEqual:
                    return DepthFunction.Notequal;
                default:
                    throw new NotImplementedException();
            }
        }

        public static StencilFunction ToOpenGLStencilFunction(this CompareFunction function)
        {
            switch (function)
            {
                case CompareFunction.Always:
                    return StencilFunction.Always;
                case CompareFunction.Equal:
                    return StencilFunction.Equal;
                case CompareFunction.GreaterEqual:
                    return StencilFunction.Gequal;
                case CompareFunction.Greater:
                    return StencilFunction.Greater;
                case CompareFunction.LessEqual:
                    return StencilFunction.Lequal;
                case CompareFunction.Less:
                    return StencilFunction.Less;
                case CompareFunction.Never:
                    return StencilFunction.Never;
                case CompareFunction.NotEqual:
                    return StencilFunction.Notequal;
                default:
                    throw new NotImplementedException();
            }
        }

        public static StencilOp ToOpenGL(this StencilOperation operation)
        {
            switch (operation)
            {
                case StencilOperation.Keep:
                    return StencilOp.Keep;
                case StencilOperation.Zero:
                    return StencilOp.Zero;
                case StencilOperation.Replace:
                    return StencilOp.Replace;
                case StencilOperation.IncrementSaturation:
                    return StencilOp.Incr;
                case StencilOperation.DecrementSaturation:
                    return StencilOp.Decr;
                case StencilOperation.Invert:
                    return StencilOp.Invert;
                case StencilOperation.Increment:
                    return StencilOp.IncrWrap;
                case StencilOperation.Decrement:
                    return StencilOp.DecrWrap;
                default:
                    throw new ArgumentOutOfRangeException("operation");
            }
        }

        public static void ConvertPixelFormat(GraphicsDevice graphicsDevice, ref PixelFormat inputFormat, out PixelInternalFormat internalFormat, out PixelFormatGl format, out PixelType type,
            out int pixelSize, out bool compressed)
        {
            compressed = false;

#if XENKO_GRAPHICS_API_OPENGLES
            // check formats more carefully if the device is initialized with OpenGL ES 2
            if (graphicsDevice.currentVersion < 300)
            {
                switch (inputFormat)
                {
                    case PixelFormat.R16_Float:
                    case PixelFormat.R16G16_Float:
                        if (!graphicsDevice.HasTextureRG || !graphicsDevice.HasTextureHalf)
                            goto unsupported;
                        break;
                    case PixelFormat.R16G16B16A16_Float:
                        if (!graphicsDevice.HasTextureHalf)
                            goto unsupported;
                        break;
                    case PixelFormat.R16_UInt:
                    case PixelFormat.R16_SInt:
                    case PixelFormat.R16G16_UInt:
                    case PixelFormat.R16G16_SInt:
                    case PixelFormat.R16G16B16A16_UInt:
                    case PixelFormat.R16G16B16A16_SInt:
                        goto unsupported;
                    case PixelFormat.R32_Float:
                    case PixelFormat.R32G32_Float:
                    case PixelFormat.R32G32B32_Float:
                        if (!graphicsDevice.HasTextureRG || !graphicsDevice.HasTextureFloat)
                            goto unsupported;
                        break;
                    case PixelFormat.R32G32B32A32_Float:
                        if (!graphicsDevice.HasTextureFloat)
                            goto unsupported;
                        break;
                    case PixelFormat.R32_UInt:
                    case PixelFormat.R32_SInt:
                    case PixelFormat.R32G32_UInt:
                    case PixelFormat.R32G32_SInt:
                    case PixelFormat.R32G32B32_UInt:
                    case PixelFormat.R32G32B32_SInt:
                    case PixelFormat.R32G32B32A32_UInt:
                    case PixelFormat.R32G32B32A32_SInt:
                        goto unsupported;
                    case PixelFormat.D32_Float:
                        goto unsupported;
                    unsupported:
                        throw new NotSupportedException($"Texture format {inputFormat} not supported with OpenGL ES 2.0");

                    // NOTE: We always allow PixelFormat.D24_UNorm_S8_UInt.
                    // If it is not supported we will fall back to separate D24/D16 and S8 resources when creating a texture.
                }
            }
#endif

            // If the Device doesn't support SRGB, we remap automatically the format to non-srgb
            if (!graphicsDevice.Features.HasSRgb)
            {
                switch (inputFormat)
                {
                    case PixelFormat.PVRTC_2bpp_RGB_SRgb:
                        inputFormat = PixelFormat.PVRTC_2bpp_RGB;
                        break;
                    case PixelFormat.PVRTC_2bpp_RGBA_SRgb:
                        inputFormat = PixelFormat.PVRTC_2bpp_RGBA;
                        break;
                    case PixelFormat.PVRTC_4bpp_RGB_SRgb:
                        inputFormat = PixelFormat.PVRTC_4bpp_RGB;
                        break;
                    case PixelFormat.PVRTC_4bpp_RGBA_SRgb:
                        inputFormat = PixelFormat.PVRTC_4bpp_RGBA;
                        break;
                    case PixelFormat.ETC2_RGB_SRgb:
                        inputFormat = PixelFormat.ETC2_RGB;
                        break;
                    case PixelFormat.ETC2_RGBA_SRgb:
                        inputFormat = PixelFormat.ETC2_RGBA;
                        break;
                    case PixelFormat.ASTC_RGBA_4X4_SRgb:
                        inputFormat = PixelFormat.ASTC_RGBA_4X4;
                        break;
                    case PixelFormat.R8G8B8A8_UNorm_SRgb:
                        inputFormat = PixelFormat.R8G8B8A8_UNorm;
                        break;
                    case PixelFormat.B8G8R8A8_UNorm_SRgb:
                        inputFormat = PixelFormat.B8G8R8A8_UNorm;
                        break;
                }
            }

            switch (inputFormat)
            {
                case PixelFormat.A8_UNorm:
                    internalFormat = PixelInternalFormat.Alpha;
                    format = PixelFormatGl.Alpha;
                    type = PixelType.UnsignedByte;
                    pixelSize = 1;
                    break;
                case PixelFormat.R8_UNorm:
#if XENKO_GRAPHICS_API_OPENGLES
                    if (!graphicsDevice.HasTextureRG && graphicsDevice.currentVersion < 300)
                    {
                        internalFormat = PixelInternalFormat.Luminance;
                        format = PixelFormatGl.Luminance;
                    }
                    else
#endif
                    {
                        internalFormat = PixelInternalFormat.R8;
                        format = PixelFormatGl.Red;
                    }
                    type = PixelType.UnsignedByte;
                    pixelSize = 1;
                    break;
                case PixelFormat.R8G8B8A8_UNorm:
                    internalFormat = PixelInternalFormat.Rgba;
                    format = PixelFormatGl.Rgba;
                    type = PixelType.UnsignedByte;
                    pixelSize = 4;
                    break;
                case PixelFormat.B8G8R8A8_UNorm:
#if XENKO_GRAPHICS_API_OPENGLES
                    if (!graphicsDevice.HasExtTextureFormatBGRA8888)
                        throw new NotSupportedException();

                    // It seems iOS and Android expects different things
#if XENKO_PLATFORM_IOS
                    internalFormat = PixelInternalFormat.Rgba;
#else
                    internalFormat = (PixelInternalFormat)ExtTextureFormatBgra8888.BgraExt;
#endif
                    format = (PixelFormatGl)ExtTextureFormatBgra8888.BgraExt;
#else
                    internalFormat = PixelInternalFormat.Rgba;
                    format = PixelFormatGl.Bgra;
#endif
                    type = PixelType.UnsignedByte;
                    pixelSize = 4;
                    break;
                case PixelFormat.R8G8B8A8_UNorm_SRgb:
                    internalFormat = PixelInternalFormat.Srgb8Alpha8;
                    format = PixelFormatGl.Rgba;
                    type = PixelType.UnsignedByte;
                    pixelSize = 4;
                    break;
#if XENKO_GRAPHICS_API_OPENGLCORE
                case PixelFormat.B8G8R8A8_UNorm_SRgb:
                    // TODO: Check on iOS/Android and OpenGL 3
                    internalFormat = PixelInternalFormat.Srgb8Alpha8;
                    format = PixelFormatGl.Bgra;
                    type = PixelType.UnsignedByte;
                    pixelSize = 4;
                    break;
                case PixelFormat.BC1_UNorm:
                    if (!graphicsDevice.HasDXT)
                        throw new NotSupportedException();
                    internalFormat = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext;
                    format = (PixelFormatGl)PixelInternalFormat.CompressedRgbaS3tcDxt1Ext;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    compressed = true;
                    break;
                case PixelFormat.BC1_UNorm_SRgb:
                    if (!graphicsDevice.HasDXT)
                        throw new NotSupportedException();
                    internalFormat = PixelInternalFormat.CompressedSrgbAlphaS3tcDxt1Ext;
                    format = (PixelFormatGl)PixelInternalFormat.CompressedSrgbAlphaS3tcDxt1Ext;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    compressed = true;
                    break;
                case PixelFormat.BC2_UNorm:
                    if (!graphicsDevice.HasDXT)
                        throw new NotSupportedException();
                    internalFormat = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext;
                    format = (PixelFormatGl)PixelInternalFormat.CompressedRgbaS3tcDxt3Ext;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    compressed = true;
                    break;
                case PixelFormat.BC2_UNorm_SRgb:
                    if (!graphicsDevice.HasDXT)
                        throw new NotSupportedException();
                    internalFormat = PixelInternalFormat.CompressedSrgbAlphaS3tcDxt3Ext;
                    format = (PixelFormatGl)PixelInternalFormat.CompressedSrgbAlphaS3tcDxt3Ext;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    compressed = true;
                    break;
                case PixelFormat.BC3_UNorm:
                    if (!graphicsDevice.HasDXT)
                        throw new NotSupportedException();
                    internalFormat = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext;
                    format = (PixelFormatGl)PixelInternalFormat.CompressedRgbaS3tcDxt5Ext;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    compressed = true;
                    break;
                case PixelFormat.BC3_UNorm_SRgb:
                    if (!graphicsDevice.HasDXT)
                        throw new NotSupportedException();
                    internalFormat = PixelInternalFormat.CompressedSrgbAlphaS3tcDxt5Ext;
                    format = (PixelFormatGl)PixelInternalFormat.CompressedSrgbAlphaS3tcDxt5Ext;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    compressed = true;
                    break;
#endif
                case PixelFormat.R16_SInt:
                    internalFormat = PixelInternalFormat.R16i;
                    format = PixelFormatGl.RedInteger;
                    type = PixelType.Short;
                    pixelSize = 2;
                    break;
                case PixelFormat.R16_UInt:
                    internalFormat = PixelInternalFormat.R16ui;
                    format = PixelFormatGl.RedInteger;
                    type = PixelType.UnsignedShort;
                    pixelSize = 2;
                    break;
                case PixelFormat.R16_Float:
                    internalFormat = PixelInternalFormat.R16f;
                    format = PixelFormatGl.Red;
                    type = PixelType.HalfFloat;
                    pixelSize = 2;
                    break;
                case PixelFormat.R16G16_SInt:
                    internalFormat = PixelInternalFormat.Rg16i;
                    format = PixelFormatGl.RgInteger;
                    type = PixelType.Short;
                    pixelSize = 4;
                    break;
                case PixelFormat.R16G16_UInt:
                    internalFormat = PixelInternalFormat.Rg16ui;
                    format = PixelFormatGl.RgInteger;
                    type = PixelType.UnsignedShort;
                    pixelSize = 4;
                    break;
                case PixelFormat.R16G16_Float:
                    internalFormat = PixelInternalFormat.Rg16f;
                    format = PixelFormatGl.Rg;
                    type = PixelType.HalfFloat;
                    pixelSize = 4;
                    break;
                case PixelFormat.R16G16B16A16_SInt:
                    internalFormat = PixelInternalFormat.Rgba16i;
                    format = PixelFormatGl.RgbaInteger;
                    type = PixelType.Short;
                    pixelSize = 8;
                    break;
                case PixelFormat.R16G16B16A16_UInt:
                    internalFormat = PixelInternalFormat.Rgba16ui;
                    format = PixelFormatGl.RgbaInteger;
                    type = PixelType.UnsignedShort;
                    pixelSize = 8;
                    break;
                case PixelFormat.R16G16B16A16_Float:
                    internalFormat = PixelInternalFormat.Rgba16f;
                    format = PixelFormatGl.Rgba;
                    type = PixelType.HalfFloat;
                    pixelSize = 8;
                    break;
                case PixelFormat.R10G10B10A2_UNorm:
                    internalFormat = PixelInternalFormat.Rgb10A2;
                    format = PixelFormatGl.Rgba;
                    type = PixelType.UnsignedInt1010102;
                    pixelSize = 4;
                    break;
                case PixelFormat.R11G11B10_Float:
                    internalFormat = PixelInternalFormat.R11fG11fB10f;
                    format = PixelFormatGl.Rgb;
                    type = PixelType.HalfFloat;
                    pixelSize = 4;
                    break;
                case PixelFormat.R32_SInt:
                    internalFormat = PixelInternalFormat.R32i;
                    format = PixelFormatGl.RedInteger;
                    type = PixelType.Int;
                    pixelSize = 4;
                    break;
                case PixelFormat.R32_UInt:
                    internalFormat = PixelInternalFormat.R32ui;
                    format = PixelFormatGl.RedInteger;
                    type = PixelType.UnsignedInt;
                    pixelSize = 4;
                    break;
                case PixelFormat.R32_Float:
                    internalFormat = PixelInternalFormat.R32f;
                    format = PixelFormatGl.Red;
                    type = PixelType.Float;
                    pixelSize = 4;
                    break;
                case PixelFormat.R32G32_SInt:
                    internalFormat = PixelInternalFormat.Rg32i;
                    format = PixelFormatGl.RgInteger;
                    type = PixelType.Int;
                    pixelSize = 8;
                    break;
                case PixelFormat.R32G32_UInt:
                    internalFormat = PixelInternalFormat.Rg32ui;
                    format = PixelFormatGl.RgInteger;
                    type = PixelType.UnsignedInt;
                    pixelSize = 8;
                    break;
                case PixelFormat.R32G32_Float:
                    internalFormat = PixelInternalFormat.Rg32f;
                    format = PixelFormatGl.Rg;
                    type = PixelType.Float;
                    pixelSize = 8;
                    break;
                case PixelFormat.R32G32B32_SInt:
                    internalFormat = PixelInternalFormat.Rgb32i;
                    format = PixelFormatGl.RgbInteger;
                    type = PixelType.Int;
                    pixelSize = 12;
                    break;
                case PixelFormat.R32G32B32_UInt:
                    internalFormat = PixelInternalFormat.Rgb32ui;
                    format = PixelFormatGl.RgbInteger;
                    type = PixelType.UnsignedInt;
                    pixelSize = 12;
                    break;
                case PixelFormat.R32G32B32_Float:
                    internalFormat = PixelInternalFormat.Rgb32f;
                    format = PixelFormatGl.Rgb;
                    type = PixelType.Float;
                    pixelSize = 12;
                    break;
                case PixelFormat.R32G32B32A32_SInt:
                    internalFormat = PixelInternalFormat.Rgba32i;
                    format = PixelFormatGl.RgbaInteger;
                    type = PixelType.Int;
                    pixelSize = 16;
                    break;
                case PixelFormat.R32G32B32A32_UInt:
                    internalFormat = PixelInternalFormat.Rgba32ui;
                    format = PixelFormatGl.RgbaInteger;
                    type = PixelType.UnsignedInt;
                    pixelSize = 16;
                    break;
                case PixelFormat.R32G32B32A32_Float:
                    internalFormat = PixelInternalFormat.Rgba32f;
                    format = PixelFormatGl.Rgba;
                    type = PixelType.Float;
                    pixelSize = 16;
                    break;
                case PixelFormat.D16_UNorm:
                    internalFormat = PixelInternalFormat.DepthComponent16;
                    format = PixelFormatGl.DepthComponent;
                    type = PixelType.UnsignedShort;
                    pixelSize = 2;
                    break;
                case PixelFormat.D24_UNorm_S8_UInt:
                    internalFormat = PixelInternalFormat.Depth24Stencil8;
                    format = PixelFormatGl.DepthStencil;
                    type = PixelType.UnsignedInt248;
                    pixelSize = 4;
                    break;
                // TODO: Temporary depth format (need to decide relation between RenderTarget1D and Texture)
                case PixelFormat.D32_Float:
                    internalFormat = PixelInternalFormat.DepthComponent32f;
                    format = PixelFormatGl.DepthComponent;
                    type = PixelType.Float;
                    pixelSize = 4;
                    break;
#if XENKO_PLATFORM_IOS
                case PixelFormat.PVRTC_4bpp_RGB:
                    internalFormat = (PixelInternalFormat)ImgTextureCompressionPvrtc.CompressedRgbPvrtc4Bppv1Img;
                    format = (PixelFormatGl)ImgTextureCompressionPvrtc.CompressedRgbPvrtc4Bppv1Img;
                    compressed = true;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_2bpp_RGB:
                    internalFormat = (PixelInternalFormat)ImgTextureCompressionPvrtc.CompressedRgbPvrtc2Bppv1Img;
                    format = (PixelFormatGl)ImgTextureCompressionPvrtc.CompressedRgbPvrtc2Bppv1Img;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_4bpp_RGBA:
                    internalFormat = (PixelInternalFormat)ImgTextureCompressionPvrtc.CompressedRgbaPvrtc4Bppv1Img;
                    format = (PixelFormatGl)ImgTextureCompressionPvrtc.CompressedRgbaPvrtc4Bppv1Img;
                    compressed = true;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_2bpp_RGBA:
                    internalFormat = (PixelInternalFormat)ImgTextureCompressionPvrtc.CompressedRgbaPvrtc2Bppv1Img;
                    format = (PixelFormatGl)ImgTextureCompressionPvrtc.CompressedRgbaPvrtc2Bppv1Img;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_4bpp_RGB_SRgb:
                    internalFormat = (PixelInternalFormat)ExtPvrtcSrgb.CompressedSrgbPvrtc4Bppv1Ext;
                    format = (PixelFormatGl)ExtPvrtcSrgb.CompressedSrgbPvrtc4Bppv1Ext;
                    compressed = true;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_2bpp_RGB_SRgb:
                    internalFormat = (PixelInternalFormat)ExtPvrtcSrgb.CompressedSrgbPvrtc2Bppv1Ext;
                    format = (PixelFormatGl)ExtPvrtcSrgb.CompressedSrgbPvrtc2Bppv1Ext;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_4bpp_RGBA_SRgb:
                    internalFormat = (PixelInternalFormat)ExtPvrtcSrgb.CompressedSrgbAlphaPvrtc4Bppv1Ext;
                    format = (PixelFormatGl)ExtPvrtcSrgb.CompressedSrgbAlphaPvrtc4Bppv1Ext;
                    compressed = true;
                    pixelSize = 4;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.PVRTC_2bpp_RGBA_SRgb:
                    internalFormat = (PixelInternalFormat)ExtPvrtcSrgb.CompressedSrgbAlphaPvrtc2Bppv1Ext;
                    format = (PixelFormatGl)ExtPvrtcSrgb.CompressedSrgbAlphaPvrtc2Bppv1Ext;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
#elif XENKO_GRAPHICS_API_OPENGLES
                // Desktop OpenGLES
                case PixelFormat.ETC1:
                    // TODO: Runtime check for extension?
                    internalFormat = (PixelInternalFormat)OesCompressedEtc1Rgb8Texture.Etc1Rgb8Oes;
                    format = (PixelFormatGl)OesCompressedEtc1Rgb8Texture.Etc1Rgb8Oes;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.ETC2_RGBA:
                    internalFormat = (PixelInternalFormat)CompressedInternalFormat.CompressedRgba8Etc2Eac;
                    format = (PixelFormatGl)CompressedInternalFormat.CompressedRgba8Etc2Eac;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.ETC2_RGBA_SRgb:
                    internalFormat = (PixelInternalFormat)CompressedInternalFormat.CompressedSrgb8Alpha8Etc2Eac;
                    format = (PixelFormatGl)CompressedInternalFormat.CompressedSrgb8Alpha8Etc2Eac;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.ASTC_RGBA_4X4:
                    internalFormat = (PixelInternalFormat)All.CompressedRgbaAstc4X4Khr;
                    format = (PixelFormatGl)All.CompressedRgbaAstc4X4Khr;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
                case PixelFormat.ASTC_RGBA_4X4_SRgb:
                    internalFormat = (PixelInternalFormat)All.CompressedSrgb8Alpha8Astc4X4Khr;
                    format = (PixelFormatGl)All.CompressedSrgb8Alpha8Astc4X4Khr;
                    compressed = true;
                    pixelSize = 2;
                    type = PixelType.UnsignedByte;
                    break;
#endif
                case PixelFormat.None: // TODO: remove this - this is only for buffers used in compute shaders
                    internalFormat = PixelInternalFormat.Rgba;
                    format = PixelFormatGl.Red;
                    type = PixelType.UnsignedByte;
                    pixelSize = 1;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported texture format: " + inputFormat);
            }

#if XENKO_GRAPHICS_API_OPENGLES
            // override some formats for ES2.0
            if (graphicsDevice.currentVersion < 300)
            {
                switch (inputFormat)
                {
                    case PixelFormat.R8G8B8A8_UNorm_SRgb:
                        // HasSRgb was true because we have GL_EXT_sRGB
                        // Note: Qualcomm Adreno 4xx fails to use GL_EXT_sRGB with FBO,
                        // but they will report a currentVersion >= 300 (ES 3.0) anyway
                        internalFormat = (PixelInternalFormat)ExtSrgb.SrgbAlphaExt;
                        format = (PixelFormatGl)ExtSrgb.SrgbAlphaExt;
                        break;
                    case PixelFormat.R8_UNorm:
                    case PixelFormat.R8_SNorm:
                    case PixelFormat.R8_UInt:
                    case PixelFormat.R8_SInt:
                    case PixelFormat.R16_Float:
                    case PixelFormat.R16_UNorm:
                    case PixelFormat.R16_SNorm:
                    case PixelFormat.R16_UInt:
                    case PixelFormat.R16_SInt:
                    case PixelFormat.R32_Float:
                    case PixelFormat.R32_UInt:
                    case PixelFormat.R32_SInt:
                        if (inputFormat == PixelFormat.R16_Float)
                            type = (PixelType)OesTextureHalfFloat.HalfFloatOes;
                        if (graphicsDevice.HasTextureRG)
                            internalFormat = (PixelInternalFormat)ExtTextureRg.RedExt;
                        break;
                    case PixelFormat.R16G16_Float:
                    case PixelFormat.R16G16_UNorm:
                    case PixelFormat.R16G16_SNorm:
                    case PixelFormat.R16G16_UInt:
                    case PixelFormat.R16G16_SInt:
                    case PixelFormat.R32G32_Float:
                    case PixelFormat.R32G32_UInt:
                    case PixelFormat.R32G32_SInt:
                        if (inputFormat == PixelFormat.R16G16_Float)
                            type = (PixelType)OesTextureHalfFloat.HalfFloatOes;
                        if (graphicsDevice.HasTextureRG)
                            internalFormat = (PixelInternalFormat)ExtTextureRg.RgExt;
                        break;
                    case PixelFormat.R32G32B32_Float:
                    case PixelFormat.R32G32B32_UInt:
                    case PixelFormat.R32G32B32_SInt:
                        internalFormat = PixelInternalFormat.Rgb;
                        break;
                    case PixelFormat.R16G16B16A16_Float:
                    case PixelFormat.R32G32B32A32_Float:
                    case PixelFormat.R16G16B16A16_UInt:
                    case PixelFormat.R32G32B32A32_UInt:
                    case PixelFormat.R16G16B16A16_SInt:
                    case PixelFormat.R32G32B32A32_SInt:
                        if (inputFormat == PixelFormat.R16G16B16A16_Float)
                            type = (PixelType)OesTextureHalfFloat.HalfFloatOes;
                        internalFormat = PixelInternalFormat.Rgba;
                        break;
                }
            }
#endif
        }
    }
}
 
#endif
