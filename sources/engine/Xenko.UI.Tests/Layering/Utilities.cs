// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

using Xunit;

using Xenko.Core.Mathematics;

namespace Xenko.UI.Tests.Layering
{
    public static class Utilities
    {
        // ReSharper disable UnusedParameter.Local
        public static void AssertAreNearlyEqual(float reference, float value)
        {
            Assert.True(Math.Abs(reference - value) < 0.001f);
        }

        public static void AssertAreNearlyEqual(Vector2 reference, Vector2 value)
        {
            Assert.True((reference - value).Length() < 0.001f);
        }

        public static void AssertAreNearlyEqual(Matrix reference, Matrix value)
        {
            var diffMat = reference - value;
            for (int i = 0; i < 16; i++)
                Assert.True(Math.Abs(diffMat[i]) < 0.001);
        }
        // ReSharper restore UnusedParameter.Local 

        public static void AreExactlyEqual(Vector2 left, Vector2 right)
        {
            Assert.Equal(left.X, right.X);
            Assert.Equal(left.Y, right.Y);
        }
    }
}
