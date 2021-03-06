// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

using Xenko.Core.Mathematics;
using Xenko.UI.Events;

namespace Xenko.UI
{
    /// <summary>
    /// Provides data for touch input events.
    /// </summary>
    public class TouchEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Gets the time when this event occurred.
        /// </summary>
        public TimeSpan Timestamp { get; set; }
        
        /// <summary>
        /// Gets the action that occurred.
        /// </summary>
        public TouchAction Action { get; set; }

        /// <summary>
        /// Gets the position of the touch on the screen. Position is normalized between [0,1]. (0,0) is the left top corner, (1,1) is the right bottom corner.
        /// </summary>
        public Vector2 ScreenPosition { get; set; }

        /// <summary>
        /// Gets the translation of the touch on the screen since last triggered event (in normalized units). (1,1) represent a translation of the top left corner to the bottom right corner.
        /// </summary>
        public Vector2 ScreenTranslation { get; set; }

        /// <summary>
        /// Gets the position of the touch in the UI virtual world space.
        /// </summary>
        public Vector3 WorldPosition { get; set; }

        /// <summary>
        /// Gets the translation of the touch in the UI virtual world space.
        /// </summary>
        public Vector3 WorldTranslation { get; set; }
    }
}
