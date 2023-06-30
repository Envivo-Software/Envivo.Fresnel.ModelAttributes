// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;
using System.Numerics;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the visibility of the associated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Parameter)]
    public class VisibleAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="isVisible"></param>
        /// <param name="isVisibleInLibrary"></param>
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