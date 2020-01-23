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
using Xenko.Rendering.Sprites;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// Represents a control that displays an image.
    /// </summary>
    [DataContract(nameof(AnimatedImageElement))]
    [DebuggerDisplay("AnimatedImageElement - Name={Name}")]
    public class AnimatedImageElement : UIElement
    {
        private SpriteFromSheet source;
        private Sprite sprite;
        private Vector3 desiredSize;
        private int frames;
        private long frameTicks;
        private bool visible;
        private long startTicks;

        public event EventHandler SpriteChanged;

        /// <summary>
        /// Gets or sets the <see cref="ISpriteProvider"/> for the image.
        /// </summary>
        /// <userdoc>The provider for the image.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider Source
        {
            get { return source; }
            set
            {
                if (source == value)
                    return;

                source = value as SpriteFromSheet;
                sprite = source?.GetSprite();

                if (sprite != null)
                {
                    desiredSize = new Vector3(sprite.SizeInPixels, 0f);
                    frames = source.SpritesCount;
                    frameTicks = TimeSpan.FromSeconds(1.0 / frames).Ticks;
                }
                else
                {
                    desiredSize = Vector3.Zero;
                    frames = 0;
                }
                InvalidateMeasure();
            }
        }

        protected override Vector3 ArrangeOverride(Vector3 finalSizeWithoutMargins)
        {
            return desiredSize;
        }

        protected override Vector3 MeasureOverride(Vector3 availableSizeWithoutMargins)
        {
            return desiredSize;
        }

        protected override void Update(GameTime time)
        {
            var isVisible = IsVisible && frames >= 2;
            if (isVisible != visible)
            {
                visible = isVisible;
                if (visible)
                {
                    // start animation
                    SetCurrentFrame(0);
                    startTicks = time.Total.Ticks;
                }
            }
            else if (visible)
            {
                if ((time.Total.Ticks - startTicks) >= frameTicks)
                {
                    SetCurrentFrame((source.CurrentFrame + 1) % frames);
                    startTicks += frameTicks;
                }
            }
        }

        private void SetCurrentFrame(int index)
        {
            if (index != source.CurrentFrame)
            {
                source.CurrentFrame = index;
                sprite = source.GetSprite();
                IsDirty = true;
                SpriteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
