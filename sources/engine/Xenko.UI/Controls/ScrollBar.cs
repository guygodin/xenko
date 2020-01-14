// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// Represents a scroll bar. 
    /// </summary>
    [DataContract(nameof(ScrollBar))]
    [DebuggerDisplay("ScrollBar - Name={Name}")]
    public class ScrollBar : UIElement
    {
        internal Color BarColorInternal = Color.Transparent;
        internal bool RotateThumbImage;

        /// <summary>
        /// The color of the bar.
        /// </summary>
        /// <userdoc>The color of the bar.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        public Color BarColor
        {
            get { return BarColorInternal; }
            set { BarColorInternal = value; }
        }

        /// <summary>
        /// Gets or sets the image to display as slider thumb.
        /// </summary>
        /// <userdoc>The image to display as slider thumb.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider ThumbImage { get; set; }
    }
}
