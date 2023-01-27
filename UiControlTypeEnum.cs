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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        None,

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Default,

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Text,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        TextArea,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Html,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Password,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Email,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Search,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Telephone,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        PostalCode,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Url,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Image,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Radio,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Switch,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Checkbox,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Date,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        DateTimeLocal,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Time,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        TimeDuration,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Month,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Week,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Color,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Number,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Currency,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Range,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        File,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Select,
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        Upload,
    }
}