// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the <c>IQuerySpecification</c> used when selecting items for the associated member
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class FilterQuerySpecificationAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="specificationType"><inheritdoc cref="SpecificationType" path="/summary"/></param>
        public FilterQuerySpecificationAttribute(Type specificationType = null)
        {
            this.SpecificationType = specificationType;
        }

        /// <summary>
        /// The type of the <c>IQuerySpecification</c> used for this member 
        /// </summary>
        public Type SpecificationType { get; }
    }
}