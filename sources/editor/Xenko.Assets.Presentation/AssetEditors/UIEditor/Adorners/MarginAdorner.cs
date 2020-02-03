// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Globalization;
using Xenko.Core.Mathematics;
using Xenko.Assets.Presentation.AssetEditors.UIEditor.Game;
using Xenko.UI;
using Xenko.UI.Controls;
using Xenko.UI.Panels;

namespace Xenko.Assets.Presentation.AssetEditors.UIEditor.Adorners
{
    internal enum MarginEdge
    {
        Left,
        Top,
        Right,
        Bottom,
    }

    internal sealed class MarginAdorner : AdornerBase<Canvas>
    {
        private readonly Border border;
        private readonly TextBlock textBlock;
        private float thickness;

        public MarginAdorner(UIEditorGameAdornerService service, UIElement gameSideElement, MarginEdge marginEdge, Graphics.SpriteFont font)
            : base(service, gameSideElement)
        {
            Visual = new Canvas
            {
                CanBeHitByUser = false,
                Name = $"[Margin] {marginEdge}",
            };
            border = new Border();
            textBlock = new TextBlock
            {
                BackgroundColor = Color.WhiteSmoke*0.5f,
                Font = font,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Visual.Children.Add(border);
            Visual.Children.Add(textBlock);

            MarginEdge = marginEdge;

            InitializeAttachedProperties();
        }

        public MarginEdge MarginEdge { get; }

        public override Canvas Visual { get; }

        public override void Disable()
        {
            // do nothing (margin adorners are not hitable)
        }

        public override void Enable()
        {
            // do nothing (margin adorners are not hitable)
        }

        public override void Update(Vector2 position)
        {
            UpdateFromSettings();

            var margin = GameSideElement.Margin;
            var offset = GameSideElement.RenderSize*0.5f;

            Vector2 pinOrigin;
            Vector2 size;
            Vector2 textRelativePosition;
            float value;
            switch (MarginEdge)
            {
                case MarginEdge.Left:
                    size = new Vector2(Math.Abs(margin.Left), thickness);
                    value = margin.Left;
                    pinOrigin = new Vector2(margin.Left >= 0 ? 1.0f : 0.0f, 0.5f);
                    position += new Vector2(-offset.X, 0.0f);
                    textRelativePosition = new Vector2(margin.Left < 0 ? 1.0f : 0.0f, 0.5f);
                    break;

                case MarginEdge.Right:
                    size = new Vector2(Math.Abs(margin.Right), thickness);
                    value = margin.Right;
                    pinOrigin = new Vector2(margin.Right <= 0 ? 1.0f : 0.0f, 0.0f);
                    position += new Vector2(offset.X, 0.0f);
                    textRelativePosition = new Vector2(margin.Right > 0 ? 1.0f : 0.0f, 0.5f);
                    break;

                case MarginEdge.Top:
                    size = new Vector2(thickness, Math.Abs(margin.Top));
                    value = margin.Top;
                    pinOrigin = new Vector2(0.5f, margin.Top >= 0 ? 1.0f : 0.0f);
                    position += new Vector2(0.0f, -offset.Y);
                    textRelativePosition = new Vector2(0.5f, margin.Top < 0 ? 1.0f : 0.0f);
                    break;

                case MarginEdge.Bottom:
                    size = new Vector2(thickness, Math.Abs(margin.Bottom));
                    value = margin.Bottom;
                    pinOrigin = new Vector2(0.5f, margin.Bottom <= 0 ? 1.0f : 0.0f);
                    position += new Vector2(0.0f, offset.Y);
                    textRelativePosition = new Vector2(0.5f, margin.Bottom > 0 ? 1.0f : 0.0f);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            border.Size = size;

            textBlock.Text = value.ToString("0.###", CultureInfo.CurrentUICulture);
            textBlock.Visibility = Math.Abs(value) > 1.0f ? Visibility.Visible : Visibility.Hidden;
            textBlock.SetCanvasPinOrigin(pinOrigin);
            textBlock.SetCanvasRelativePosition(textRelativePosition);

            Visual.Size = size;
            Visual.SetCanvasAbsolutePosition(position);
            Visual.SetCanvasPinOrigin(pinOrigin);
        }

        private void UpdateFromSettings()
        {
            var editor = Service.Controller.Editor;

            thickness = editor.GuidelineThickness;
            border.BackgroundColor = editor.GuidelineColor;
            textBlock.TextColor = editor.GuidelineColor;
        }
    }
}
