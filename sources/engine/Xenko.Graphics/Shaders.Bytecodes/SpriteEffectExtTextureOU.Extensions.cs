// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using Xenko.Shaders;

namespace Xenko.Graphics
{
    public partial class SpriteEffectExtTextureOU
    {
        private static EffectBytecode bytecode = null;

        public static EffectBytecode Bytecode
        {
            get
            {
#if XENKO_PLATFORM_ANDROID
                return bytecode ?? (bytecode = EffectBytecode.FromBytesSafe(binaryBytecode));
#else
                return bytecode;
#endif
            }
        }
    }
}
