// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using Xunit;

using Xenko.Core.Mathematics;

namespace Xenko.UI.Tests.Layering
{
    class MeasureArrangeValidator : UIElement
    {
        public Vector3 ExpectedMeasureValue;
        public Vector3 ExpectedArrangeValue;
        public Vector3 ReturnedMeasuredValue;

        protected override Vector3 MeasureOverride(ref Vector3 availableSizeWithoutMargins)
        {
            for (int i = 0; i < 3; i++)
            {
                var val1 = availableSizeWithoutMargins[i];
                var val2 = ExpectedMeasureValue[i];

                if (val1 == val2) continue; // value can be infinity

                var maxLength = Math.Max(Math.Abs(val1), Math.Abs(val2));
                Assert.True(Math.Abs(val1 - val2) < maxLength * 0.001f,
                    "Measure arrange validator test failed: expected value=" + ExpectedMeasureValue + ", Received value=" + availableSizeWithoutMargins + " (Validator='" + Name + "'");
            }

            return ReturnedMeasuredValue;
        }

        protected override Vector3 ArrangeOverride(ref Vector3 finalSizeWithoutMargins)
        {
            var maxLength = Math.Max(finalSizeWithoutMargins.Length(), ExpectedArrangeValue.Length());
            Assert.True((finalSizeWithoutMargins - ExpectedArrangeValue).Length() <= maxLength * 0.001f);

            return base.ArrangeOverride(ref finalSizeWithoutMargins);
        }
    }
}
