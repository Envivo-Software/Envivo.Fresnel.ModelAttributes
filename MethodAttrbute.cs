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
        /// <param name="relatedPropertyName"></param>
        /// <param name="mandatoryPromptText"></param>
        /// <param name="unsavedChangesPromptText"></param>
        public MethodAttribute
        (
            string relatedPropertyName = null,
            string mandatoryPromptText = null,
            string unsavedChangesPromptText = "There are unsaved changes. Save them before continuing?"
        )
        {
            RelatedPropertyName = relatedPropertyName;
            MandatoryPromptText = mandatoryPromptText;
            UnsavedChangesPromptText = unsavedChangesPromptText;
        }

        /// <summary>
        /// The name of the Property that the method should be rendered against
        /// </summary>
        public string RelatedPropertyName { get; set; }

        /// <summary>
        /// Displays this text before the method is invoked
        /// </summary>
        public string MandatoryPromptText { get; }

        /// <summary>
        /// Displays this text if the parent object has unsaved changes
        /// </summary>
        public string UnsavedChangesPromptText { get; }
    }
}