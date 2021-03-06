// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
//
// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using Xenko.Core;

namespace Xenko.Games
{
    /// <summary>
    /// Current timing used for variable-step (real time) or fixed-step (game time) games.
    /// </summary>
    public class GameTime
    {
        private TimeSpan accumulatedElapsedTime;
        private int accumulatedFrameCountPerSecond;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameTime" /> class.
        /// </summary>
        public GameTime()
        {
            accumulatedElapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameTime" /> class.
        /// </summary>
        /// <param name="totalTime">The total game time since the start of the game.</param>
        /// <param name="elapsedTime">The elapsed game time since the last update.</param>
        public GameTime(TimeSpan totalTime, TimeSpan elapsedTime)
        {
            Total = totalTime;
            Elapsed = elapsedTime;
            accumulatedElapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameTime" /> class.
        /// </summary>
        /// <param name="totalTime">The total game time since the start of the game.</param>
        /// <param name="elapsedTime">The elapsed game time since the last update.</param>
        /// <param name="isRunningSlowly">True if the game is running unexpectedly slowly.</param>
        public GameTime(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            Total = totalTime;
            Elapsed = elapsedTime;
            IsRunningSlowly = isRunningSlowly;
            accumulatedElapsedTime = TimeSpan.Zero;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the elapsed game time since the last update
        /// </summary>
        /// <value>The elapsed game time.</value>
        public TimeSpan Elapsed { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the game is running slowly than its TargetElapsedTime. This can be used for example to render less details...etc.
        /// </summary>
        /// <value><c>true</c> if this instance is running slowly; otherwise, <c>false</c>.</value>
        public bool IsRunningSlowly { get; private set; }

        /// <summary>
        /// Gets the amount of game time since the start of the game.
        /// </summary>
        /// <value>The total game time.</value>
        public TimeSpan Total { get; private set; }

        /// <summary>
        /// Gets the current frame count since the start of the game.
        /// </summary>
        public int FrameCount { get; private set; }

        /// <summary>
        /// Gets the number of frame per second (FPS) for the current running game.
        /// </summary>
        /// <value>The frame per second.</value>
        public float FramePerSecond { get; private set; }

        /// <summary>
        /// Gets the time per frame.
        /// </summary>
        /// <value>The time per frame.</value>
        public TimeSpan TimePerFrame { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="FramePerSecond"/> and <see cref="TimePerFrame"/> were updated for this frame.
        /// </summary>
        /// <value><c>true</c> if the <see cref="FramePerSecond"/> and <see cref="TimePerFrame"/> were updated for this frame; otherwise, <c>false</c>.</value>
        public bool FramePerSecondUpdated { get; private set; }

        // GG: Making it public so it can be updated manually
        public void Update(TimeSpan totalGameTime, TimeSpan elapsedGameTime, TimeSpan elapsedUpdateTime, bool isRunningSlowly, bool incrementFrameCount)
        {
            Total = totalGameTime;
            Elapsed = elapsedGameTime;
            IsRunningSlowly = isRunningSlowly;
            FramePerSecondUpdated = false;

            if (incrementFrameCount)
            {
                accumulatedElapsedTime += elapsedGameTime;
                var accumulatedElapsedGameTimeInSecond = accumulatedElapsedTime.TotalSeconds;
                if (accumulatedFrameCountPerSecond > 0 && accumulatedElapsedGameTimeInSecond > 1.0)
                {
                    TimePerFrame = TimeSpan.FromTicks(accumulatedElapsedTime.Ticks / accumulatedFrameCountPerSecond);
                    FramePerSecond = (float)(accumulatedFrameCountPerSecond / accumulatedElapsedGameTimeInSecond);
                    accumulatedFrameCountPerSecond = 0;
                    accumulatedElapsedTime = TimeSpan.Zero;
                    FramePerSecondUpdated = true;
                }

                accumulatedFrameCountPerSecond++;
                FrameCount++;
            }
        }

        // GG: Making it public so it can be reset
        public void Reset(TimeSpan totalGameTime)
        {
            Update(totalGameTime, TimeSpan.Zero, TimeSpan.Zero, false, false);
            accumulatedElapsedTime = TimeSpan.Zero;
            accumulatedFrameCountPerSecond = 0;
            FrameCount = 0;
        }

        #endregion
    }
}
