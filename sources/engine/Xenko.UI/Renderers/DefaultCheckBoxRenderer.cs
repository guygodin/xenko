// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;

using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Graphics;
using Xenko.UI.Controls;

namespace Xenko.UI.Renderers
{
    /// <summary>
    /// The default renderer for <see cref="CheckBox"/>.
    /// </summary>
    internal class DefaultCheckBoxRenderer : ElementRenderer
    {
        public DefaultCheckBoxRenderer(IServiceRegistry services)
            : base(services)
        {
        }

        public override void RenderColor(UIElement element, UIRenderingContext context)
        {
            base.RenderColor(element, context);

            var checkBox = (CheckBox)element;
            var sprite = GetToggleStateImage(checkBox);
            var texture = sprite?.Texture;
            if (texture == null)
                return;

            var color = checkBox.RenderOpacity * Color.White;
            var size = new Vector3(sprite.SizeInPixels, 0f);
            var translation = Matrix.Translation(-element.RenderSize.X / 2 + size.X / 2, 0f, 0f);
            Matrix.Multiply(ref element.WorldMatrixInternal, ref translation, out Matrix matrix);
            Batch.DrawImage(texture, ref matrix, ref sprite.RegionInternal, ref size, ref sprite.BordersInternal, ref color, context.DepthBias, sprite.Orientation);
        }

        private static Sprite GetToggleStateImage(CheckBox checkBox)
        {
            switch (checkBox.State)
            {
                case ToggleState.Checked:
                    if (checkBox.IsPressed)
                    {
                        return checkBox.CheckedMouseDownImage?.GetSprite();
                    }
                    if (checkBox.MouseOverState != MouseOverState.MouseOverNone)
                    {
                        return checkBox.CheckedMouseOverImage?.GetSprite();
                    }
                    return checkBox.CheckedImage?.GetSprite();
                case ToggleState.Indeterminate:
                    if (checkBox.IsPressed)
                    {
                        return checkBox.IndeterminateMouseDownImage?.GetSprite();
                    }
                    if (checkBox.MouseOverState != MouseOverState.MouseOverNone)
                    {
                        return checkBox.IndeterminateMouseOverImage?.GetSprite();
                    }
                    return checkBox.IndeterminateImage?.GetSprite();
                case ToggleState.UnChecked:
                    if (checkBox.IsPressed)
                    {
                        return checkBox.UncheckedMouseDownImage?.GetSprite();
                    }
                    if (checkBox.MouseOverState != MouseOverState.MouseOverNone)
                    {
                        return checkBox.UncheckedMouseOverImage?.GetSprite();
                    }
                    return checkBox.UncheckedImage?.GetSprite();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
