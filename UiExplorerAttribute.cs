// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the UI behaviour for the associated Class or Interface
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class UiExplorerAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="preferredSize"><inheritdoc cref="PreferredSize" path="/summary"/></param>
        public UiExplorerAttribute
        (
            UiExplorerSize preferredSize = UiExplorerSize.Default
        )
        {
            PreferredSize = preferredSize;
        }

        /// <summary>
        /// The preferred starting size for the Class
        /// </summary>
        public UiExplorerSize PreferredSize { get; }
    }
}
