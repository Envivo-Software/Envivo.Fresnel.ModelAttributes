// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the methods to be used when interacting with Collections
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CollectionAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="addMethodName">The name of the Method that adds an item to the collection</param>
        /// <param name="removeMethodName">The name of the Method that removes an item to the collection</param>
        public CollectionAttribute
        (
            string addMethodName = null,
            string removeMethodName = null
        )
        {
            AddMethodName = addMethodName;
            RemoveMethodName = removeMethodName;
        }

        /// <summary>
        /// The name of the Method that adds an item to the collection
        /// </summary>
        public string AddMethodName { get; set; }

        /// <summary>
        /// The name of the Method that removes an item from the collection
        /// </summary>
        public string RemoveMethodName { get; set; }
    }
}