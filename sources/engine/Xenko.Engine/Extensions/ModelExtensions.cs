using System;
using System.Collections.Generic;
using System.Text;
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Graphics;
using Xenko.Rendering;
using Xenko.Rendering.Materials;

namespace Xenko.Rendering
{
    public static class ModelExtensions
    {
        #region Fields
        private static readonly Dictionary<MeshDraw, InputElementDescription[]> _inputElements = new Dictionary<MeshDraw, InputElementDescription[]>();
        private static MutablePipelineState _pipelineState;
        private static EffectInstance _simpleEffect;
        #endregion

        #region Methods
        public static void Draw(this Model model, GraphicsContext context, ref Matrix transform, float opacity = 1.0f, SamplerState samplerOverride = null, BlendStateDescription? blendState = null, Mesh excludedMesh = null)
        {
            var commandList = context.CommandList;

            if (_simpleEffect == null)
            {
                var graphicsDevice = commandList.GraphicsDevice;
                var effect = new Effect(graphicsDevice, SpriteEffect.Bytecode).DisposeBy(graphicsDevice);
                _simpleEffect = new EffectInstance(effect).DisposeBy(graphicsDevice);
                _simpleEffect.UpdateEffect(graphicsDevice);
                _pipelineState = new MutablePipelineState(graphicsDevice);
                _pipelineState.State.SetDefaults();
                _pipelineState.State.RootSignature = _simpleEffect.RootSignature;
                _pipelineState.State.EffectBytecode = _simpleEffect.Effect.Bytecode;
            }

            var color = new Color4(opacity, opacity, opacity, opacity);
            _simpleEffect.Parameters.Set(SpriteEffectKeys.Color, ref color);
            _simpleEffect.Parameters.Set(SpriteBaseKeys.MatrixTransform, ref transform);

            for (var i = 0; i < model.Meshes.Count; i++)
            {
                var mesh = model.Meshes[i];
                if (mesh == excludedMesh)
                    continue;

                var meshDraw = mesh.Draw;
                for (var slot = 0; slot < meshDraw.VertexBuffers.Length; slot++)
                {
                    var vertexBuffer = meshDraw.VertexBuffers[slot];
                    commandList.SetVertexBuffer(slot, vertexBuffer.Buffer, vertexBuffer.Offset, vertexBuffer.Stride);
                }
                if (meshDraw.IndexBuffer != null)
                {
                    commandList.SetIndexBuffer(meshDraw.IndexBuffer.Buffer, meshDraw.IndexBuffer.Offset, meshDraw.IndexBuffer.Is32Bit);
                }

                SetPipelineState(commandList, meshDraw, blendState);

                var material = model.Materials[mesh.MaterialIndex].Material;
                for (var j = 0; j < material.Passes.Count; j++)
                {
                    var parameters = material.Passes[j].Parameters;
                    ApplyEffect(context, parameters, samplerOverride);

                    if (meshDraw.IndexBuffer != null)
                    {
                        commandList.DrawIndexed(meshDraw.DrawCount, meshDraw.StartLocation, 0);
                    }
                    else
                    {
                        commandList.Draw(meshDraw.DrawCount, meshDraw.StartLocation);
                    }
                }
            }
        }

        private static void SetPipelineState(CommandList commandList, MeshDraw meshDraw, BlendStateDescription? blendState)
        {
            if (!_inputElements.TryGetValue(meshDraw, out InputElementDescription[] inputElements))
            {
                inputElements = meshDraw.VertexBuffers.CreateInputElements();
                _inputElements.Add(meshDraw, inputElements);
            }
            _pipelineState.State.BlendState = blendState ?? BlendStates.Default;
            _pipelineState.State.InputElements = inputElements;
            _pipelineState.State.PrimitiveType = meshDraw.PrimitiveType;
            _pipelineState.State.Output.CaptureState(commandList);
            _pipelineState.Update();

            commandList.SetPipelineState(_pipelineState.CurrentState);
        }

        private static void ApplyEffect(GraphicsContext context, ParameterCollection materialParams, SamplerState samplerOverride = null)
        {
            _simpleEffect.Parameters.Set(TexturingKeys.Texture0, materialParams.Get(MaterialKeys.DiffuseMap));
            _simpleEffect.Parameters.Set(TexturingKeys.Sampler, samplerOverride ?? materialParams.Get(MaterialKeys.Sampler) ?? context.CommandList.GraphicsDevice.SamplerStates.LinearClamp);
            _simpleEffect.Apply(context);
        }
        #endregion
    }
}
