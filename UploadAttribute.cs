// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the UI behaviour for upload operations
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class UploadAttribute : Attribute
    {
        /// <inheritdoc/>
        public UploadAttribute()
        {
        }

        /// <inheritdoc/>
        public UploadAttribute(string accept)
        {
            this.Accept = accept;
        }

        /// <summary>
        /// A list of file-types that may be uploaded (e.g.".png, .jpg")
        /// </summary>
        public string Accept { get; set; }
    }
}