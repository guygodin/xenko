// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.ComponentModel;
using System.Diagnostics;

using Xenko.Core;
using Xenko.Core.Annotations;
using Xenko.Core.Mathematics;

namespace Xenko.UI.Panels
{
    /// <summary>
    /// Represents the grid where all the rows and columns have an uniform size.
    /// </summary>
    [DataContract(nameof(UniformGrid))]
    [DebuggerDisplay("UniformGrid - Name={Name}")]
    public class UniformGrid : GridBase
    {
        /// <summary>
        /// The final size of one cell
        /// </summary>
        private Vector2 finalForOneCell;

        private int rows = 1;
        private int columns = 1;

        /// <summary>
        /// Gets or sets the number of rows that the <see cref="UniformGrid"/> has.
        /// </summary>
        /// <remarks>The value is coerced in the range [1, <see cref="int.MaxValue"/>].</remarks>
        /// <userdoc>The number of rows.</userdoc>
        [DataMember]
        [DataMemberRange(1, 0)]
        [Display(category: LayoutCategory)]
        [DefaultValue(1)]
        public int Rows
        {
            get { return rows; }
            set
            {
                rows = MathUtil.Clamp(value, 1, int.MaxValue);
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the number of columns that the <see cref="UniformGrid"/> has.
        /// </summary>
        /// <remarks>The value is coerced in the range [1, <see cref="int.MaxValue"/>].</remarks>
        /// <userdoc>The number of columns.</userdoc>
        [DataMember]
        [DataMemberRange(1, 0)]
        [Display(category: LayoutCategory)]
        [DefaultValue(1)]
        public int Columns
        {
            get { return columns; }
            set
            {
                columns = MathUtil.Clamp(value, 1, int.MaxValue);
                InvalidateMeasure();
            }
        }

        protected override Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            // compute the size available for one cell
            var gridSize = new Vector2(Columns, Rows);
            var availableForOneCell = new Vector2(availableSizeWithoutMargins.X / gridSize.X, availableSizeWithoutMargins.Y / gridSize.Y);

            // measure all the children
            var neededForOneCell = Vector2.Zero;
            foreach (var child in VisualChildrenCollection)
            {
                // compute the size available for the child depending on its spans values
                var childSpans = GetElementSpanValuesAsFloat(child);
                var availableForChildWithMargin = Vector2.Modulate(childSpans, availableForOneCell);

                child.Measure(ref availableForChildWithMargin);

                neededForOneCell = new Vector2(
                    Math.Max(neededForOneCell.X, child.DesiredSizeWithMargins.X / childSpans.X),
                    Math.Max(neededForOneCell.Y, child.DesiredSizeWithMargins.Y / childSpans.Y));
            }

            return Vector2.Modulate(gridSize, neededForOneCell);
        }

        protected override Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            // compute the size available for one cell
            var gridSize = new Vector2(Columns, Rows);
            finalForOneCell = new Vector2(finalSizeWithoutMargins.X / gridSize.X, finalSizeWithoutMargins.Y / gridSize.Y);

            // arrange all the children
            foreach (var child in VisualChildrenCollection)
            {
                // compute the final size of the child depending on its spans values
                var childSpans = GetElementSpanValuesAsFloat(child);
                var finalForChildWithMargin = Vector2.Modulate(childSpans, finalForOneCell);

                // set the arrange matrix of the child
                var childOffsets = GetElementGridPositionsAsFloat(child);
                child.DependencyProperties.Set(PanelArrangeMatrixPropertyKey, Matrix.Translation(Vector2.Modulate(childOffsets, finalForOneCell) - finalSizeWithoutMargins / 2));

                // arrange the child
                child.Arrange(ref finalForChildWithMargin, IsCollapsed);
            }

            return finalSizeWithoutMargins;
        }
        
        private void CalculateDistanceToSurroundingModulo(float position, float modulo, float elementCount, out Vector2 distances)
        {
            if (modulo <= 0)
            {
                distances = Vector2.Zero;
                return;
            }

            var validPosition = Math.Max(0, Math.Min(position, elementCount * modulo));
            var inferiorQuotient = Math.Min(elementCount - 1, (float)Math.Floor(validPosition / modulo));

            distances.X = (inferiorQuotient+0) * modulo - validPosition;
            distances.Y = (inferiorQuotient+1) * modulo - validPosition;
        }

        public override Vector2 GetSurroudingAnchorDistances(Orientation direction, float position)
        {
            Vector2 distances;
            var gridElements = new Vector2(Columns, Rows);
            
            CalculateDistanceToSurroundingModulo(position, finalForOneCell[(int)direction], gridElements[(int)direction], out distances);

            return distances;
        }

        /// <summary>
        /// Get an element span values as an <see cref="Vector3"/>.
        /// </summary>
        /// <param name="element">The element from which extract the span values</param>
        /// <returns>The span values of the element</returns>
        protected Vector2 GetElementSpanValuesAsFloat(UIElement element)
        {
            var intValues = GetElementSpanValues(element);

            return new Vector2(intValues.X, intValues.Y);
        }

        /// <summary>
        /// Get the positions of an element in the grid as an <see cref="Vector3"/>.
        /// </summary>
        /// <param name="element">The element from which extract the position values</param>
        /// <returns>The position of the element</returns>
        protected Vector2 GetElementGridPositionsAsFloat(UIElement element)
        {
            var intValues = GetElementGridPositions(element);

            return new Vector2(intValues.X, intValues.Y);
        }
    }
}
