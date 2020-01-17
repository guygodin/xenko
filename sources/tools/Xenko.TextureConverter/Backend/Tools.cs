// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;

using Xenko.Graphics;

namespace Xenko.TextureConverter
{
    /// <summary>
    /// Provides general methods used by the libraries.
    /// </summary>
    internal class Tools
    {
        /// <summary>
        /// Computes the pitch.
        /// </summary>
        /// <param name="fmt">The format.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rowPitch">output row pitch.</param>
        /// <param name="slicePitch">output slice pitch.</param>
        public static void ComputePitch(PixelFormat fmt, int width, int height, out int rowPitch, out int slicePitch)
        {
            var widthCount = width;
            var heightCount = height;

            if (fmt.IsCompressed())
            {
                int minWidth = 1;
                int minHeight = 1;
                int bpb = 8;

                switch (fmt)
                {
                    case PixelFormat.BC1_Typeless:
                    case PixelFormat.BC1_UNorm:
                    case PixelFormat.BC1_UNorm_SRgb:
                    case PixelFormat.BC4_Typeless:
                    case PixelFormat.BC4_UNorm:
                    case PixelFormat.BC4_SNorm:
                    case PixelFormat.ETC1:
                        bpb = 8;
                        break;
                    case PixelFormat.PVRTC_4bpp_RGB:
                    case PixelFormat.PVRTC_4bpp_RGB_SRgb:
                    case PixelFormat.PVRTC_4bpp_RGBA:
                    case PixelFormat.PVRTC_4bpp_RGBA_SRgb:
                    case PixelFormat.PVRTC_II_4bpp:
                        minWidth = 8;
                        minHeight = 8;
                        break;
                    case PixelFormat.PVRTC_2bpp_RGB:
                    case PixelFormat.PVRTC_2bpp_RGB_SRgb:
                    case PixelFormat.PVRTC_2bpp_RGBA:
                    case PixelFormat.PVRTC_2bpp_RGBA_SRgb:
                    case PixelFormat.PVRTC_II_2bpp:
                        minWidth = 16;
                        minHeight = 8;
                        bpb = 4;
                        break;
                    default:
                        bpb = 16;
                        break;
                }

                widthCount = Math.Max(1, (Math.Max(minWidth, width) + 3)) / 4;
                heightCount = Math.Max(1, (Math.Max(minHeight, height) + 3)) / 4;
                rowPitch = widthCount * bpb;

                slicePitch = rowPitch * heightCount;
            }
            else if (fmt.IsPacked())
            {
                rowPitch = ((width + 1) >> 1) * 4;

                slicePitch = rowPitch * height;
            }
            else
            {
                var bpp = fmt.SizeInBits();

                rowPitch = (width * bpp + 7) / 8;
                slicePitch = rowPitch * height;
            }
        }

        /// <summary>
        /// Determines whether two different formats are in same channel order.
        /// </summary>
        /// <param name="format1">The format1.</param>
        /// <param name="format2">The format2.</param>
        /// <returns>
        ///   <c>true</c> if the formats are in the same channel order; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInSameChannelOrder(PixelFormat format1, PixelFormat format2)
        {
            return format1.IsBGRAOrder() && format2.IsBGRAOrder() || format1.IsRGBAOrder() && format2.IsRGBAOrder();
        }
    }
}
