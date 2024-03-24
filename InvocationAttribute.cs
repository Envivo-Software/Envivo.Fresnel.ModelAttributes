// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the actions allowed when invoking the associated member
    /// </summary>
    [Obsolete("Please use MethodAttribute instead")]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class InvocationAttribute : Attribute
    {
        /// <inheritdoc/>
        public InvocationAttribute()
        {
            this.PromptForUnsavedChanges = true;
        }

        /// <inheritdoc/>
        /// <param name="mustPrompt"><inheritdoc cref="PromptForUnsavedChanges" path="/summary"/></param>
        public InvocationAttribute(bool mustPrompt)
        {
            this.PromptForUnsavedChanges = mustPrompt;
        }

        /// <summary>
        /// Determines if the user should be prompted to save changes when the associated member is invoked
        /// </summary>
        public bool PromptForUnsavedChanges { get; set; }
    }
}