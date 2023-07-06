// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the actions allowed when invoking the associated method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public MethodAttribute()
        {
            this.PromptForUnsavedChanges = true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="mustPrompt"></param>
        public MethodAttribute(bool mustPrompt)
        {
            this.PromptForUnsavedChanges = mustPrompt;
        }

        /// <summary>
        /// Determines if the user should be prompted to save changes when the associated method is invoked
        /// </summary>
        public bool PromptForUnsavedChanges { get; set; }

        /// <summary>
        /// The name of the Property that the associated method should be rendered
        /// </summary>
        public string RelatedPropertyName { get; set; }
    }
}