// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Xenko.Core;

namespace Xenko.Graphics
{
    /// <summary>
    /// Base factory for <see cref="SamplerState"/>.
    /// </summary>
    public class SamplerStateFactory : GraphicsResourceFactoryBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SamplerStateFactory"/> class.
        /// </summary>
        /// <param name="device">The device.</param>
        internal SamplerStateFactory(GraphicsDevice device) : base(device)
        {
            PointWrap = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Point, TextureAddressMode.Wrap)).DisposeBy(this);
            PointWrap.Name = "SamplerState.PointWrap";

            PointClamp = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Point, TextureAddressMode.Clamp)).DisposeBy(this);
            PointClamp.Name = "SamplerState.PointClamp";

            LinearWrap = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Linear, TextureAddressMode.Wrap)).DisposeBy(this);
            LinearWrap.Name = "SamplerState.LinearWrap";

            LinearClamp = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Linear, TextureAddressMode.Clamp)).DisposeBy(this);
            LinearClamp.Name = "SamplerState.LinearClamp";

            AnisotropicWrap = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Anisotropic, TextureAddressMode.Wrap)).DisposeBy(this);
            AnisotropicWrap.Name = "SamplerState.AnisotropicWrap";

            AnisotropicClamp = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Anisotropic, TextureAddressMode.Clamp)).DisposeBy(this);
            AnisotropicClamp.Name = "SamplerState.AnisotropicClamp";

            CubicWrap = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Cubic, TextureAddressMode.Wrap)).DisposeBy(this);
            CubicWrap.Name = "SamplerState.CubicWrap";

            CubicClamp = SamplerState.New(device, new SamplerStateDescription(TextureFilter.Cubic, TextureAddressMode.Clamp)).DisposeBy(this);
            CubicClamp.Name = "SamplerState.CubicClamp";
        }

        /// <summary>
        /// Default state for point filtering with texture coordinate wrapping.
        /// </summary>
        public readonly SamplerState PointWrap;

        /// <summary>
        /// Default state for point filtering with texture coordinate clamping.
        /// </summary>
        public readonly SamplerState PointClamp;

        /// <summary>
        /// Default state for linear filtering with texture coordinate wrapping.
        /// </summary>
        public readonly SamplerState LinearWrap;

        /// <summary>
        /// Default state for linear filtering with texture coordinate clamping.
        /// </summary>
        public readonly SamplerState LinearClamp;

        /// <summary>
        /// Default state for anisotropic filtering with texture coordinate wrapping.
        /// </summary>
        public readonly SamplerState AnisotropicWrap;

        /// <summary>
        /// Default state for anisotropic filtering with texture coordinate clamping.
        /// </summary>
        public readonly SamplerState AnisotropicClamp;

        /// <summary>
        /// Default state for cubic filtering with texture coordinate wrapping.
        /// </summary>
        public readonly SamplerState CubicWrap;

        /// <summary>
        /// Default state for cubic filtering with texture coordinate clamping.
        /// </summary>
        public readonly SamplerState CubicClamp;
    }
}
