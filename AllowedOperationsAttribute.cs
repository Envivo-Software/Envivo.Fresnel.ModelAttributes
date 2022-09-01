// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the operations that are allowed on the associaated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Method)]
    public class AllowedOperationsAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="canCreate"></param>
        /// <param name="canRead"></param>
        /// <param name="canModify"></param>
        /// <param name="canAdd"></param>
        /// <param name="canRemove"></param>
        /// <param name="canClear"></param>
        /// <param name="canInvoke"></param>
        public AllowedOperationsAttribute
        (
            bool canCreate = true,
            bool canRead = true,
            bool canModify = true,
            bool canAdd = true,
            bool canRemove = true,
            bool canClear = true,
            bool canInvoke = true
        )
        {
            this.CanCreate = canCreate;
            this.CanRead = canRead;
            this.CanModify = canModify;
            this.CanAdd = canAdd;
            this.CanRemove = canRemove;
            this.CanClear = canClear;
            this.CanInvoke = canInvoke;
        }

        /// <summary>
        /// Determines if the item can be created
        /// </summary>
        public bool CanCreate { get; }

        /// <summary>
        /// Determines if the item can be read
        /// </summary>
        public bool CanRead { get; }

        /// <summary>
        /// Determines if the item can be modified
        /// </summary>
        public bool CanModify { get; set; }

        /// <summary>
        /// Determines if items can be added
        /// </summary>
        public bool CanAdd { get; }

        /// <summary>
        /// Determines if items can be removed
        /// </summary>
        public bool CanRemove { get; }

        /// <summary>
        /// Determines if the item can be cleared
        /// </summary>
        public bool CanClear { get; }

        /// <summary>
        /// Determines if the item can be invoked
        /// </summary>
        public bool CanInvoke { get; }
    }
}