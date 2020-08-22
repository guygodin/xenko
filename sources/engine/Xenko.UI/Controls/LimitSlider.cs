using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Engine;
using Xenko.UI.Events;

namespace Xenko.UI.Controls
{
    [DataContract(nameof(LimitSlider))]
    [Display(category: InputCategory)]
    public class LimitSlider : Slider
    {
        /// <summary>
        /// Identifies the <see cref="LimitChanged"/> routed event.
        /// </summary>
        public static readonly RoutedEvent<RoutedEventArgs> LimitChangedEvent = EventManager.RegisterRoutedEvent<RoutedEventArgs>(nameof(LimitChanged), RoutingStrategy.Bubble, typeof(LimitSlider));

        private float limit = 1.0f;

        /// <summary>
        /// Occurs when the limit of the slider changed.
        /// </summary>
        /// <remarks>A ValueChanged event is bubbling</remarks>
        public event EventHandler<RoutedEventArgs> LimitChanged
        {
            add { AddHandler(LimitChangedEvent, value); }
            remove { RemoveHandler(LimitChangedEvent, value); }
        }

        static LimitSlider()
        {
            EventManager.RegisterClassHandler(typeof(LimitSlider), LimitChangedEvent, LimitChangedClassHandler);
        }

        /// <summary>
        /// Gets or sets the current value of the slider.
        /// </summary>
        /// <remarks>The value is coerced in the range [<see cref="Minimum"/>, <see cref="Maximum"/>].</remarks>
        /// <userdoc>The current value limit of the slider.</userdoc>
        [DataMember]
        [DefaultValue(1.0f)]
        public float Limit
        {
            get { return limit; }
            set
            {
                if (float.IsNaN(value))
                    return;
                var oldLimit = Limit;

                this.limit = MathUtil.Clamp(value, Minimum, Maximum);
                if (ShouldSnapToTicks)
                    this.limit = CalculateClosestTick(this.limit);

                if (Math.Abs(oldLimit - this.limit) > MathUtil.ZeroTolerance)
                {
                    RaiseEvent(new RoutedEventArgs(LimitChangedEvent));
                    IsDirty = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image to display as Track limit.
        /// </summary>
        /// <userdoc>The image to display as Track limit.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider TrackLimitImage { get; set; }

        /// <summary>
        /// The class handler of the event <see cref="LimitChanged"/>.
        /// This method can be overridden in inherited classes to perform actions common to all instances of a class.
        /// </summary>
        /// <param name="args">The arguments of the event</param>
        protected virtual void OnLimitChanged(RoutedEventArgs args)
        {

        }

        private static void LimitChangedClassHandler(object sender, RoutedEventArgs args)
        {
            var slider = (LimitSlider)sender;
            slider.OnLimitChanged(args);
        }
    }
}
