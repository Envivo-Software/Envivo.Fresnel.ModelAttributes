// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// The options for rendering objects and entities
    /// </summary>
    public enum UiRenderOption
    {
        /// <summary>
        /// The object is show as a single entry
        /// </summary>
        InlineSimple,

        /// <summary>
        /// The object's properties are expanded
        /// </summary>
        InlineExpanded,

        /// <summary>
        /// The object' properties are shown in a separate tab
        /// </summary>
        SeparateTabExpanded
    }
}