// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using Xunit;

using Xenko.Core.Mathematics;

namespace Xenko.UI.Tests.Layering
{
    class ArrangeValidator : UIElement
    {
        public Vector2 ExpectedArrangeValue;
        public Vector2 ReturnedMeasuredValue;

        protected override Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            return ReturnedMeasuredValue;
        }

        protected override Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            var maxLength = Math.Max(finalSizeWithoutMargins.Length(), ExpectedArrangeValue.Length());
            Assert.True((finalSizeWithoutMargins - ExpectedArrangeValue).Length() <= maxLength * 0.001f, 
                "Arrange validator test failed: expected value=" + ExpectedArrangeValue + ", Received value=" + finalSizeWithoutMargins + " (Validator='" + Name + "'");

            return base.ArrangeOverride(ref finalSizeWithoutMargins);
        }
    }
}
