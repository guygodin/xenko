// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Xenko.Input;
using Xenko.UI.Events;

namespace Xenko.UI
{
    /// <summary>
    /// The arguments associated with a <see cref="TextInputEvent"/>
    /// </summary>
    public class TextEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// The text that was entered
        /// </summary>
        public string Text { get; internal set; }
        
        /// <summary>
        /// The type of text input event
        /// </summary>
        public TextInputEventType Type { get; internal set; }

        /// <summary>
        /// Start of the current composition being edited
        /// </summary>
        public int CompositionStart { get; internal set; }

        /// <summary>
        /// Length of the current part of the composition being edited
        /// </summary>
        public int CompositionLength { get; internal set; }
    }
}
