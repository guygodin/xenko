using System;
using Xenko.Core;
using Xenko.Rendering;
using Xenko.Graphics;
using Xenko.Shaders;
using Xenko.Core.Mathematics;
using Buffer = Xenko.Graphics.Buffer;

namespace Xenko.Rendering
{
    public static partial class SpriteEffectExtTextureChromaKeys
    {
        public static readonly ValueParameterKey<float> Similarity = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<float> Smoothness = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<float> Spill = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<Color3> ChromaKeyColor = ParameterKeys.NewValue<Color3>(new Color3(0.0f, 0.0f, 0.0f));
    }
}
