// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.


using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.UI.Controls;

namespace Xenko.UI.Renderers
{
    /// <summary>
    /// The default renderer for <see cref="Border"/>.
    /// </summary>
    public class DefaultBorderRenderer : ElementRenderer
    {
        public DefaultBorderRenderer(IServiceRegistry services)
            : base(services)
        {
        }

        public override void RenderColor(UIElement element, UIRenderingContext context)
        {
            base.RenderColor(element, context);

            var border = (Border)element;

            var borderColor = border.BorderColorInternal;
            if (border.RenderOpacity != 1f)
                borderColor *= border.RenderOpacity;
            // optimization: don't draw the border if transparent
            if (borderColor.A == 0)
                return;

            var borderThickness = border.BorderThickness;
            var elementHalfBorders = borderThickness / 2;
            var elementSize = border.RenderSizeInternal;
            var elementHalfSize = elementSize / 2;

            Vector3 borderSize;

            // left
            borderSize = new Vector3(borderThickness.Left, elementSize.Y, 0f);
            DrawRectangle(border, -elementHalfSize.X + elementHalfBorders.Left, 0f, ref borderSize, ref borderColor, context);

            // right
            borderSize = new Vector3(borderThickness.Right, elementSize.Y, 0f);
            DrawRectangle(border, elementHalfSize.X - elementHalfBorders.Right, 0f, ref borderSize, ref borderColor, context);

            // top
            borderSize = new Vector3(elementSize.X, borderThickness.Top, 0f);
            DrawRectangle(border, 0f, -elementHalfSize.Y + elementHalfBorders.Top, ref borderSize, ref borderColor, context);

            // bottom
            borderSize = new Vector3(elementSize.X, borderThickness.Bottom, 0f);
            DrawRectangle(border, 0f, elementHalfSize.Y - elementHalfBorders.Bottom, ref borderSize, ref borderColor, context);
        }

        private void DrawRectangle(Border border, float offsetX, float offsetY, ref Vector3 borderSize, ref Color borderColor, UIRenderingContext context)
        {
            var worldMatrix = border.WorldMatrixInternal;
            worldMatrix.M41 += worldMatrix.M11 * offsetX + worldMatrix.M21 * offsetY;
            worldMatrix.M42 += worldMatrix.M12 * offsetX + worldMatrix.M22 * offsetY;
            worldMatrix.M43 += worldMatrix.M13 * offsetX + worldMatrix.M23 * offsetY;
            Batch.DrawRectangle(ref worldMatrix, ref borderSize, ref borderColor, context.DepthBias);
        }
    }
}
