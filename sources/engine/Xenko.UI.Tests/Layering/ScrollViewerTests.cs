// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

using Xunit;

using Xenko.Core.Mathematics;
using Xenko.UI.Controls;

namespace Xenko.UI.Tests.Layering
{
    /// <summary>
    /// A class that contains test functions for layering of the <see cref="ScrollViewer"/> class.
    /// </summary>
    [System.ComponentModel.Description("Tests for ScrollViewer layering")]
    public class ScrollViewerTests : ScrollViewer
    {
        /// <summary>
        /// Test the invalidations generated object property changes.
        /// </summary>
        [Fact]
        public void TestBasicInvalidations()
        {
            // - test the properties that are not supposed to invalidate the object layout state
            UIElementLayeringTests.TestNoInvalidation(this, () => Deceleration = 5.5f);
            UIElementLayeringTests.TestNoInvalidation(this, () => TouchScrollingEnabled = !TouchScrollingEnabled);
            UIElementLayeringTests.TestNoInvalidation(this, () => ScrollBarColor = new Color(1, 2, 3, 4));
            UIElementLayeringTests.TestNoInvalidation(this, () => ScrollBarThickness = 34);
        }


        [Fact]
        public void TestScrolling()
        {
            const float elementWidth = 100;
            const float elementHeight = 200;

            var rand = new Random();
            var scrollViewer = new ScrollViewer { ScrollMode = ScrollingMode.HorizontalVertical, Width = elementWidth, Height = elementHeight };
            scrollViewer.Measure(Vector2.Zero);
            scrollViewer.Arrange(Vector2.Zero, false);

            // tests that no crashes happen with no content
            scrollViewer.ScrollTo(rand.NextVector2());
            Assert.Equal(Vector2.Zero, ScrollPosition);
            scrollViewer.ScrollOf(rand.NextVector2());
            Assert.Equal(Vector2.Zero, ScrollPosition);
            scrollViewer.ScrollToBeginning(Orientation.Horizontal);
            Assert.Equal(Vector2.Zero, ScrollPosition);
            scrollViewer.ScrollToEnd(Orientation.Horizontal);
            Assert.Equal(Vector2.Zero, ScrollPosition);

            // tests with an arranged element
            const float contentWidth = 1000;
            const float contentHeight = 2000;
            var content = new ContentDecorator { Width = contentWidth, Height = contentHeight };
            scrollViewer.Content = content;
            scrollViewer.Measure(Vector2.Zero);
            scrollViewer.Arrange(Vector2.Zero, false);

            var scrollValue = new Vector2(123, 456);
            scrollViewer.ScrollTo(scrollValue);
            Assert.Equal(new Vector2(scrollValue.X, scrollValue.Y), scrollViewer.ScrollPosition);

            scrollViewer.ScrollToEnd(Orientation.Horizontal);
            Assert.Equal(new Vector2(contentWidth - elementWidth, scrollValue.Y), scrollViewer.ScrollPosition);
            scrollViewer.ScrollToEnd(Orientation.Vertical);
            Assert.Equal(new Vector2(contentWidth - elementWidth, contentHeight - elementHeight), scrollViewer.ScrollPosition);

            scrollViewer.ScrollToBeginning(Orientation.Horizontal);
            Assert.Equal(new Vector2(0, contentHeight - elementHeight), scrollViewer.ScrollPosition);
            scrollViewer.ScrollToBeginning(Orientation.Vertical);
            Assert.Equal(new Vector2(0, 0), scrollViewer.ScrollPosition);

            scrollViewer.ScrollOf(scrollValue);
            Assert.Equal(new Vector2(scrollValue.X, scrollValue.Y), scrollViewer.ScrollPosition);

            // tests with an not arranged element
            content.InvalidateArrange();
            scrollViewer.ScrollTo(scrollValue);
            scrollViewer.Arrange(Vector2.Zero, false);
            Assert.Equal(new Vector2(scrollValue.X, scrollValue.Y), scrollViewer.ScrollPosition);
            content.InvalidateArrange();
            scrollViewer.ScrollOf(2*scrollValue);
            scrollViewer.ScrollTo(scrollValue);
            scrollViewer.Arrange(Vector2.Zero, false);
            Assert.Equal(new Vector2(scrollValue.X, scrollValue.Y), scrollViewer.ScrollPosition);

            content.InvalidateArrange();
            scrollViewer.ScrollToEnd(Orientation.Horizontal);
            scrollViewer.ScrollToEnd(Orientation.Vertical);
            scrollViewer.Arrange(Vector2.Zero, false);
            Assert.Equal(new Vector2(contentWidth - elementWidth, contentHeight - elementHeight), scrollViewer.ScrollPosition);

            content.InvalidateArrange();
            scrollViewer.ScrollToBeginning(Orientation.Horizontal);
            scrollViewer.ScrollToBeginning(Orientation.Vertical);
            scrollViewer.Arrange(Vector2.Zero, false);
            Assert.Equal(new Vector2(0, 0), scrollViewer.ScrollPosition);

            content.InvalidateArrange();
            scrollViewer.ScrollOf(scrollValue);
            scrollViewer.Arrange(Vector2.Zero, false);
            Assert.Equal(new Vector2(scrollValue.X, scrollValue.Y), scrollViewer.ScrollPosition);
            content.InvalidateArrange();
            scrollViewer.ScrollToBeginning(Orientation.Horizontal);
            scrollViewer.ScrollToBeginning(Orientation.Vertical);
            scrollViewer.ScrollOf(scrollValue);
            scrollViewer.ScrollOf(scrollValue);
            scrollViewer.Arrange(Vector2.Zero, false);
            Assert.Equal(new Vector2(2*scrollValue.X, 2*scrollValue.Y), scrollViewer.ScrollPosition);
        }

