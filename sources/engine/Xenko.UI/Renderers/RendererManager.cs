// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;

using System.Reflection;

namespace Xenko.UI.Renderers
{
    /// <summary>
    /// The class in charge to manage the renderer of the different <see cref="UIElement"/>s.
    /// Once registered into the manager, a renderer is owned by the manager.
    /// </summary>
    public class RendererManager: IRendererManager, IDisposable
    {
        private readonly IElementRendererFactory defaultFactory;

        private readonly Dictionary<Type, IElementRendererFactory> typesToUserFactories = new Dictionary<Type, IElementRendererFactory>();

        // Note: use Id instead of element instance in order to avoid to keep dead UIelement alive.
        private readonly HashSet<ElementRenderer> elementRenderers = new HashSet<ElementRenderer>();

        /// <summary> 
        /// Create a new instance of <see cref="RendererManager"/> with provided DefaultFactory
        /// </summary>
        /// <param name="defaultFactory"></param>
        public RendererManager(IElementRendererFactory defaultFactory)
        {
            this.defaultFactory = defaultFactory;
        }

        public ElementRenderer GetRenderer(UIElement element)
        {
            var renderer = element.Renderer;
            if (renderer == null)
            {
                // try to get the renderer from the user registered class factory
                if (typesToUserFactories.Count > 0)
                {
                    var currentType = element.GetType();
                    while (currentType != null)
                    {
                        if (typesToUserFactories.TryGetValue(currentType, out var factory))
                        {
                            renderer = factory.TryCreateRenderer(element);
                            if (renderer != null)
                                break;
                        }

                        currentType = currentType.GetTypeInfo().BaseType;
                    }
                }

                // try to get the renderer from the default renderer factory.
                if (renderer == null)
                {
                    if (defaultFactory != null)
                        renderer = defaultFactory.TryCreateRenderer(element);

                    if (renderer == null)
                        throw new InvalidOperationException($"No renderer found for element {element}");
                }

                // cache the renderer for future uses.
                element.Renderer = renderer;
                elementRenderers.Add(renderer);
            }

            return renderer;
        }

        public void RegisterRendererFactory(Type uiElementType, IElementRendererFactory factory)
        {
            if (uiElementType == null) throw new ArgumentNullException(nameof(uiElementType));
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            if (!typeof(UIElement).GetTypeInfo().IsAssignableFrom(uiElementType.GetTypeInfo()))
                throw new InvalidOperationException(uiElementType + " is not a descendant of UIElement.");

            typesToUserFactories[uiElementType] = factory;
        }

        public void RegisterRenderer(UIElement element, ElementRenderer renderer)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));

            element.Renderer = renderer;
            elementRenderers.Add(renderer);
        }

        public void Dispose()
        {
            foreach (var renderer in elementRenderers)
            {
                if (!renderer.IsDisposed)
                    renderer.Dispose();
            }
            elementRenderers.Clear();
        }
    }
}
