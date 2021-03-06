// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xenko.Core;
using Xenko.Core.Annotations;
using Xenko.Core.Collections;
using Xenko.Core.Mathematics;
using Xenko.Games;
using Xenko.UI.Renderers;

namespace Xenko.UI
{
    /// <summary>
    /// Provides a base class for all the User Interface elements in Xenko applications.
    /// </summary>
    [DataContract(Inherited = true)]
    [CategoryOrder(10, AppearanceCategory, Expand = ExpandRule.Auto)]
    [CategoryOrder(20, BehaviorCategory, Expand = ExpandRule.Auto)]
    [CategoryOrder(30, LayoutCategory, Expand = ExpandRule.Auto)]
    [CategoryOrder(100, MiscCategory, Expand = ExpandRule.Auto)]
    [DebuggerDisplay("UIElement: {Name}")]
    public abstract partial class UIElement : IUIElementUpdate, IUIElementChildren, IIdentifiable
    {
        // Categories of UI element classes
        protected const string InputCategory = "Input";
        protected const string PanelCategory = "Panel";
        // Categories of UI element properties
        protected const string AppearanceCategory = "Appearance";
        protected const string BehaviorCategory = "Behavior";
        protected const string LayoutCategory = "Layout";
        protected const string MiscCategory = "Misc";

        protected const int Dims = 2;

        internal ElementRenderer Renderer;
        internal Vector3 RenderSizeInternal;
        internal Matrix WorldMatrixInternal;
        protected internal Thickness MarginInternal;

        private string name;
        private Color backgroundColor;
        private Visibility visibility = Visibility.Visible;
        private float opacity = 1.0f;
        private bool isEnabled = true;
        private bool isHierarchyEnabled = true;
        private bool isDirty;
        private float defaultWidth;
        private float defaultHeight;
        private float width = float.NaN;
        private float height = float.NaN;
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.Stretch;
        private VerticalAlignment verticalAlignment = VerticalAlignment.Stretch;
        private float maximumWidth = float.MaxValue;
        private float maximumHeight = float.MaxValue;
        private float minimumWidth;
        private float minimumHeight;
        private Matrix localMatrix = Matrix.Identity;
        private Matrix localMatrixPicking = Matrix.Identity;
        private Matrix worldMatrixPicking;
        private bool localMatrixNotIdentity;
        private MouseOverState mouseOverState;
        private LayoutingContext layoutingContext;

        protected bool ArrangeChanged;
        protected bool LocalMatrixChanged;

        private Vector2 previousProvidedMeasureSize = new Vector2(-1);
        private Vector2 previousProvidedArrangeSize = new Vector2(-11);
        private bool previousIsParentCollapsed;

        /// <summary>
        /// Creates a new instance of <see cref="UIElement"/>.
        /// </summary>
        protected UIElement()
        {
            Id = Guid.NewGuid();
            DependencyProperties = new PropertyContainerClass(this);
            VisualChildrenCollection = new UIElementCollection();
        }

        /// <summary>
        /// The <see cref="UIElement"/> that currently has the focus.
        /// </summary>
        internal static UIElement FocusedElement { get; set; }

        /// <summary>
        /// The <see cref="UIElement"/> that is captured for touch events.
        /// </summary>
        public static UIElement TouchCapturedElement { get; set; }

        /// <summary>
        /// A unique ID defining the UI element.
        /// </summary>
        /// <userdoc>A unique ID defining the UI element.</userdoc>
        [DataMember]
        [Display(Browsable = false)]
        [NonOverridable]
        public Guid Id { get; set; }

        /// <summary>
        /// The list of the dependency properties attached to the UI element.
        /// </summary>
        /// <userdoc>The list of the dependency properties attached to the UI element.</userdoc>
        [DataMember]
        public PropertyContainerClass DependencyProperties { get; }

        /// <summary>
        /// Gets or sets the LocalMatrix of this element.
        /// </summary>
        /// <remarks>The local transform is not taken is account during the layering. The transformation is purely for rendering effects.</remarks>
        /// <userdoc>Local matrix of this element.</userdoc>
        [DataMemberIgnore]
        public Matrix LocalMatrix
        {
            get => localMatrix;
            set
            {
                localMatrix = value;
                localMatrixNotIdentity = !value.IsIdentity;

                // Picking (see XK-4689) - this fix relates to the inverted axis introduced in
                //  UIRenderFeature.PickingUpdate(RenderUIElement renderUIElement, Viewport viewport, ref Matrix worldViewProj, GameTime drawTime)
                localMatrixPicking = value;
                localMatrixPicking.M13 *= -1;
                localMatrixPicking.M31 *= -1;
                localMatrixPicking.M23 *= -1;
                localMatrixPicking.M32 *= -1;

                LocalMatrixChanged = true;
            }
        }

