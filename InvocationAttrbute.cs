// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the actions allowed when invoking the associated member
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class InvocationAttrbute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public InvocationAttrbute()
        {
            this.PromptForUnsavedChanges = true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="mustPrompt"></param>
        public InvocationAttrbute(bool mustPrompt)
        {
            this.PromptForUnsavedChanges = mustPrompt;
        }

        /// <summary>
        /// Determines if the user should be prompted to save changes when the associated member is invoked
        /// </summary>
        public bool PromptForUnsavedChanges { get; set; }
    }
}