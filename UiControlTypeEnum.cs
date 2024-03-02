// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// The types of HTML controls that may be rendered
    /// </summary>
    public enum UiControlType
    {
        // These map to HTML5 field input types (mostly!)

        /// <inheritdoc/>
        None,

        /// <inheritdoc/>
        Default,

        /// <inheritdoc/>
        Text,
        /// <inheritdoc/>
        TextArea,
        /// <inheritdoc/>
        Html,
        /// <inheritdoc/>
        Password,
        /// <inheritdoc/>
        Email,
        /// <inheritdoc/>
        Search,
        /// <inheritdoc/>
        Telephone,
        /// <inheritdoc/>
        PostalCode,
        /// <inheritdoc/>
        Url,
        /// <inheritdoc/>
        Image,
        /// <inheritdoc/>
        Radio,
        /// <inheritdoc/>
        Switch,
        /// <inheritdoc/>
        Checkbox,
        /// <inheritdoc/>
        Date,
        /// <inheritdoc/>
        DateTimeLocal,
        /// <inheritdoc/>
        Time,
        /// <inheritdoc/>
        TimeDuration,
        /// <inheritdoc/>
        Month,
        /// <inheritdoc/>
        Week,
        /// <inheritdoc/>
        Color,
        /// <inheritdoc/>
        Number,
        /// <inheritdoc/>
        Currency,
        /// <inheritdoc/>
        Range,
        /// <inheritdoc/>
        File,
        /// <inheritdoc/>
        Select,
        /// <inheritdoc/>
        Upload,
    }
}