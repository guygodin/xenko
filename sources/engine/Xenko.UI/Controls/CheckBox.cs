// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.ComponentModel;
using System.Diagnostics;

using Xenko.Core;
using Xenko.Engine;

namespace Xenko.UI.Controls
{
    /// <summary>
    /// Represent a UI checkbox. A checkbox but can have two or three states depending on the <see cref="IsThreeState"/> property.
    /// </summary>
    [DataContract(nameof(CheckBox))]
    [DebuggerDisplay("CheckBox - Name={Name}")]
    [Display(category: InputCategory)]
    public class CheckBox : ToggleButton
    {
        private ISpriteProvider uncheckedMouseOverImage;
        private ISpriteProvider uncheckedMouseDownImage;
        private ISpriteProvider indeterminateMouseOverImage;
        private ISpriteProvider indeterminateMouseDownImage;
        private ISpriteProvider checkedMouseOverImage;
        private ISpriteProvider checkedMouseDownImage;

        /// <summary>
        /// Gets or sets the image displayed when the button is unchecked and the mouse is over.
        /// </summary>
        /// <userdoc>The image displayed when the button is unchecked and the mouse is over.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider UncheckedMouseOverImage
        {
            get { return uncheckedMouseOverImage; }
            set
            {
                if (CheckedImage == value)
                    return;

                uncheckedMouseOverImage = value;
                OnToggleImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the button is unchecked and the mouse is down.
        /// </summary>
        /// <userdoc>The image displayed when the button is unchecked and the mouse is down.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider UncheckedMouseDownImage
        {
            get { return uncheckedMouseDownImage; }
            set
            {
                if (CheckedImage == value)
                    return;

                uncheckedMouseDownImage = value;
                OnToggleImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the checkbox is checked and the mouse is over.
        /// </summary>
        /// <userdoc>The image displayed when the button is checked and the mosue is over.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider CheckedMouseOverImage
        {
            get { return checkedMouseOverImage; }
            set
            {
                if (CheckedImage == value)
                    return;

                checkedMouseOverImage = value;
                OnToggleImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the checkbox is checked and the mouse is down.
        /// </summary>
        /// <userdoc>The image displayed when the button is checked and the mouse is down.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider CheckedMouseDownImage
        {
            get { return checkedMouseDownImage; }
            set
            {
                if (CheckedImage == value)
                    return;

                checkedMouseDownImage = value;
                OnToggleImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the button state is undeterminate and the mouse is over.
        /// </summary>
        /// <userdoc>The image displayed when the button state is undeterminate and the mouse is over.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider IndeterminateMouseOverImage
        {
            get { return indeterminateMouseOverImage; }
            set
            {
                if (CheckedImage == value)
                    return;

                indeterminateMouseOverImage = value;
                OnToggleImageInvalidated();
            }
        }

        /// <summary>
        /// Gets or sets the image displayed when the button state is undeterminate and the mouse is down.
        /// </summary>
        /// <userdoc>The image displayed when the button state is undeterminate and the mouse is down.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(null)]
        public ISpriteProvider IndeterminateMouseDownImage
        {
            get { return indeterminateMouseDownImage; }
            set
            {
                if (CheckedImage == value)
                    return;

                indeterminateMouseDownImage = value;
                OnToggleImageInvalidated();
            }
        }
    }
}
