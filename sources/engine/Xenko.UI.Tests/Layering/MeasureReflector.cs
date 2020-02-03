// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Xenko.Core.Mathematics;

namespace Xenko.UI.Tests.Layering
{
    /// <summary>
    /// Element that returns the size provided during the measure.
    /// Can be used to analyze the size during measure.
    /// </summary>
    public class MeasureReflector: UIElement
    {
        protected override Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            return availableSizeWithoutMargins;
        }
    }
}
