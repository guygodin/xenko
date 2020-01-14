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

            var borderColor = border.RenderOpacity * border.BorderColorInternal;
            // optimization: don't draw the border if transparent
            if (borderColor == new Color())
                return;

            if (border.BorderThickness.Front != 0f || border.BorderThickness.Back != 0f)
            {
                Render3DBorder(border, ref borderColor, context);
            }
            else
            {
                Render2DBorder(border, ref borderColor, context);
            }
        }

        private void Render3DBorder(Border border, ref Color borderColor, UIRenderingContext context)
        {
            var borderThickness = border.BorderThickness;
            var elementHalfBorders = borderThickness / 2;
            var elementSize = border.RenderSizeInternal;
            var elementHalfSize = elementSize / 2;

            Vector3 offsets;
            Vector3 borderSize;

            // left/front
            offsets = new Vector3(-elementHalfSize.X + elementHalfBorders.Left, 0, -elementHalfSize.Z + elementHalfBorders.Front);
            borderSize = new Vector3(borderThickness.Left, elementSize.Y, borderThickness.Front);
            DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

            // right/front
            offsets = new Vector3(elementHalfSize.X - elementHalfBorders.Right, 0, -elementHalfSize.Z + elementHalfBorders.Front);
            borderSize = new Vector3(borderThickness.Right, elementSize.Y, borderThickness.Front);
            DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

            // top/front
            offsets = new Vector3(0, -elementHalfSize.Y + elementHalfBorders.Top, -elementHalfSize.Z + elementHalfBorders.Front);
            borderSize = new Vector3(elementSize.X, borderThickness.Top, borderThickness.Front);
            DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

            // bottom/front
            offsets = new Vector3(0, elementHalfSize.Y - elementHalfBorders.Bottom, -elementHalfSize.Z + elementHalfBorders.Front);
            borderSize = new Vector3(elementSize.X, borderThickness.Bottom, borderThickness.Front);
            DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

            // if the element is 3D draw the extra borders
            if (border.ActualDepth > MathUtil.ZeroTolerance)
            {
                // left/back
                offsets = new Vector3(-elementHalfSize.X + elementHalfBorders.Left, 0, elementHalfSize.Z - elementHalfBorders.Back);
                borderSize = new Vector3(borderThickness.Left, elementSize.Y, borderThickness.Back);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // right/back
                offsets = new Vector3(elementHalfSize.X - elementHalfBorders.Right, 0, elementHalfSize.Z - elementHalfBorders.Back);
                borderSize = new Vector3(borderThickness.Right, elementSize.Y, borderThickness.Back);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // top/back
                offsets = new Vector3(0, -elementHalfSize.Y + elementHalfBorders.Top, elementHalfSize.Z - elementHalfBorders.Back);
                borderSize = new Vector3(elementSize.X, borderThickness.Top, borderThickness.Back);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // bottom/back
                offsets = new Vector3(0, elementHalfSize.Y - elementHalfBorders.Bottom, elementHalfSize.Z - elementHalfBorders.Back);
                borderSize = new Vector3(elementSize.X, borderThickness.Bottom, borderThickness.Back);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // left/top
                offsets = new Vector3(-elementHalfSize.X + elementHalfBorders.Left, -elementHalfSize.Y + elementHalfBorders.Top, 0);
                borderSize = new Vector3(borderThickness.Left, borderThickness.Top, elementSize.Z);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // right/top
                offsets = new Vector3(elementHalfSize.X - elementHalfBorders.Right, -elementHalfSize.Y + elementHalfBorders.Top, 0);
                borderSize = new Vector3(borderThickness.Right, borderThickness.Top, elementSize.Z);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // left/bottom
                offsets = new Vector3(-elementHalfSize.X + elementHalfBorders.Left, elementHalfSize.Y - elementHalfBorders.Bottom, 0);
                borderSize = new Vector3(borderThickness.Left, borderThickness.Bottom, elementSize.Z);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);

                // right/bottom
                offsets = new Vector3(elementHalfSize.X - elementHalfBorders.Right, elementHalfSize.Y - elementHalfBorders.Bottom, 0);
                borderSize = new Vector3(borderThickness.Right, borderThickness.Bottom, elementSize.Z);
                DrawBorder(border, ref offsets, ref borderSize, ref borderColor, context);
            }
        }

        private void DrawBorder(Border border, ref Vector3 offsets, ref Vector3 borderSize, ref Color borderColor, UIRenderingContext context)
        {
            var worldMatrix = border.WorldMatrixInternal;
            worldMatrix.M41 += worldMatrix.M11 * offsets.X + worldMatrix.M21 * offsets.Y + worldMatrix.M31 * offsets.Z;
            worldMatrix.M42 += worldMatrix.M12 * offsets.X + worldMatrix.M22 * offsets.Y + worldMatrix.M32 * offsets.Z;
            worldMatrix.M43 += worldMatrix.M13 * offsets.X + worldMatrix.M23 * offsets.Y + worldMatrix.M33 * offsets.Z;
            Batch.DrawCube(ref worldMatrix, ref borderSize, ref borderColor, context.DepthBias);
        }

        private void Render2DBorder(Border border, ref Color borderColor, UIRenderingContext context)
        {
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