        /// <summary>
        /// Tests that <see cref="ScrollViewer.CurrentScrollingSpeed"/> is properly reseted or not.
        /// </summary>
        [Fact]
        public void TestStopScrolling()
        {
            var referenceValue = Vector2.One;

            ScrollMode = ScrollingMode.Horizontal;

            CurrentScrollingSpeed = referenceValue;

            // tests the function itself
            StopCurrentScrolling();
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);

            CurrentScrollingSpeed = referenceValue;

            // tests ScrollTo function
            ScrollTo(Vector2.Zero, false);
            Assert.Equal(referenceValue, CurrentScrollingSpeed);
            ScrollTo(Vector2.Zero);
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);
            
            CurrentScrollingSpeed = referenceValue;

            // tests ScrollOf function
            ScrollOf(Vector2.Zero, false);
            Assert.Equal(referenceValue, CurrentScrollingSpeed);
            ScrollOf(Vector2.Zero);
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);

            CurrentScrollingSpeed = referenceValue;

            // test ScrollToBeginning
            ScrollToBeginning(Orientation.Horizontal, false);
            Assert.Equal(referenceValue, CurrentScrollingSpeed);
            ScrollToBeginning(Orientation.Vertical, false);
            Assert.Equal(referenceValue, CurrentScrollingSpeed);
            ScrollToBeginning(Orientation.Horizontal);
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);
            CurrentScrollingSpeed = referenceValue;
            ScrollToBeginning(Orientation.Vertical);
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);

            CurrentScrollingSpeed = referenceValue;

            // test ScrollToEnd
            ScrollToEnd(Orientation.Horizontal, false);
            Assert.Equal(referenceValue, CurrentScrollingSpeed);
            ScrollToEnd(Orientation.Vertical, false);
            Assert.Equal(referenceValue, CurrentScrollingSpeed);
            ScrollToEnd(Orientation.Horizontal);
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);
            CurrentScrollingSpeed = referenceValue;
            ScrollToEnd(Orientation.Vertical);
            Assert.Equal(Vector2.Zero, CurrentScrollingSpeed);

            CurrentScrollingSpeed = referenceValue;
        }
    }
}
