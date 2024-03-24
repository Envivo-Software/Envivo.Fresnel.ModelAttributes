// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// The options for rendering objects and entities
    /// </summary>
    public enum UiRenderOption
    {
        /// <summary>
        /// The object is shown as a simple compact entry
        /// </summary>
        InlineSimple,

        /// <summary>
        /// The object's properties are expanded
        /// </summary>
        InlineExpanded,

        /// <summary>
        /// The object's properties are shown in a separate tab
        /// </summary>
        SeparateTabExpanded
    }
}