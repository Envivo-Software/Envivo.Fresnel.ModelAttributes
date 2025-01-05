// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the visibility of the associated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Parameter)]
    public class VisibleAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="isVisible"><inheritdoc cref="IsVisible" path="/summary"/></param>
        /// <param name="isVisibleInLibrary"><inheritdoc cref="IsVisibleInLibrary" path="/summary"/></param>
        public VisibleAttribute(bool isVisible = true, bool isVisibleInLibrary = true)
        {
            IsVisible = isVisible;
            IsVisibleInLibrary = isVisibleInLibrary;
        }

        /// <summary>
        /// Determines if the item is visible in the UI
        /// </summary>
        public bool IsVisible { get; }

        /// <summary>
        /// Determines if the item is visible in the Library panel
        /// </summary>
        public bool IsVisibleInLibrary { get; }
    }
}