// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class UploadAttribute : Attribute
    {
        public UploadAttribute()
        {
        }

        public UploadAttribute(string accept)
        {
            this.Accept = accept;
        }

        public string Accept { get; set; }
    }
}