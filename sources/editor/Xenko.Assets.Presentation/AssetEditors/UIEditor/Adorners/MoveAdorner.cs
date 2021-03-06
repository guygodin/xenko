// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Windows.Forms;
using Xenko.Core.Mathematics;
using Xenko.Assets.Presentation.AssetEditors.UIEditor.Game;
using Xenko.Assets.Presentation.ViewModel;
using Xenko.UI;
using Xenko.UI.Controls;

namespace Xenko.Assets.Presentation.AssetEditors.UIEditor.Adorners
{
    /// <summary>
    /// Represents an adorner that can move the associated  <see cref="UIElement"/>.
    /// </summary>
    internal sealed class MoveAdorner : BorderAdorner, IResizingAdorner
    {
        public MoveAdorner(UIEditorGameAdornerService service, UIElement gameSideElement)
            : base(service, gameSideElement)
        {
            Visual.Name = "[Move]";
            Visual.CanBeHitByUser = true;
        }

        public ResizingDirection ResizingDirection => ResizingDirection.Center;

        public Cursor GetCursor() => CannotMove() ? Cursors.No : Cursors.SizeAll;

        public override void Update(Vector2 position)
        {
            UpdateFromSettings();
            Size = (Vector2)GameSideElement.RenderSize;
        }

        protected override void UpdateSize()
        {
            base.UpdateSize();
            Visual.Margin = new Thickness(-BorderThickness);
        }

        private bool CannotMove()
        {
            // If the parent of the associated element is a ContentControl, then moving is disabled
            return GameSideElement.VisualParent is ContentControl;
        }

        private void UpdateFromSettings()
        {
            var editor = Service.Controller.Editor;

            BackgroundColor = editor.SelectionColor*0.2f;
            BorderColor = editor.SelectionColor;
            BorderThickness = editor.SelectionThickness;
        }

        void IResizingAdorner.OnResizingDelta(float horizontalChange, float verticalChange)
        {
            // Nothing to do
        }

        void IResizingAdorner.OnResizingCompleted()
        {
            // Nothing to do
        }
    }
}
