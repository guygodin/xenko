// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Xenko.Core;

namespace Xenko.UI
{
    /// <summary>
    /// Provides a services class for all the User Interface elements in Xenko applications.
    /// </summary>
    public struct UIElementServices
    {
        public IServiceRegistry Services { get; set; }

        public bool Equals(ref UIElementServices other)
        {
            return (Services == other.Services);
        }

    }

}
