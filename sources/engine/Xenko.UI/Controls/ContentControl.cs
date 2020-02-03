// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using Xenko.Core;
using Xenko.Core.Mathematics;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// Represents a control with a single piece of content of any type.
    /// </summary>
    [DataContract(nameof(ContentControl))]
    [DebuggerDisplay("ContentControl - Name={Name}")]
    public abstract class ContentControl : Control
    {
        private UIElement content;

        private UIElement visualContent;

        /// <summary>
        /// The key to the ContentArrangeMatrix dependency property.
        /// </summary>
        protected static readonly PropertyKey<Matrix> ContentArrangeMatrixPropertyKey = DependencyPropertyFactory.RegisterAttached(nameof(ContentArrangeMatrixPropertyKey), typeof(ContentControl), Matrix.Identity);

        private Matrix contentWorldMatrix;

        /// <summary>
        /// Gets or sets the content of the ContentControl.
        /// </summary>
        /// <exception cref="InvalidOperationException">The value passed has already a parent.</exception>
        /// <userdoc>The content of the Content Control.</userdoc>
        [DataMember]
        [DefaultValue(null)]
        public virtual UIElement Content
        {
            get { return content; }
            set
            {
                if (content == value)
                    return;

                if (content != null)
                    SetParent(content, null);

                content = value;
                VisualContent = content;

                if (content != null)
                    SetParent(content, this);

                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets the visual content of the ContentControl.
        /// </summary>
        [DataMemberIgnore]
        public UIElement VisualContent
        {
            get { return visualContent; }
            protected set
            {
                if (VisualContent != null)
                    SetVisualParent(VisualContent, null);

                visualContent = value;

                if (VisualContent != null)
                    SetVisualParent(visualContent, this);

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
            if (VisualContent != null)
            {
                // remove space for padding in availableSizeWithoutMargins
                var childAvailableSizeWithoutPadding = CalculateSizeWithoutThickness(ref availableSizeWithoutMargins, ref padding);

                VisualContent.Measure(ref childAvailableSizeWithoutPadding);
                childDesiredSizeWithMargins = VisualContent.DesiredSizeWithMargins;
            }

            // add the padding to the child desired size
            var desiredSizeWithPadding = CalculateSizeWithThickness(ref childDesiredSizeWithMargins, ref padding);

            return desiredSizeWithPadding;
        }

        protected override Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            // arrange the content
            if (VisualContent != null)
            {
                var actualPadding = padding;

                // adjust padding if child larger than element size without padding
                var spaceAroundChild = finalSizeWithoutMargins - VisualContent.DesiredSizeWithMargins;
                if (spaceAroundChild.X <= 0)
                {
                    actualPadding.Left = 0;
                    actualPadding.Right = 0;
                }
                else if (spaceAroundChild.X < padding.TotalWidth)
                {
                    var ratio = spaceAroundChild.X / padding.TotalWidth;
                    actualPadding.Left *= ratio;
                    actualPadding.Right *= ratio;
                }
                if (spaceAroundChild.Y <= 0)
                {
                    actualPadding.Top = 0;
                    actualPadding.Bottom = 0;
                }
                else if (spaceAroundChild.Y < padding.TotalHeight)
                {
                    var ratio = spaceAroundChild.Y / padding.TotalHeight;
                    actualPadding.Top *= ratio;
                    actualPadding.Bottom *= ratio;
                }

                // calculate the remaining space for the child after having removed the padding space.
                var childSizeWithoutPadding = CalculateSizeWithoutThickness(ref finalSizeWithoutMargins, ref actualPadding);

                // arrange the child
                VisualContent.Arrange(ref childSizeWithoutPadding, IsCollapsed);

                // compute the rendering offsets of the child element wrt the parent origin (0,0,0)
                var childOffsets = new Vector2(actualPadding.Left, actualPadding.Top) - finalSizeWithoutMargins / 2;

                // set the arrange matrix of the child.
                VisualContent.DependencyProperties.Set(ContentArrangeMatrixPropertyKey, Matrix.Translation(childOffsets));
            }

            return finalSizeWithoutMargins;
        }

        protected override void UpdateWorldMatrix(ref Matrix parentWorldMatrix, bool parentWorldChanged)
        {
            var contentMatrixChanged = parentWorldChanged || ArrangeChanged || LocalMatrixChanged;

            base.UpdateWorldMatrix(ref parentWorldMatrix, parentWorldChanged);

            if (VisualContent != null)
            {
                if (contentMatrixChanged)
                {
                    var contentMatrix = VisualContent.DependencyProperties.Get(ContentArrangeMatrixPropertyKey);
                    Matrix.Multiply(ref contentMatrix, ref WorldMatrixInternal, out contentWorldMatrix);
                }

                ((IUIElementUpdate)VisualContent).UpdateWorldMatrix(ref contentWorldMatrix, contentMatrixChanged);
            }
        }
    }
}
