// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the operations that are allowed on the associated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Method)]
    public class AllowedOperationsAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="canCreate"><inheritdoc cref="CanCreate" path="/summary"/></param>
        /// <param name="canRead"><inheritdoc cref="CanRead" path="/summary"/></param>
        /// <param name="canModify"><inheritdoc cref="CanModify" path="/summary"/></param>
        /// <param name="canAdd"><inheritdoc cref="CanAdd" path="/summary"/></param>
        /// <param name="canRemove"><inheritdoc cref="CanRemove" path="/summary"/></param>
        /// <param name="canClear"><inheritdoc cref="CanClear" path="/summary"/></param>
        /// <param name="canInvoke"><inheritdoc cref="CanInvoke" path="/summary"/></param>
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