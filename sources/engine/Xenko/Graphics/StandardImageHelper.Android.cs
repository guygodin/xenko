// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
#if XENKO_PLATFORM_ANDROID
using System;
using System.IO;
using System.Runtime.InteropServices;
using Xenko.Core;
using Android.Graphics;

namespace Xenko.Graphics
{
    /// <summary>
    /// This class is responsible to provide image loader for png, gif, bmp.
    /// </summary>
    partial class StandardImageHelper
    {
        private static readonly BitmapFactory.Options _options = new BitmapFactory.Options { InPreferredConfig = Bitmap.Config.Argb8888 };

        public static unsafe Image LoadFromMemory(IntPtr pSource, int size, bool makeACopy, GCHandle? handle)
        {
            // GG: Workaround for weird bug in .NET 9
            var data = new byte[size];
            Marshal.Copy(pSource, data, 0, size);

            var bitmap = BitmapFactory.DecodeByteArray(data, 0, size, _options);

            // fix the format of the bitmap if not supported
            if (bitmap.GetConfig() != Bitmap.Config.Argb8888)
            {
                var temp = bitmap.Copy(Bitmap.Config.Argb8888, false);
                bitmap.Dispose();
                bitmap = temp;
            }
                
            var bitmapData = bitmap.LockPixels();
                
            var image = Image.New2D(bitmap.Width, bitmap.Height, 1, PixelFormat.B8G8R8A8_UNorm, 1, bitmap.RowBytes);

            // Directly load image as RGBA instead of BGRA, because OpenGL ES devices don't support it out of the box (extension).
            image.Description.Format = PixelFormat.R8G8B8A8_UNorm;
            CopyMemoryBGRA(image.PixelBuffer[0].DataPointer, bitmapData, image.PixelBuffer[0].BufferStride);
            bitmap.UnlockPixels();
            bitmap.Dispose();

            if (handle != null)
                handle.Value.Free();
            else if (!makeACopy)
                Utilities.FreeMemory(pSource);

            return image;
        }

        public static void SaveGifFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        public static void SaveTiffFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        public static void SaveBmpFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        public static void SaveJpgFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream)
        {
            SaveFromMemory(pixelBuffers, count, description, imageStream, Bitmap.CompressFormat.Jpeg);
        }

        public static void SavePngFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream)
        {
            SaveFromMemory(pixelBuffers, count, description, imageStream, Bitmap.CompressFormat.Png);
        }

        public static void SaveWmpFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        private static void SaveFromMemory(PixelBuffer[] pixelBuffers, int count, ImageDescription description, Stream imageStream, Bitmap.CompressFormat imageFormat)
        {
            var colors = pixelBuffers[0].GetPixels<int>();

            using (var bitmap = Bitmap.CreateBitmap(description.Width, description.Height, Bitmap.Config.Argb8888))
            {
                var pixelData = bitmap.LockPixels();
                var sizeToCopy = colors.Length * sizeof(int);

                unsafe
                {
                    fixed (int* pSrc = colors)
                    {
                        // Copy the memory
                        if (description.Format == PixelFormat.R8G8B8A8_UNorm || description.Format == PixelFormat.R8G8B8A8_UNorm_SRgb)
                        {
                            CopyMemoryBGRA(pixelData, (IntPtr)pSrc, sizeToCopy);
                        }
                        else if (description.Format == PixelFormat.B8G8R8A8_UNorm || description.Format == PixelFormat.B8G8R8A8_UNorm_SRgb)
                        {
                            Utilities.CopyMemory(pixelData, (IntPtr)pSrc, sizeToCopy);
                        }
                        else if (description.Format == PixelFormat.R32_Float)
                        {
                            CopyMemoryR32(pixelData, (IntPtr)pSrc, sizeToCopy);
                        }
                        else if (description.Format == PixelFormat.R8_UNorm)
                        {
                            CopyMemoryRRR1(pixelData, (IntPtr)pSrc, sizeToCopy);
                        }
                        else
                        {
                            throw new NotSupportedException(string.Format("Pixel format [{0}] is not supported", description.Format));
                        }
                    }
                }

                bitmap.UnlockPixels();
                bitmap.Compress(imageFormat, 100, imageStream);
            }
        }
    }
}
#endif
