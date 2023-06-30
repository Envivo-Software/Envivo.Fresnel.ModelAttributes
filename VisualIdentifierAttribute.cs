﻿// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares how the class/member is visually identifed in the UI
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class VisualIdentifierAttribute : Attribute
    {
        public VisualIdentifierAttribute()
        {
        }

        /// <summary>
        /// The emoji or icon to be shown
        /// </summary>
        public string IconHtml { get; set; }

        /// <summary>
        /// The HTML colour to be used
        /// </summary>
        public string HtmlColour { get; set; }
    }
}