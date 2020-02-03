// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Engine;
using Xenko.Games;
using Xenko.Graphics;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// Represents a control that displays an image.
    /// </summary>
    [DataContract(nameof(ImageElement))]
    [DebuggerDisplay("ImageElement - Name={Name}")]
    public class ImageElement : UIElement
    {
        private ISpriteProvider source;
        private Sprite sprite;
        private Color color = Color.White;
        private StretchType stretchType = StretchType.Uniform;
        private StretchDirection stretchDirection = StretchDirection.Both;

        /// <summary>
        /// Gets or sets the <see cref="ISpriteProvider"/> for the image.
        /// </summary>
        /// <userdoc>The provider for the image.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider Source
        {
            get { return source;}
            set
            {
                if (source == value)
                    return;

                source = value;
                OnSourceChanged();
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or set the color used to tint the image. Default value is White/>.
        /// </summary>
        /// <remarks>The initial image color is multiplied by this color.</remarks>
        /// <userdoc>The color used to tint the image. The default value is white.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        public Color Color
        {
            get { return color; }
            set
            {
                if (value == color)
                    return;
                color = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value that describes how the image should be stretched to fill the destination rectangle.
        /// </summary>
        /// <userdoc>Indicates how the image should be stretched to fill the destination rectangle.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(StretchType.Uniform)]
        public StretchType StretchType
        {
            get { return stretchType; }
            set
            {
                stretchType = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates how the image is scaled.
        /// </summary>
        /// <userdoc>Indicates how the image is scaled.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(StretchDirection.Both)]
        public StretchDirection StretchDirection
        {
            get { return stretchDirection; }
            set
            {
                stretchDirection = value;
                InvalidateMeasure();
            }
        }

        protected virtual void OnSourceChanged()
        {
            UpdateSprite();
        }

        protected override Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            return ImageSizeHelper.CalculateImageSizeFromAvailable(sprite, ref finalSizeWithoutMargins, StretchType, StretchDirection, false);
        }

        protected override Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            return ImageSizeHelper.CalculateImageSizeFromAvailable(sprite, ref availableSizeWithoutMargins, StretchType, StretchDirection, true);
        }

        protected override void Update(GameTime time)
        {
            UpdateSprite();
        }

        /*private void InvalidateMeasure(object sender, EventArgs eventArgs)
        {
            InvalidateMeasure();
        }*/

        private void UpdateSprite()
        {
            var currentSprite = source?.GetSprite();
            if (sprite == currentSprite)
                return;

            // this seems a little heavy-handed, especially since a sprite will never change size/border
            // also commented out for optimization for animated images which change CurrentFrame frequently
            /*if (sprite != null)
            {
                sprite.SizeChanged -= InvalidateMeasure;
                sprite.BorderChanged -= InvalidateMeasure;
            }*/

            bool sizeChanged = sprite == null || currentSprite == null || currentSprite.SizeInPixels != sprite.SizeInPixels;
            sprite = currentSprite;

            /*if (sprite != null)
            {
                sprite.SizeChanged += InvalidateMeasure;
                sprite.BorderChanged += InvalidateMeasure;
            }*/

            // no need to re-measure if sprite size the same as before
            if (sizeChanged)
            {
                InvalidateMeasure();
            }

            IsDirty = true;
        }
    }
}
