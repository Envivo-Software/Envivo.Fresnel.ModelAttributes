// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the UI behaviour for the associated member
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class UIAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="renderOption"><inheritdoc cref="RenderOption" path="/summary"/></param>
        /// <param name="decimalPlaces"><inheritdoc cref="DecimalPlaces" path="/summary"/></param>
        /// <param name="preferredControl"><inheritdoc cref="PreferredControl" path="/summary"/></param>
        /// <param name="trueValue"><inheritdoc cref="TrueValue" path="/summary"/></param>
        /// <param name="falseValue"><inheritdoc cref="FalseValue" path="/summary"/><param>
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