// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using SharpDX.DirectWrite;
using Xenko.Core.Assets.Compiler;
using Xenko.Core;

namespace Xenko.Assets.SpriteFont
{
    [DataContract("FontProviderBase")]
    public abstract class FontProviderBase
    {
        [DataMemberIgnore]
        public virtual Graphics.Font.FontStyle Style { get; set; } = Graphics.Font.FontStyle.Regular;

        /// <summary>
        /// Gets the associated <see cref="Font"/>
        /// </summary>
        /// <returns><see cref="Font"/> from the specified source or <c>null</c> if not found</returns>
        public abstract Font GetFont();

        /// <summary>
        /// Gets the associated <see cref="FontFace"/>
        /// </summary>
        /// <returns><see cref="FontFace"/> from the specified source or <c>null</c> if not found</returns>
        public abstract FontFace GetFontFace();

        /// <summary>
        /// Gets the fallback <see cref="FontFace"/>
        /// </summary>
        /// <returns>Fallback <see cref="FontFace"/> from the specified source or <c>null</c> if not found</returns>
        public abstract FontFace GetFallbackFontFace();

        /// <summary>
        /// Gets the actual file path to the font file
        /// </summary>
        /// <returns>Path to the font file</returns>
        public abstract string GetFontPath(AssetCompilerResult result = null);

        /// <summary>
        /// Gets the actual font name
        /// </summary>
        /// <returns>The name of the font</returns>
        public abstract string GetFontName();
    }
}