        /// <summary>
        /// The background color of the element.
        /// </summary>
        /// <userdoc>Color used for the background surface of this element.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                if (value == backgroundColor)
                    return;
                backgroundColor = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the opacity factor applied to the entire UIElement when it is rendered in the user interface (UI).
        /// </summary>
        /// <remarks>The value is coerced in the range [0, 1].</remarks>
        /// <userdoc>Opacity factor applied to this element when rendered in the user interface (UI).</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 1.0f, 0.01f, 0.1f, 2)]
        [Display(category: AppearanceCategory)]
        [DefaultValue(1.0f)]
        public float Opacity
        {
            get => opacity;
            set
            {
                if (float.IsNaN(value))
                    return;
                opacity = MathUtil.Clamp(value, 0.0f, 1.0f);
            }
        }

        /// <summary>
        /// Gets or sets the user interface (UI) visibility of this element.
        /// </summary>
        /// <userdoc>Visibility of this element.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(Visibility.Visible)]
        public Visibility Visibility
        {
            get => visibility;
            set
            {
                if (value == visibility)
                    return;

                // not all changes need to invalidate measure
                var invalidateMeasure = IsCollapsed || value == Visibility.Collapsed;

                visibility = value;

                if (invalidateMeasure)
                    InvalidateMeasure();

                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to clip the content of this element (or content coming from the child elements of this element)
        /// to fit into the size of the containing element.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The value has to be positive and finite.</exception>
        /// <userdoc>Indicates whether to clip the content of this element (or content coming from the child elements of this element).</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(false)]
        public bool ClipToBounds { get; set; }

        /// <summary>
        /// The number of layers used to draw this element.
        /// This value has to be modified by the user when he redefines the default element renderer,
        /// so that <see cref="DepthBias"/> values of the relatives keeps enough spaces to draw the different layers.
        /// </summary>
        /// <userdoc>The number of layers used to draw this element.</userdoc>
        [DataMember]
        [Display(category: AppearanceCategory)]
        [DefaultValue(1)]
        public int DrawLayerNumber { get; set; } = 1; // one layer for BackgroundColor/Clipping

        /// <summary>
        /// Gets or sets a value indicating whether this element is enabled in the user interface (UI).
        /// </summary>
        /// <userdoc>True if this element is enabled, False otherwise.</userdoc>
        [DataMember]
        [Display(category: BehaviorCategory)]
        [DefaultValue(true)]
        public virtual bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (value == isEnabled)
                    return;
                isEnabled = value;
                MouseOverState = MouseOverState.MouseOverNone;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Indicate if the UIElement can be hit by the user.
        /// If this property is true, the UI system performs hit test on the UIElement.
        /// </summary>
        /// <userdoc>True if the UI system should perform hit test on this element, False otherwise.</userdoc>
        [DataMember]
        [Display(category: BehaviorCategory)]
        [DefaultValue(false)]
        public bool CanBeHitByUser { get; set; }

        /// <summary>
        /// Gets or sets the user suggested width of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Width of this element. If NaN, the default width will be used instead.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(float.NaN)]
        public float Width
        {
            get => width;
            set
            {
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == width)
                    return;
                width = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the user suggested height of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Height of this element. If NaN, the default height will be used instead.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(float.NaN)]
        public float Height
        {
            get => height;
            set
            {
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == height)
                    return;
                height = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the size of the element. Same as setting separately <see cref="Width"/>, and <see cref="Height"/>/>
        /// </summary>
        [DataMemberIgnore]
        public Vector2 Size
        {
            get => new Vector2(width, height);
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the horizontal alignment of this element.
        /// </summary>
        /// <userdoc>Horizontal alignment of this element.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(HorizontalAlignment.Stretch)]
        public HorizontalAlignment HorizontalAlignment
        {
            get => horizontalAlignment;
            set
            {
                if (value == horizontalAlignment)
                    return;
                horizontalAlignment = value;
                InvalidateArrange();
            }
        }

        /// <summary>
        /// Gets or sets the vertical alignment of this element.
        /// </summary>
        /// <userdoc>Vertical alignment of this element.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        [DefaultValue(VerticalAlignment.Stretch)]
        public VerticalAlignment VerticalAlignment
        {
            get => verticalAlignment;
            set
            {
                if (value == verticalAlignment)
                    return;
                verticalAlignment = value;
                InvalidateArrange();
            }
        }

        /// <summary>
        /// Gets or sets the margins of this element.
        /// </summary>
        /// <userdoc>Layout margin of this element.</userdoc>
        [DataMember]
        [Display(category: LayoutCategory)]
        public Thickness Margin
        {
            get => MarginInternal;
            set
            {
                MarginInternal = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the minimum width of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Minimum width of this element.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(0.0f)]
        public float MinimumWidth
        {
            get => minimumWidth;
            set
            {
                if (float.IsNaN(value))
                    return;
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == minimumWidth)
                    return;
                minimumWidth = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the minimum height of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Minimum height of this element.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(0.0f)]
        public float MinimumHeight
        {
            get => minimumHeight;
            set
            {
                if (float.IsNaN(value))
                    return;
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == minimumHeight)
                    return;
                minimumHeight = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the maximum width of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Maximum width of this element.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(float.MaxValue)]
        public float MaximumWidth
        {
            get => maximumWidth;
            set
            {
                if (float.IsNaN(value))
                    return;
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == maximumWidth)
                    return;
                maximumWidth = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the maximum height of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Maximum height of this element.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(float.MaxValue)]
        public float MaximumHeight
        {
            get => maximumHeight;
            set
            {
                if (float.IsNaN(value))
                    return;
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == maximumHeight)
                    return;
                maximumHeight = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the default width of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Default width of this element.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(0.0f)]
        public float DefaultWidth
        {
            get => defaultWidth;
            set
            {
                if (float.IsNaN(value))
                    return;
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == defaultWidth)
                    return;
                defaultWidth = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the default height of this element.
        /// </summary>
        /// <remarks>The value is coerced in the range [0, <see cref="float.MaxValue"/>].</remarks>
        /// <userdoc>Default height of this element.</userdoc>
        [DataMember]
        [DataMemberRange(0.0f, 3)]
        [Display(category: LayoutCategory)]
        [DefaultValue(0.0f)]
        public float DefaultHeight
        {
            get => defaultHeight;
            set
            {
                if (float.IsNaN(value))
                    return;
                value = MathUtil.Clamp(value, 0.0f, float.MaxValue);
                if (value == defaultHeight)
                    return;
                defaultHeight = value;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// Gets or sets the name of this element.
        /// </summary>
        /// <userdoc>Name of this element.</userdoc>
        [DataMember]
        [Display(category: MiscCategory)]
        [DefaultValue(null)]
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;

                name = value;
                OnNameChanged();
            }
        }

        /// <summary>
        /// Indicate if the UIElement acts as a top level element for the IsDirty flag.
        /// If this property is true, the UI system sets this element's IsDirty to true when a child's IsDirty is set true.
        /// </summary>
        [DataMember]
        [Display(category: BehaviorCategory)]
        [DefaultValue(false)]
        public bool IsTopLevelDirty { get; set; }

        [DataMemberIgnore]
        public bool IsDirty
        {
            get => isDirty;
            set
            {
                if (value != isDirty)
                {
                    isDirty = value;
                    if (value)
                        PropagateIsDirtyToTopLevel();
                }
            }
        }

        [DataMemberIgnore]
        public Rectangle Bounds { get; set; }

        /// <summary>
        /// Gets the size that this element computed during the measure pass of the layout process.
        /// </summary>
        /// <remarks>This value does not contain possible <see cref="Margin"/></remarks>
        [DataMemberIgnore]
        public Vector2 DesiredSize { get; private set; }

        /// <summary>
        /// Gets the size that this element computed during the measure pass of the layout process.
        /// </summary>
        /// <remarks>This value contains possible <see cref="Margin"/></remarks>
        [DataMemberIgnore]
        public Vector2 DesiredSizeWithMargins { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the computed size and position of child elements in this element's layout are valid.
        /// </summary>
        [DataMemberIgnore]
        public bool IsArrangeValid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the current size returned by layout measure is valid.
        /// </summary>
        [DataMemberIgnore]
        public bool IsMeasureValid { get; private set; }

        /// <summary>
        /// The world matrix of the UIElement.
        /// The origin of the element is the center of the object's bounding box defined by <see cref="RenderSize"/>.
        /// </summary>
        [DataMemberIgnore]
        public Matrix WorldMatrix
        {
            get => WorldMatrixInternal;
            private set => WorldMatrixInternal = value;
        }

        /// <summary>
        /// The final depth bias value of the element resulting from the parent/children z order update.
        /// </summary>
        [DataMemberIgnore]
        public int DepthBias { get; private set; }

        /// <summary>
        /// The maximum depth bias value among the children of the element resulting from the parent/children z order update.
        /// </summary>
        public int MaxChildrenDepthBias { get; private set; }

        internal bool ForceNextMeasure = true;
        internal bool ForceNextArrange = true;

        /// <summary>
        /// The ratio between the element real size on the screen and the element virtual size.
        /// </summary>
        [DataMemberIgnore]
        public LayoutingContext LayoutingContext
        {
            get => layoutingContext;
            set
            {
                if (value == null)
                    return;

                if (layoutingContext != null && layoutingContext.Equals(value))
                    return;

                ForceMeasure();
                layoutingContext = value;
                foreach (var child in VisualChildren)
                    child.LayoutingContext = value;
            }
        }

        private UIElementServices uiElementServices;

        [DataMemberIgnore]
        public UIElementServices UIElementServices
        {
            get
            {
                if (Parent != null && !Parent.UIElementServices.Equals(ref uiElementServices))
                    uiElementServices = Parent.UIElementServices;

                return uiElementServices;
            }
            set
            {
                if (Parent != null)
                    throw new InvalidOperationException("Can only assign UIElementService to the root element!");

                uiElementServices = value;
            }
        }

        /// <summary>
        /// The visual children of this element.
        /// </summary>
        /// <remarks>If the class is inherited it is the responsibility of the descendant class to correctly update this collection</remarks>
        [DataMemberIgnore]
        public UIElementCollection VisualChildrenCollection { get; }

        /// <summary>
        /// Gets or sets the object that contains data about the UIElement.
        /// </summary>
        [DataMemberIgnore]
        public object Tag { get; set; }

        /// <summary>
        /// Invalidates the arrange state (layout) for the element.
        /// </summary>
        protected internal void InvalidateArrange()
        {
            ForceArrange(); // force arrange on top hierarchy

            PropagateArrangeInvalidationToChildren(); // propagate weak invalidation on children
        }

        private void PropagateArrangeInvalidationToChildren()
        {
            foreach (var child in VisualChildrenCollection)
            {
                if (!child.IsArrangeValid)
                    continue;

                child.IsArrangeValid = false;
                child.PropagateArrangeInvalidationToChildren();
            }
        }

        private void ForceArrange()
        {
            if (ForceNextArrange) // no need to propagate arrange force if it's already done
                return;

            IsArrangeValid = false;
            ForceNextArrange = true;

            VisualParent?.ForceArrange();
        }

        /// <summary>
        /// Invalidates the measurement state (layout) for the element.
        /// </summary>
        protected internal void InvalidateMeasure()
        {
            ForceMeasure(); // force measure on top hierarchy

            PropagateMeasureInvalidationToChildren(); // propagate weak invalidation on children
        }

        private void PropagateMeasureInvalidationToChildren()
        {
            foreach (var child in VisualChildrenCollection)
            {
                if (child.IsMeasureValid)
                {
                    child.IsMeasureValid = false;
                    child.IsArrangeValid = false;
                    child.PropagateMeasureInvalidationToChildren();
                }
            }
        }

        private void ForceMeasure()
        {
            if (ForceNextMeasure && ForceNextArrange) // no need to propagate arrange force if it's already done
                return;

            ForceNextMeasure = true;
            ForceNextArrange = true;

            IsMeasureValid = false;
            IsArrangeValid = false;

            VisualParent?.ForceMeasure();
        }

        /// <summary>
        /// This method is call when the name of the UIElement changes.
        /// This method can be overridden in inherited classes to perform class specific actions on <see cref="Name"/> changes.
        /// </summary>
        protected virtual void OnNameChanged()
        {
        }

        /// <summary>
        /// Gets the value indicating whether this element and all its upper hierarchy are enabled or not.
        /// </summary>
        public bool IsHierarchyEnabled => isHierarchyEnabled;

        /// <summary>
        /// Gets a value indicating whether this element is visible in the user interface (UI).
        /// </summary>
        public bool IsVisible => Visibility == Visibility.Visible;

        /// <summary>
        /// Gets a value indicating whether this element takes some place in the user interface.
        /// </summary>
        public bool IsCollapsed => Visibility == Visibility.Collapsed;

        /// <summary>
        /// Set one component of the size of the element.
        /// </summary>
        /// <param name="dimensionIndex">Index indicating which component to set</param>
        /// <param name="value">The value to give to the size</param>
        internal void SetSize(int dimensionIndex, float value)
        {
            if (dimensionIndex == 0)
                Width = value;
            else
                Height = value;
        }

        /// <summary>
        /// Gets the logical parent of this element.
        /// </summary>
        [DataMemberIgnore]
        [CanBeNull]
        public UIElement Parent { get; protected set; }

        /// <summary>
        /// Gets the visual parent of this element.
        /// </summary>
        [DataMemberIgnore]
        [CanBeNull]
        public UIElement VisualParent { get; protected set; }


        /// <summary>
        /// Get a enumerable to the visual children of the <see cref="UIElement"/>.
        /// </summary>
        /// <remarks>Inherited classes are in charge of overriding this method to return their children.</remarks>
        [DataMemberIgnore]
        public IReadOnlyList<UIElement> VisualChildren => VisualChildrenCollection;

        /// <summary>
        /// The list of the children of the element that can be hit by the user.
        /// </summary>
        [DataMemberIgnore]
        public virtual FastCollection<UIElement> HitableChildren => VisualChildrenCollection;

        /// <summary>
        /// The opacity used to render element.
        /// </summary>
        [DataMemberIgnore]
        public float RenderOpacity { get; private set; }

        /// <summary>
        /// Gets (or sets, but see Remarks) the final render size of this element.
        /// </summary>
        [DataMemberIgnore]
        public Vector3 RenderSize
        {
            get => RenderSizeInternal;
            private set => RenderSizeInternal = value;
        }

        /// <summary>
        /// The rendering offsets caused by the UIElement margins and alignments.
        /// </summary>
        [DataMemberIgnore]
        public Vector3 RenderOffsets { get; private set; }

        /// <summary>
        /// Gets the rendered width of this element.
        /// </summary>
        public float ActualWidth => RenderSize.X;

        /// <summary>
        /// Gets the rendered height of this element.
        /// </summary>
        public float ActualHeight => RenderSize.Y;

        /// <inheritdoc/>
        IEnumerable<IUIElementChildren> IUIElementChildren.Children => EnumerateChildren();

        /// <summary>
        /// Enumerates the children of this element.
        /// </summary>
        /// <returns>A sequence containing all the children of this element.</returns>
        /// <remarks>This method is used by the implementation of the <see cref="IUIElementChildren"/> interface.</remarks>
        protected virtual IEnumerable<IUIElementChildren> EnumerateChildren()
        {
            // Empty by default
            yield break;
        }

        private unsafe bool Vector2BinaryEqual(ref Vector2 left, ref Vector2 right)
        {
            fixed (Vector2* pVector2Left = &left)
            fixed (Vector2* pVector2Right = &right)
            {
                var pLeft = (int*)pVector2Left;
                var pRight = (int*)pVector2Right;

                return pLeft[0] == pRight[0] && pLeft[1] == pRight[1];
            }
        }

        public void Measure(Vector2 availableSizeWithMargins)
        {
            Measure(ref availableSizeWithMargins);
        }

        /// <summary>
        /// Updates the <see cref="DesiredSize"/> of a <see cref="UIElement"/>.
        /// Parent elements call this method from their own implementations to form a recursive layout update.
        /// Calling this method constitutes the first pass (the "Measure" pass) of a layout update.
        /// </summary>
        /// <param name="availableSizeWithMargins">The available space that a parent element can allocate a child element with its margins.
        /// A child element can request a larger space than what is available;  the provided size might be accommodated if scrolling is possible in the content model for the current element.</param>
        public void Measure(ref Vector2 availableSizeWithMargins)
        {
            if (!ForceNextMeasure && Vector2BinaryEqual(ref availableSizeWithMargins, ref previousProvidedMeasureSize))
            {
                IsMeasureValid = true;
                ValidateChildrenMeasure();
                return;
            }

            ForceNextMeasure = false;
            IsMeasureValid = true;
            IsArrangeValid = false;
            RequiresMouseOverUpdate = true;
            previousProvidedMeasureSize = availableSizeWithMargins;

            // avoid useless computation if the element is collapsed
            if (IsCollapsed)
            {
                DesiredSize = DesiredSizeWithMargins = Vector2.Zero;
                return;
            }

            // variable containing the temporary desired size
            var desiredSize = Size;

            // width, height or the depth of the UIElement might be undetermined
            // -> compute the desired size of the children to determine it

            // removes the size required for the margins in the available size
            var availableSizeWithoutMargins = CalculateSizeWithoutThickness(ref availableSizeWithMargins, ref MarginInternal);

            // clamp the available size for the element between the maximum and minimum width/height of the UIElement
            availableSizeWithoutMargins = new Vector2(
                MathUtil.Clamp(!float.IsNaN(desiredSize.X) ? desiredSize.X : availableSizeWithoutMargins.X, MinimumWidth, MaximumWidth),
                MathUtil.Clamp(!float.IsNaN(desiredSize.Y) ? desiredSize.Y : availableSizeWithoutMargins.Y, MinimumHeight, MaximumHeight));

            // compute the desired size for the children
            var childrenDesiredSize = MeasureOverride(ref availableSizeWithoutMargins);

            // replace the undetermined size by the desired size for the children
            // else override the element size by the default size if still unspecified
            if (float.IsNaN(desiredSize.X))
            {
                desiredSize.X = childrenDesiredSize.X;
                if (float.IsNaN(desiredSize.X))
                    desiredSize.X = DefaultWidth;
            }
            if (float.IsNaN(desiredSize.Y))
            {
                desiredSize.Y = childrenDesiredSize.Y;
                if (float.IsNaN(desiredSize.Y))
                    desiredSize.Y = DefaultHeight;
            }

            // clamp the desired size between the maximum and minimum width/height of the UIElement
            desiredSize = new Vector2(
                MathUtil.Clamp(desiredSize.X, MinimumWidth, MaximumWidth),
                MathUtil.Clamp(desiredSize.Y, MinimumHeight, MaximumHeight));

            // compute the desired size with margin
            var desiredSizeWithMargins = CalculateSizeWithThickness(ref desiredSize, ref MarginInternal);

            // update Element state variables
            DesiredSize = desiredSize;
            DesiredSizeWithMargins = new Vector2(desiredSizeWithMargins.X, (int)(desiredSizeWithMargins.Y + 0.5f));
        }

        private void ValidateChildrenMeasure()
        {
            foreach (var child in VisualChildrenCollection)
            {
                if (!child.IsMeasureValid)
                {
                    child.IsMeasureValid = true;
                    child.ValidateChildrenMeasure();
                }
            }
        }

        /// <summary>
        /// When overridden in a derived class, measures the size in layout required for possible child elements and determines a size for the <see cref="UIElement"/>-derived class.
        /// </summary>
        /// <param name="availableSizeWithoutMargins">The available size that this element can give to child elements.
        /// Infinity can be specified as a value to indicate that the element will size to whatever content is available.</param>
        /// <returns>The size desired by the children</returns>
        protected virtual Vector2 MeasureOverride(ref Vector2 availableSizeWithoutMargins)
        {
            return Vector2.Zero;
        }

        public void Arrange(Vector2 finalSizeWithMargins, bool isParentCollapsed)
        {
            Arrange(ref finalSizeWithMargins, isParentCollapsed);
        }

        /// <summary>
        /// Positions child elements and determines the size of the UIElement.
        /// This method constitutes the second pass of a layout update.
        /// </summary>
        /// <param name="finalSizeWithMargins">The final size that the parent computes for the child element with the margins.</param>
        /// <param name="isParentCollapsed">Boolean indicating if one of the parents of the element is currently collapsed.</param>
        public void Arrange(ref Vector2 finalSizeWithMargins, bool isParentCollapsed)
        {
            if (!ForceNextArrange && Vector2BinaryEqual(ref finalSizeWithMargins, ref previousProvidedArrangeSize) && isParentCollapsed == previousIsParentCollapsed)
            {
                IsArrangeValid = true;
                ValidateChildrenArrange();
                return;
            }

            ForceNextArrange = false;
            IsArrangeValid = true;
            ArrangeChanged = true;
            previousIsParentCollapsed = isParentCollapsed;
            previousProvidedArrangeSize = finalSizeWithMargins;
            RequiresMouseOverUpdate = true;

            // special to avoid useless computation if the element is collapsed
            if (IsCollapsed || isParentCollapsed)
            {
                CollapseOverride();
                return;
            }

            // initialize the element size with the user suggested size (maybe NaN if not set)
            var elementSize = Size;

            // stretch the element if the user size is unspecified and alignment constraints requires it
            // else override the element size by the desired size if still unspecified
            var finalSizeWithoutMargins = CalculateSizeWithoutThickness(ref finalSizeWithMargins, ref MarginInternal);
            if (float.IsNaN(elementSize.X))
            {
                if (HorizontalAlignment == HorizontalAlignment.Stretch)
                    elementSize.X = finalSizeWithoutMargins.X;
                else
                    elementSize.X = Math.Min(DesiredSize.X, finalSizeWithoutMargins.X);
            }
            if (float.IsNaN(elementSize.Y))
            {
                if (VerticalAlignment == VerticalAlignment.Stretch)
                    elementSize.Y = finalSizeWithoutMargins.Y;
                else
                    elementSize.Y = Math.Min(DesiredSize.Y, finalSizeWithoutMargins.Y);
            }

            // clamp the element size between the maximum and minimum width/height of the UIElement
            elementSize = new Vector2(
                MathUtil.Clamp(elementSize.X, MinimumWidth, MaximumWidth),
                MathUtil.Clamp(elementSize.Y, MinimumHeight, MaximumHeight));

            // let ArrangeOverride decide of the final taken size
            elementSize = ArrangeOverride(ref elementSize);

            // compute the rendering offsets
            var renderOffsets = CalculateAdjustmentOffsets(ref MarginInternal, ref finalSizeWithMargins, ref elementSize);

            // update UIElement internal variables
            RenderSize = new Vector3(elementSize, 0f);
            RenderOffsets = new Vector3(renderOffsets, 0f);
        }

        private void ValidateChildrenArrange()
        {
            foreach (var child in VisualChildrenCollection)
            {
                if (!child.IsArrangeValid)
                {
                    child.IsArrangeValid = true;
                    child.ValidateChildrenArrange();
                }
            }
        }

        /// <summary>
        /// When overridden in a derived class, positions possible child elements and determines a size for a <see cref="UIElement"/> derived class.
        /// </summary>
        /// <param name="finalSizeWithoutMargins">The final area within the parent that this element should use to arrange itself and its children.</param>
        /// <returns>The actual size used.</returns>
        protected virtual Vector2 ArrangeOverride(ref Vector2 finalSizeWithoutMargins)
        {
            return finalSizeWithoutMargins;
        }

        /// <summary>
        /// When overridden in a derived class, collapse possible child elements and derived class.
        /// </summary>
        protected virtual void CollapseOverride()
        {
            DesiredSize = Vector2.Zero;
            DesiredSizeWithMargins = Vector2.Zero;
            RenderSize = Vector3.Zero;
            RenderOffsets = Vector3.Zero;

            foreach (var child in VisualChildrenCollection)
                PropagateCollapseToChild(child);
        }

        /// <summary>
        /// Propagate the collapsing to a child element <paramref name="element"/>.
        /// </summary>
        /// <param name="element">A child element to which propagate the collapse.</param>
        /// <exception cref="InvalidOperationException"><paramref name="element"/> is not a child of this element.</exception>
        protected void PropagateCollapseToChild(UIElement element)
        {
            if (element.VisualParent != this)
                throw new InvalidOperationException("Element is not a child of this element.");

            element.InvalidateMeasure();
            element.CollapseOverride();
        }

        /// <summary>
        /// Propagate the IsDirty flag to the top level parent.
        /// </summary>
        private void PropagateIsDirtyToTopLevel()
        {
            if (IsTopLevelDirty)
            {
                isDirty = true;
                return;
            }

            VisualParent?.PropagateIsDirtyToTopLevel();
        }

        /// <summary>
        /// Finds an element that has the provided identifier name in the element children.
        /// </summary>
        /// <param name="name">The name of the requested element.</param>
        /// <returns>The requested element. This can be null if no matching element was found.</returns>
        /// <remarks>If several elements with the same name exist return the first found</remarks>
        public UIElement FindName(string name)
        {
            if (Name == name)
                return this;

            return VisualChildren.Select(child => child.FindName(name)).FirstOrDefault(elt => elt != null);
        }

        /// <summary>
        /// Set the parent to a child.
        /// </summary>
        /// <param name="child">The child to which set the parent.</param>
        /// <param name="parent">The parent of the child.</param>
        protected static void SetParent([NotNull] UIElement child, [CanBeNull] UIElement parent)
        {
            if (parent != null && child.Parent != null && parent != child.Parent)
                throw new InvalidOperationException("The UI element 'Name="+child.Name+"' has already as parent the element 'Name="+child.Parent.Name+"'.");

            child.Parent = parent;
        }

        /// <summary>
        /// Set the visual parent to a child.
        /// </summary>
        /// <param name="child">The child to which set the visual parent.</param>
        /// <param name="parent">The parent of the child.</param>
        protected static void SetVisualParent([NotNull] UIElement child, [CanBeNull] UIElement parent)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (parent != null && child.VisualParent != null && parent != child.VisualParent)
                throw new InvalidOperationException("The UI element 'Name=" + child.Name + "' has already as visual parent the element 'Name=" + child.VisualParent.Name + "'.");

            child.VisualParent?.VisualChildrenCollection.Remove(child);

            child.VisualParent = parent;

            if (parent != null)
            {
                child.LayoutingContext = parent.layoutingContext;
                parent.VisualChildrenCollection.Add(child);
            }
        }

        /// <summary>
        /// Calculate the intersection of the UI element and the ray.
        /// </summary>
        /// <param name="ray">The ray in world space coordinate</param>
        /// <param name="intersectionPoint">The intersection point in world space coordinate</param>
        /// <returns><value>true</value> if the two elements intersects, <value>false</value> otherwise</returns>
        public virtual bool Intersects(ref Ray ray, out Vector3 intersectionPoint)
        {
            // does ray intersect element Oxy face?
            return CollisionHelper.RayIntersectsRectangle(ref ray, ref worldMatrixPicking, ref RenderSizeInternal, out intersectionPoint);
        }

        void IUIElementUpdate.Update(GameTime time)
        {
            Update(time);

            foreach (var child in VisualChildrenCollection)
                ((IUIElementUpdate)child).Update(time);
        }

        void IUIElementUpdate.UpdateWorldMatrix(ref Matrix parentWorldMatrix, bool parentWorldChanged)
        {
            UpdateWorldMatrix(ref parentWorldMatrix, parentWorldChanged);
        }

        void IUIElementUpdate.UpdateElementState(int elementBias)
        {
            float parentRenderOpacity;
            bool parentIsHierarchyEnabled;

            var parent = VisualParent;
            if (parent != null)
            {
                parentRenderOpacity = parent.RenderOpacity;
                parentIsHierarchyEnabled = parent.IsHierarchyEnabled;
            }
            else
            {
                parentRenderOpacity = 1f;
                parentIsHierarchyEnabled = true;
            }

            RenderOpacity = parentRenderOpacity * Opacity;
            isHierarchyEnabled = parentIsHierarchyEnabled && isEnabled;
            DepthBias = elementBias;

            var currentElementDepthBias = DepthBias + DrawLayerNumber;

            foreach (var visualChild in VisualChildrenCollection)
            {
                ((IUIElementUpdate)visualChild).UpdateElementState(currentElementDepthBias);

                currentElementDepthBias = visualChild.MaxChildrenDepthBias + (visualChild.ClipToBounds ? visualChild.DrawLayerNumber : 0);
            }

            MaxChildrenDepthBias = currentElementDepthBias;
        }

        /// <summary>
        /// Method called by <see cref="IUIElementUpdate.Update"/>.
        /// This method can be overridden by inherited classes to perform time-based actions.
        /// This method is not in charge to recursively call the update on child elements, this is automatically done.
        /// </summary>
        /// <param name="time">The current time of the game</param>
        protected virtual void Update(GameTime time)
        {
            if (Parent != null && !Parent.UIElementServices.Equals(ref uiElementServices))
                uiElementServices = Parent.UIElementServices;
        }

        /// <summary>
        /// Method called by <see cref="IUIElementUpdate.UpdateWorldMatrix"/>.
        /// Parents are in charge of recursively calling this function on their children.
        /// </summary>
        /// <param name="parentWorldMatrix">The world matrix of the parent.</param>
        /// <param name="parentWorldChanged">Boolean indicating if the world matrix provided by the parent changed</param>
        protected virtual void UpdateWorldMatrix(ref Matrix parentWorldMatrix, bool parentWorldChanged)
        {
            if (parentWorldChanged || ArrangeChanged || LocalMatrixChanged)
            {
                var localMatrixCopy = localMatrix;

                // include rendering offsets into the local matrix.
                var translation = RenderOffsets + RenderSize / 2;
                localMatrixCopy.TranslationVector += translation;

                // calculate the world matrix of UIElement
                Matrix.Multiply(ref localMatrixCopy, ref parentWorldMatrix, out WorldMatrixInternal);

                if (localMatrixNotIdentity)
                {
                    localMatrixCopy = localMatrixPicking;
                    localMatrixCopy.TranslationVector += translation;
                    Matrix.Multiply(ref localMatrixCopy, ref parentWorldMatrix, out worldMatrixPicking);
                }
                else
                {
                    worldMatrixPicking = WorldMatrixInternal;
                }

                LocalMatrixChanged = false;
                ArrangeChanged = false;
            }
        }

        /// <summary>
        /// Add the thickness values into the size calculation of a UI element.
        /// </summary>
        /// <param name="sizeWithoutMargins">The size without the thickness included</param>
        /// <param name="thickness">The thickness to add to the space</param>
        /// <returns>The size with the margins included</returns>
        protected static Vector2 CalculateSizeWithThickness(ref Vector2 sizeWithoutMargins, ref Thickness thickness)
        {
            return new Vector2(
                    Math.Max(0, sizeWithoutMargins.X + thickness.TotalWidth),
                    Math.Max(0, sizeWithoutMargins.Y + thickness.TotalHeight));
        }

        /// <summary>
        /// Remove the thickness values into the size calculation of a UI element.
        /// </summary>
        /// <param name="sizeWithMargins">The size with the thickness included</param>
        /// <param name="thickness">The thickness to remove in the space</param>
        /// <returns>The size with the margins not included</returns>
        protected static Vector2 CalculateSizeWithoutThickness(ref Vector2 sizeWithMargins, ref Thickness thickness)
        {
            return new Vector2(
                    Math.Max(0, sizeWithMargins.X - thickness.TotalWidth),
                    Math.Max(0, sizeWithMargins.Y - thickness.TotalHeight));
        }

        /// <summary>
        /// Computes the (X,Y) offsets to position correctly the UI element given the total provided space to it.
        /// </summary>
        /// <param name="thickness">The thickness around the element to position.</param>
        /// <param name="providedSpace">The total space given to the child element by the parent</param>
        /// <param name="usedSpaceWithoutThickness">The space used by the child element without the thickness included in it.</param>
        /// <returns>The offsets</returns>
        protected Vector2 CalculateAdjustmentOffsets(ref Thickness thickness, ref Vector2 providedSpace, ref Vector2 usedSpaceWithoutThickness)
        {
            // compute the size of the element with the thickness included
            var usedSpaceWithThickness = CalculateSizeWithThickness(ref usedSpaceWithoutThickness, ref thickness);

            // set offset for left and stretch alignments
            var offsets = new Vector2(thickness.Left, thickness.Top);

            // align the element horizontally
            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Center:
                case HorizontalAlignment.Stretch:
                    offsets.X += (providedSpace.X - usedSpaceWithThickness.X) / 2;
                    break;
                case HorizontalAlignment.Right:
                    offsets.X += providedSpace.X - usedSpaceWithThickness.X;
                    break;
            }

            // align the element vertically
            switch (VerticalAlignment)
            {
                case VerticalAlignment.Center:
                case VerticalAlignment.Stretch:
                    offsets.Y += (providedSpace.Y - usedSpaceWithThickness.Y) / 2;
                    break;
                case VerticalAlignment.Bottom:
                    offsets.Y += providedSpace.Y - usedSpaceWithThickness.Y;
                    break;
            }

            return offsets;
        }
    }
}
