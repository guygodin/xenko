// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

using Xunit;

using Xenko.Core.Mathematics;
using Xenko.UI.Controls;
using Xenko.UI.Panels;

namespace Xenko.UI.Tests.Layering
{
    /// <summary>
    /// Series of tests for <see cref="Canvas"/>
    /// </summary>
    public class CanvasTests : Canvas
    {
        private Random rand = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// launch all the tests of <see cref="CanvasTests"/>
        /// </summary>
        internal void TestAll()
        {
            TestProperties();
            TestCollapseOverride();
            TestBasicInvalidations();
            TestMeasureOverrideRelative();
            TestArrangeOverrideRelative();
            TestMeasureOverrideAbsolute();
            TestArrangeOverrideAbsolute();
        }

        private void ResetState()
        {
            DependencyProperties.Clear();
            Children.Clear();
            InvalidateArrange();
            InvalidateMeasure();
        }

        /// <summary>
        /// Test the <see cref="Canvas"/> properties
        /// </summary>
        [Fact]
        public void TestProperties()
        {
            var newElement = new Canvas();

            // test default values
            Assert.Equal(float.NaN, newElement.DependencyProperties.Get(RelativeSizePropertyKey).X);
            Assert.Equal(float.NaN, newElement.DependencyProperties.Get(RelativeSizePropertyKey).Y);
            Assert.Equal(Vector2.Zero, newElement.DependencyProperties.Get(RelativePositionPropertyKey));
            Assert.Equal(Vector2.Zero, newElement.DependencyProperties.Get(AbsolutePositionPropertyKey));
            Assert.Equal(Vector2.Zero, newElement.DependencyProperties.Get(PinOriginPropertyKey));

            // test pin origin validator
            newElement.DependencyProperties.Set(PinOriginPropertyKey, new Vector2(-1));
            Assert.Equal(Vector2.Zero, newElement.DependencyProperties.Get(PinOriginPropertyKey));
            newElement.DependencyProperties.Set(PinOriginPropertyKey, new Vector2(2));
            Assert.Equal(Vector2.One, newElement.DependencyProperties.Get(PinOriginPropertyKey));
            newElement.DependencyProperties.Set(PinOriginPropertyKey, new Vector2(0.5f));
            Assert.Equal(new Vector2(0.5f), newElement.DependencyProperties.Get(PinOriginPropertyKey));

            // test relative size validator
            newElement.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(0.5f));
            Assert.Equal(new Vector2(0.5f), newElement.DependencyProperties.Get(RelativeSizePropertyKey));
            newElement.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(2.5f, 3.5f));
            Assert.Equal(new Vector2(2.5f, 3.5f), newElement.DependencyProperties.Get(RelativeSizePropertyKey));
            newElement.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(-2.4f, 3.5f));
            Assert.Equal(new Vector2(2.4f, 3.5f), newElement.DependencyProperties.Get(RelativeSizePropertyKey));
            newElement.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(2.5f, -3.4f));
            Assert.Equal(new Vector2(2.5f, 3.4f), newElement.DependencyProperties.Get(RelativeSizePropertyKey));
            newElement.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(2.5f, 3.5f));
            Assert.Equal(new Vector2(2.5f, 3.5f), newElement.DependencyProperties.Get(RelativeSizePropertyKey));
        }

        /// <summary>
        /// Test the invalidations generated object property changes.
        /// </summary>
        [Fact]
        public void TestBasicInvalidations()
        {
            var canvas = new Canvas();
            var child = new Canvas();
            canvas.Children.Add(child);

            // - test the properties that are supposed to invalidate the object measurement
            UIElementLayeringTests.TestMeasureInvalidation(canvas, () => child.DependencyProperties.Set(PinOriginPropertyKey, new Vector2(0.1f, 0.2f)));
            UIElementLayeringTests.TestMeasureInvalidation(canvas, () => child.DependencyProperties.Set(RelativePositionPropertyKey, new Vector2(1f, 2f)));
            UIElementLayeringTests.TestMeasureInvalidation(canvas, () => child.DependencyProperties.Set(AbsolutePositionPropertyKey, new Vector2(1f, 2f)));
            UIElementLayeringTests.TestMeasureInvalidation(canvas, () => child.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(1f, 2f)));
        }
        
        /// <summary>
        /// Test the function <see cref="Canvas.MeasureOverride"/>
        /// </summary>
        [Fact]
        public void TestMeasureOverrideRelative()
        {
            ResetState();

            // check that desired size is null if no children
            Measure(1000 * rand.NextVector2());
            Assert.Equal(Vector2.Zero, DesiredSize);

            var child = new MeasureValidator();
            child.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(0.2f,0.3f));
            Children.Add(child);
            
            child.ExpectedMeasureValue = new Vector2(2,3);
            child.ReturnedMeasuredValue = new Vector2(4,3);
            Measure(10 * Vector2.One);
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, DesiredSize);
        }

        /// <summary>
        /// Test for the function <see cref="Canvas.ArrangeOverride"/>
        /// </summary>
        [Fact]
        public void TestArrangeOverrideRelative()
        {
            ResetState();

            // test that arrange set render size to provided size when there is no children
            var providedSize = 1000 * rand.NextVector2();
            var providedSizeWithoutMargins = CalculateSizeWithoutThickness(ref providedSize, ref MarginInternal);
            Measure(providedSize);
            Arrange(providedSize, false);
            Assert.Equal(providedSizeWithoutMargins, (Vector2)RenderSize);

            ResetState();

            var child = new ArrangeValidator();
            child.DependencyProperties.Set(UseAbsolutePositionPropertyKey, false);
            child.DependencyProperties.Set(RelativeSizePropertyKey, new Vector2(0.2f, 0.3f));
            child.DependencyProperties.Set(PinOriginPropertyKey, new Vector2(0f, 0.5f));
            child.DependencyProperties.Set(RelativePositionPropertyKey, new Vector2(0.2f, 0.4f));
            Children.Add(child);

            child.ReturnedMeasuredValue = 2 * new Vector2(2, 6);
            child.ExpectedArrangeValue = child.ReturnedMeasuredValue;
            providedSize = new Vector2(10, 20);
            Measure(providedSize);
            Arrange(providedSize, false);
            Assert.Equal(Matrix.Translation(2f-5f,8f-6f-10f,18f-24f-15f), child.DependencyProperties.Get(PanelArrangeMatrixPropertyKey));
        }
        
        /// <summary>
        /// Test <see cref="Canvas.CollapseOverride"/>
        /// </summary>
        [Fact]
        public void TestCollapseOverride()
        {
            ResetState();

            // create two children
            var childOne = new StackPanelTests();
            var childTwo = new StackPanelTests();

            // set fixed size to the children
            childOne.Width = rand.NextFloat();
            childOne.Height = rand.NextFloat();
            childTwo.Width = 10 * rand.NextFloat();
            childTwo.Height = 20 * rand.NextFloat();

            // add the children to the stack panel 
            Children.Add(childOne);
            Children.Add(childTwo);

            // arrange the stack panel and check children size
            Arrange(1000 * rand.NextVector2(), true);
            Assert.Equal(Vector2.Zero, (Vector2)childOne.RenderSize);
            Assert.Equal(Vector2.Zero, (Vector2)childTwo.RenderSize);
        }

        /// <summary>
        /// Test the function <see cref="Canvas.MeasureOverride"/> with absolute position
        /// </summary>
        [Fact]
        public void TestMeasureOverrideAbsolute()
        {
            ResetState();

            // check that desired size is null if no children
            Measure(1000 * rand.NextVector2());
            Assert.Equal(Vector2.Zero, DesiredSize);

            var child = new MeasureValidator();
            Children.Add(child);
            child.Margin = new Thickness(10);

            // check canvas desired size and child provided size with one child out of the available zone
            var availableSize = new Vector2(100, 200);
            var childDesiredSize = new Vector2(30, 80);

            var pinOrigin = Vector2.Zero;
            TestOutOfBounds(child, childDesiredSize, new Vector2(float.PositiveInfinity), new Vector2(-1, 100), pinOrigin, availableSize, Vector2.Zero);
        }

        private void TestOutOfBounds(MeasureValidator child, Vector2 childDesiredSize, Vector2 childExpectedValue, Vector2 pinPosition, Vector2 pinOrigin, Vector2 availableSize, Vector2 expectedSize)
        {
            child.ExpectedMeasureValue = childExpectedValue;
            child.ReturnedMeasuredValue = childDesiredSize;
            child.DependencyProperties.Set(AbsolutePositionPropertyKey, pinPosition);
            child.DependencyProperties.Set(PinOriginPropertyKey, pinOrigin);
            Measure(availableSize);
            Assert.Equal(expectedSize, DesiredSize);
        }

        /// <summary>
        /// Test for the function <see cref="Canvas.ArrangeOverride"/> with absolute position
        /// </summary>
        [Fact]
        public void TestArrangeOverrideAbsolute()
        {
            // test that arrange set render size to provided size when there is no children
            var nullCanvas = new Canvas();
            var providedSize = 1000 * rand.NextVector2();
            var providedSizeWithoutMargins = CalculateSizeWithoutThickness(ref providedSize, ref MarginInternal);
            nullCanvas.Measure(providedSize);
            nullCanvas.Arrange(providedSize, false);
            Assert.Equal(providedSizeWithoutMargins, (Vector2)nullCanvas.RenderSize);

            // test that arrange works properly with valid children.
            var availablesizeWithMargins = new Vector2(200, 300);
            var canvas = new Canvas();
            for (int i = 0; i < 10; i++)
            {
                var child = new ArrangeValidator { Name = i.ToString() };

                child.SetCanvasPinOrigin(new Vector2(0, 0.5f));
                child.SetCanvasAbsolutePosition(((i>>1)-1) * 0.5f * availablesizeWithMargins);
                child.Margin = new Thickness(10, 11, 13, 14);

                child.ReturnedMeasuredValue = (i%2)==0? new Vector2(1000) : availablesizeWithMargins/3f;
                child.ExpectedArrangeValue = child.ReturnedMeasuredValue;

                canvas.Children.Add(child);
            }

            // Measure the stack
            canvas.Measure(availablesizeWithMargins);
            canvas.Arrange(availablesizeWithMargins, false);

            // checks the stack arranged size
            Assert.Equal(availablesizeWithMargins, (Vector2)canvas.RenderSize);

            // Checks the children arrange matrix
            for (int i = 0; i < canvas.Children.Count; i++)
            {
                var pinPosition = canvas.Children[i].DependencyProperties.Get(AbsolutePositionPropertyKey);
                var pinOrigin = canvas.Children[i].DependencyProperties.Get(PinOriginPropertyKey);
                var childOffsets = (pinPosition - Vector2.Modulate(pinOrigin, (Vector2)canvas.Children[i].RenderSize)) - (Vector2)canvas.RenderSize / 2;
                Assert.Equal(Matrix.Translation(childOffsets), canvas.Children[i].DependencyProperties.Get(PanelArrangeMatrixPropertyKey));
            }
        }

        /// <summary>
        /// Test the function <see cref="Canvas.ComputeAbsolutePinPosition"/>
        /// </summary>
        [Fact]
        public void TestComputeAbsolutePinPosition()
        {
            var child = new Button();

            // directly set the values
            var parentSize = new Vector2(2);
            child.SetCanvasRelativePosition(new Vector2(float.NaN));
            child.SetCanvasAbsolutePosition(new Vector2(-1.5f, 0));
            Assert.Equal(child.GetCanvasAbsolutePosition(), ComputeAbsolutePinPosition(child, ref parentSize));
            child.SetCanvasAbsolutePosition(new Vector2(float.NaN));
            child.SetCanvasRelativePosition(new Vector2(-1.5f, 0));
            Assert.Equal(2*child.GetCanvasRelativePosition(), ComputeAbsolutePinPosition(child, ref parentSize));

            // indirectly set the value
            child.SetCanvasAbsolutePosition(new Vector2(-1.5f, 0));
            child.SetCanvasRelativePosition(new Vector2(float.NaN));
            Assert.Equal(child.GetCanvasAbsolutePosition(), ComputeAbsolutePinPosition(child, ref parentSize));
            child.SetCanvasRelativePosition(new Vector2(-1.5f, 0));
            child.SetCanvasAbsolutePosition(new Vector2(float.NaN));
            Assert.Equal(2*child.GetCanvasRelativePosition(), ComputeAbsolutePinPosition(child, ref parentSize));

            // indirect/direct mix
            child.SetCanvasAbsolutePosition(new Vector2(-1.5f, float.NaN));
            child.SetCanvasRelativePosition(new Vector2(float.NaN, 1));
            Assert.Equal(new Vector2(-1.5f, 2), ComputeAbsolutePinPosition(child, ref parentSize));
            child.SetCanvasRelativePosition(new Vector2(-1.5f, float.NaN));
            child.SetCanvasAbsolutePosition(new Vector2(float.NaN, 1));
            Assert.Equal(new Vector2(-3f, 1), ComputeAbsolutePinPosition(child, ref parentSize));

            // infinite values
            parentSize = new Vector2(float.PositiveInfinity);
            child.SetCanvasRelativePosition(new Vector2(-1.5f, 0));
            Utilities.AreExactlyEqual(new Vector2(float.NegativeInfinity, 0f), ComputeAbsolutePinPosition(child, ref parentSize));
        }

        /// <summary>
        /// Test the function <see cref="Canvas.MeasureOverride"/> when provided size is infinite
        /// </summary>
        [Fact]
        public void TestMeasureOverrideInfinite()
        {
            var child1 = new MeasureValidator();
            var canvas = new Canvas { Children = { child1 } };

            // check that relative 0 x inf available = 0 
            child1.SetCanvasRelativeSize(Vector2.Zero);
            child1.ExpectedMeasureValue = Vector2.Zero;
            canvas.Measure(new Vector2(float.PositiveInfinity));
            child1.SetCanvasRelativeSize(new Vector2(float.NaN));

            // check sizes with infinite measure values and absolute position
            child1.SetCanvasAbsolutePosition(new Vector2(1, -1));
            child1.ExpectedMeasureValue = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
            child1.ReturnedMeasuredValue = new Vector2(2);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);

            // check sizes with infinite measure values and relative position
            child1.SetCanvasPinOrigin(new Vector2(0, .5f));
            child1.SetCanvasRelativePosition(new Vector2(-1));
            child1.ExpectedMeasureValue = new Vector2(0);
            child1.ReturnedMeasuredValue = new Vector2(1);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);
            child1.SetCanvasRelativePosition(new Vector2(0));
            child1.ExpectedMeasureValue = new Vector2(float.PositiveInfinity, 0);
            child1.ReturnedMeasuredValue = new Vector2(1);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);
            child1.SetCanvasRelativePosition(new Vector2(0.5f));
            child1.ExpectedMeasureValue = new Vector2(float.PositiveInfinity);
            child1.ReturnedMeasuredValue = new Vector2(1);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);
            child1.SetCanvasRelativePosition(new Vector2(1f));
            child1.ExpectedMeasureValue = new Vector2(float.PositiveInfinity);
            child1.ReturnedMeasuredValue = new Vector2(1);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);
            child1.SetCanvasRelativePosition(new Vector2(2f));
            child1.ExpectedMeasureValue = new Vector2(float.PositiveInfinity);
            child1.ReturnedMeasuredValue = new Vector2(1);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);

            // check that the maximum is correctly taken
            var child2 = new MeasureValidator();
            var child3 = new MeasureValidator();
            canvas.Children.Add(child2);
            canvas.Children.Add(child3);
            child1.InvalidateMeasure();
            child1.SetCanvasPinOrigin(new Vector2(0.5f));
            child1.SetCanvasRelativePosition(new Vector2(0.5f));
            child1.ExpectedMeasureValue = new Vector2(float.PositiveInfinity);
            child1.ReturnedMeasuredValue = new Vector2(10);
            child2.SetCanvasPinOrigin(new Vector2(0.5f));
            child2.SetCanvasRelativePosition(new Vector2(-.1f, .5f));
            child2.ExpectedMeasureValue = new Vector2(float.PositiveInfinity);
            child2.ReturnedMeasuredValue = new Vector2(30.8f, 5);
            child3.SetCanvasRelativeSize(new Vector2(0f, 1f));
            child3.ExpectedMeasureValue = new Vector2(0, float.PositiveInfinity);
            child3.ReturnedMeasuredValue = new Vector2(0, 5);
            canvas.Measure(new Vector2(float.PositiveInfinity));
            // canvas size does not depend on its children
            Assert.Equal(Vector2.Zero, canvas.DesiredSizeWithMargins);
        }
    }
}
