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
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="specificationType"></param>
        public FilterQuerySpecificationAttribute(Type specificationType = null, bool runWhenContextChanges = false)
        {
            this.SpecificationType = specificationType;
            this.RunWhenContextChanges = runWhenContextChanges;
        }

        /// <summary>
        /// The type of the <c>IQuerySpecification</c> used for this member 
        /// </summary>
        public Type SpecificationType { get; }

        /// <summary>
        /// Determines if the <c>IQuerySpecification</c> should be run whenever the parent object's values change
        /// </summary>
        public bool RunWhenContextChanges { get; }
    }
}