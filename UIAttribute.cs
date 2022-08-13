using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the UI behaviour for the associated member
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class UIAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="renderOption"></param>
        /// <param name="decimalPlaces"></param>
        /// <param name="preferredControl"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        public UIAttribute
        (
            UiRenderOption renderOption = UiRenderOption.SeparateTabExpanded,
            int decimalPlaces = 3,
            UiControlType preferredControl = UiControlType.None,
            string trueValue = "Yes",
            string falseValue = "No"
        )
        {
            RenderOption = renderOption;
            DecimalPlaces = decimalPlaces;
            PreferredControl = preferredControl;
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        /// <summary>
        /// The way the associated item should be rendered
        /// </summary>
        public UiRenderOption RenderOption { get; }

        /// <summary>
        /// The number of decimal places to show
        /// </summary>
        public int DecimalPlaces { get; }

        /// <summary>
        /// The preferred control to use when rendering the associated member
        /// </summary>
        public UiControlType PreferredControl { get; }

        /// <summary>
        /// The text to use for boolean TRUE values
        /// </summary>
        public string TrueValue { get; }

        /// <summary>
        /// The text to use for boolean FALSE values
        /// </summary>
        public string FalseValue { get; }
    }
}