// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xenko.Core;
using System.Diagnostics;
using Xenko.Core.Mathematics;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// A class aiming at presenting another <see cref="UIElement"/>.
    /// </summary>
    [DataContract(nameof(ContentPresenter))]
    [DebuggerDisplay("ContentPresenter - Name={Name}")]
    [Obsolete("This class has no effect and shouldn't be used. Consider one of the classes that inherit from ContentControl.")]
    public class ContentPresenter : UIElement
    {
        private Matrix contentWorldMatrix;
        private UIElement content;

        /// <summary>
        /// Gets or sets the content of the presenter.
        /// </summary>
        /// <userdoc>The content of the presenter.</userdoc>
        [DataMember]
        [DefaultValue(null)]
        public UIElement Content
        {
            get { return content; }
            set
            {
                if (content == value)
                    return;

                if (content != null)
                    SetVisualParent(content, null);

                content = value;

                if (content != null)
                    SetVisualParent(content, this);

                content = value;
                InvalidateMeasure();
            }
        }

        /// <inheritdoc/>
        protected override IEnumerable<IUIElementChildren> EnumerateChildren()
        {
            if (Content != null)
                yield return Content;
        }

        protected override Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            // measure size desired by the children
            var childDesiredSizeWithMargins = Vector2.Zero;
            if (Content != null)
            {
                Content.Measure(ref availableSizeWithoutMargins);
                childDesiredSizeWithMargins = Content.DesiredSizeWithMargins;
            }

            return childDesiredSizeWithMargins;
        }

        protected override Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            // arrange child elements
            Content?.Arrange(ref finalSizeWithoutMargins, IsCollapsed);

            return finalSizeWithoutMargins;
        }

        protected override void UpdateWorldMatrix(ref Matrix parentWorldMatrix, bool parentWorldChanged)
        {
            var contentWorldMatrixChanged = parentWorldChanged || ArrangeChanged || LocalMatrixChanged;

            base.UpdateWorldMatrix(ref parentWorldMatrix, parentWorldChanged);

            if (Content != null)
            {
                if (contentWorldMatrixChanged)
                {
                    contentWorldMatrix = WorldMatrixInternal;
                    var contentMatrix = Matrix.Translation(-RenderSize / 2);
                    Matrix.Multiply(ref contentMatrix, ref WorldMatrixInternal, out contentWorldMatrix);
                }

                ((IUIElementUpdate)Content).UpdateWorldMatrix(ref contentWorldMatrix, contentWorldMatrixChanged);
            }
        }
    }
}
