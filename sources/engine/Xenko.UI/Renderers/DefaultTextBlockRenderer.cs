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

            if (textBlock.Font == null)
                return;

            var text = textBlock.TextToDisplay;
            if (string.IsNullOrEmpty(text))
                return;
            
            var drawCommand = new SpriteFont.InternalUIDrawCommand
            {
                Color = textBlock.RenderOpacity * (textBlock.IsEnabled ? textBlock.TextColor : Color.FromBgra(0xFF555555)),
                DepthBias = context.DepthBias,
                RealVirtualResolutionRatio = element.LayoutingContext.RealVirtualResolutionRatio,
                RequestedFontSize = textBlock.ActualTextSize,
                Batch = Batch,
                SnapText = context.ShouldSnapText && !textBlock.DoNotSnapText,
                Matrix = textBlock.WorldMatrixInternal,
                Alignment = textBlock.TextAlignment,
                TextBoxSize = new Vector2(textBlock.ActualWidth, textBlock.ActualHeight)
            };

            if (textBlock.Font.FontType == SpriteFontType.SDF)
            {
                Batch.End();
                Batch.BeginCustom(context.GraphicsContext, 1);
                Batch.DrawString(textBlock.Font, text, ref drawCommand);
                Batch.End();
                Batch.BeginCustom(context.GraphicsContext, 0);
            }
            else
            {
                Batch.DrawString(textBlock.Font, text, ref drawCommand);
            }
        }
    }
}
