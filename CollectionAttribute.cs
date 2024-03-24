// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the methods and properties used when interacting with Collections
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CollectionAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="addMethodName"><inheritdoc cref="AddMethodName" path="/summary"/></param>
        /// <param name="removeMethodName"><inheritdoc cref="RemoveMethodName" path="/summary"/></param>
        /// <param name="visibleColumnNames"><inheritdoc cref="VisibleColumnNames" path="/summary"/></param>
        /// <param name="canExpandRows"><inheritdoc cref="CanExpandRows" path="/summary"/></param>
        public CollectionAttribute
        (
            string addMethodName = null,
            string removeMethodName = null,
            string[] visibleColumnNames = null,
            bool canExpandRows = false)
        {
            AddMethodName = addMethodName;
            RemoveMethodName = removeMethodName;
            VisibleColumnNames = visibleColumnNames ?? Array.Empty<string>();
            CanExpandRows = canExpandRows;
        }

        /// <summary>
        /// The name of the Method that adds an item to the collection
        /// </summary>
        public string AddMethodName { get; set; }

        /// <summary>
        /// The name of the Method that removes an item from the collection
        /// </summary>
        public string RemoveMethodName { get; set; }

        /// <summary>
        /// Optional: The properties shown when rendered as a table
        /// </summary>
        public string[] VisibleColumnNames { get; set; }

        /// <summary>
        /// Determines if the table rows can be expanded
        /// </summary>
        public bool CanExpandRows { get; set; }
    }
}