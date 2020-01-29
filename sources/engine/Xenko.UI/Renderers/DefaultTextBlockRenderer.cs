// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Graphics;
using Xenko.Graphics.Font;
using Xenko.UI.Controls;

namespace Xenko.UI.Renderers
{
    /// <summary>
    /// The default renderer for <see cref="TextBlock"/>.
    /// </summary>
    internal class DefaultTextBlockRenderer : ElementRenderer
    {
        public DefaultTextBlockRenderer(IServiceRegistry services)
            : base(services)
        {
        }

        public override void RenderColor(UIElement element, UIRenderingContext context)
        {
            base.RenderColor(element, context);

            var textBlock = (TextBlock)element;

            var font = textBlock.Font;
            if (font == null)
                return;

            var text = textBlock.TextToDisplay;
            if (string.IsNullOrEmpty(text))
                return;

            var color = textBlock.IsEnabled ? textBlock.TextColor : Color.FromBgra(0xFF555555);
            if (textBlock.RenderOpacity != 1f)
                color *= textBlock.RenderOpacity;
            // optimization: don't draw the text if transparent
            if (color.A == 0)
                return;
            
            var drawCommand = new SpriteFont.InternalUIDrawCommand
            {
                Color = color,
                DepthBias = context.DepthBias,
                RealVirtualResolutionRatio = element.LayoutingContext.RealVirtualResolutionRatio,
                RequestedFontSize = textBlock.ActualTextSize,
                Batch = Batch,
                SnapText = context.ShouldSnapText && !textBlock.DoNotSnapText,
                Matrix = textBlock.WorldMatrixInternal,
                Alignment = textBlock.TextAlignment,
                TextBoxSize = new Vector2(textBlock.ActualWidth, textBlock.ActualHeight)
            };

            if (font.FontType == SpriteFontType.SDF)
            {
                Batch.End();
                Batch.BeginCustom(context.GraphicsContext, 1);
                Batch.DrawString(font, text, ref drawCommand);
                Batch.End();
                Batch.BeginCustom(context.GraphicsContext, 0);
            }
            else
            {
                Batch.DrawString(font, text, ref drawCommand);
            }
        }
    }
}
