// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;

using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Engine;
using Xenko.Graphics;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// Represents a Windows button control, which reacts to the Click event.
    /// </summary>
    [DataContract(nameof(Button))]
    [DebuggerDisplay("Button - Name={Name}")]
    public class Button : ButtonBase
    {
        private StretchType imageStretchType = StretchType.Uniform;
        private StretchDirection imageStretchDirection = StretchDirection.Both;
        private ISpriteProvider pressedImage;
        private ISpriteProvider notPressedImage;
        private ISpriteProvider mouseOverImage;
        private bool sizeToContent = true;

        public Button()
        {
            DrawLayerNumber += 1; // (button design image)

            // this breaks the ability to set a Thickness(0) in GameStudio, since it will not deserialize a default Thickness(0), and hence Padding will stay at this value 
            Padding = new Thickness(10, 5, 10, 7);
        }

        /// <inheritdoc/>
        public override bool IsPressed
        {
            get { return base.IsPressed; }
            protected set
            {
                if (value == IsPressed)
                    return;

                base.IsPressed = value;
                InvalidateButtonImage();
            }
        }

        public override bool IsEnabled
        {
            get { return base.IsEnabled; }
            set
            {
                if (!value)
                {
                    IsPressed = false;
                }
                base.IsEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the button is pressed.
        /// </summary>
        /// <userdoc>Image displayed when the button is pressed.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider PressedImage
        {
            get { return pressedImage; }
            set
            {
                if (pressedImage == value)
                    return;

                pressedImage = value;
                OnAspectImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the button is not pressed.
        /// </summary>
        /// <userdoc>Image displayed when the button is not pressed.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider NotPressedImage
        {
            get { return notPressedImage; }
            set
            {
                if (notPressedImage == value)
                    return;

                notPressedImage = value;
                OnAspectImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the mouse hovers over the button.
        /// </summary>
        /// <userdoc>Image displayed when the mouse hovers over the button.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider MouseOverImage
        {
            get { return mouseOverImage; }
            set
            {
                if (mouseOverImage == value)
                    return;

                mouseOverImage = value;
                OnAspectImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets a value that describes how the button image should be stretched to fill the destination rectangle.
        /// </summary>
        /// <remarks>This property has no effect is <see cref="SizeToContent"/> is <c>true</c>.</remarks>
        /// <userdoc>Describes how the button image should be stretched to fill the destination rectangle.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(StretchType.Uniform)]
        public StretchType ImageStretchType
        {
            get { return imageStretchType; }
            set
            {
                imageStretchType = value;
                InvalidateButtonImage();
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates how the button image is scaled.
        /// </summary>
        /// <remarks>This property has no effect is <see cref="SizeToContent"/> is <c>true</c>.</remarks>
        /// <userdoc>Indicates how the button image is scaled.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(StretchDirection.Both)]
        public StretchDirection ImageStretchDirection
        {
            get { return imageStretchDirection; }
            set
            {
                imageStretchDirection = value;
                InvalidateButtonImage();
            }
        }

        /// <summary>
        /// Gets or sets whether the size depends on the Content. The default is <c>true</c>.
        /// </summary>
        /// <userdoc>True if this button's size depends of its content, false otherwise.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(true)]
        public bool SizeToContent
        {
            get { return sizeToContent; }
            set
            {
                if (sizeToContent == value)
                    return;

                sizeToContent = value;
                InvalidateMeasure();
            }
        }

        internal ISpriteProvider ButtonImageProvider
        {
            get
            {
                if (IsEnabled)
                {
                    if (IsPressed && PressedImage != null)
                        return PressedImage;
                    else if (MouseOverState == MouseOverState.MouseOverElement && MouseOverImage != null)
                        return MouseOverImage;
                }
                return NotPressedImage;
            }
        }

        internal Sprite ButtonImage
        {
            get { return ButtonImageProvider?.GetSprite(); }
        }

        protected override void OnMouseOverStateChanged(MouseOverState oldValue, MouseOverState newValue)
        {
            base.OnMouseOverStateChanged(oldValue, newValue);
            InvalidateButtonImage();

            if (IsEnabled && !IsPressed && (oldValue == MouseOverState.MouseOverElement || newValue == MouseOverState.MouseOverElement))
            {
                IsDirty = true;
            }
        }

        /// <inheritdoc/>
        protected override Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            return sizeToContent
                ? base.ArrangeOverride(ref finalSizeWithoutMargins)
                : ImageSizeHelper.CalculateImageSizeFromAvailable(ButtonImage, ref finalSizeWithoutMargins, ImageStretchType, ImageStretchDirection, false);
        }

        /// <inheritdoc/>
        protected override Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            return sizeToContent
                ? base.MeasureOverride(ref availableSizeWithoutMargins)
                : ImageSizeHelper.CalculateImageSizeFromAvailable(ButtonImage, ref availableSizeWithoutMargins, ImageStretchType, ImageStretchDirection, true);
        }

        /// <summary>
        /// Function triggered when one of the <see cref="PressedImage"/> and <see cref="NotPressedImage"/> images are invalidated.
        /// This function can be overridden in inherited classes.
        /// </summary>
        protected virtual void OnAspectImageInvalidated()
        {
            InvalidateButtonImage();
        }
        
        private void InvalidateButtonImage()
        {
            if (!sizeToContent)
                InvalidateMeasure();
        }
    }
}
