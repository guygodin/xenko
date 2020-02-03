// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

namespace Xenko.UI
{
    /// <summary>
    /// The different ways of scrolling in a <see cref="Controls.ScrollViewer"/>.
    /// </summary>
    public enum ScrollingMode
    {
        /// <summary>
        /// No scrolling is allowed.
        /// </summary>
        /// <userdoc>No scrolling is allowed.</userdoc>
        None,
        /// <summary>
        /// Only horizontal scrolling is allowed.
        /// </summary>
        /// <userdoc>Only horizontal scrolling is allowed.</userdoc>
        Horizontal,
        /// <summary>
        /// Only vertical scrolling is allowed.
        /// </summary>
        /// <userdoc>Only vertical scrolling is allowed.</userdoc>
        Vertical,
        /// <summary>
        /// Both horizontal and vertical scrolling are allowed.
        /// </summary>
        /// <userdoc>Both horizontal and vertical scrolling are allowed.</userdoc>
        HorizontalVertical,
    }
}
