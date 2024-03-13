// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the persistence behaviour of the associated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Property)]
    public class PersistenceAttribute : Attribute
    {
        /// <inheritdoc/>
        /// <param name="isPersistable"><inheritdoc cref="IsPersistable" path="/summary"/></param>
        /// <param name="isLazyLoaded"><inheritdoc cref="IsLazyLoaded" path="/summary"/></param>
        /// <param name="isPessimisticLockingAllowed"><inheritdoc cref="IsPessimisticLockingAllowed" path="/summary"/></param>
        /// <param name="isPessimisticLockingForced"><inheritdoc cref="IsPessimisticLockingForced" path="/summary"/></param>
        /// <param name="isImmutable"><inheritdoc cref="IsImmutable" path="/summary"/></param>
        /// <param name="backingFieldName"><inheritdoc cref="BackingFieldName" path="/summary"/></param>
        public PersistenceAttribute
        (
            bool isPersistable = true,
            bool isLazyLoaded = false,
            bool isPessimisticLockingAllowed = false,
            bool isPessimisticLockingForced = false,
            bool isImmutable = false,
            string backingFieldName = null
        )
        {
            IsPersistable = isPersistable;
            IsLazyLoaded = isLazyLoaded;
            IsPessimisticLockingAllowed = isPessimisticLockingAllowed;
            IsPessimisticLockingForced = isPessimisticLockingForced;
            IsImmutable = isImmutable;
            BackingFieldName = backingFieldName;
        }

        /// <summary>
        /// The object may be persisted
        /// </summary>
        public bool IsPersistable { get; set; }

        /// <summary>
        /// The property is loaded at the time of request
        /// </summary>
        public bool IsLazyLoaded { get; set; }

        /// <summary>
        /// The current user is allowed to lock the object before editing, thus preventing other users from modifying it
        /// </summary>
        public bool IsPessimisticLockingAllowed { get; set; }

        /// <summary>
        /// The object is locked before editing, preventing other users from modifying it
        /// </summary>
        public bool IsPessimisticLockingForced { get; set; }

        /// <summary>
        /// The given property may only be edited once. After saving, it can no longer be modified.
        /// </summary>
        public bool IsImmutable { get; set; }

        /// <summary>
        /// The backing field behind the given property.
        /// </summary>
        public string BackingFieldName { get; set; }
    }
}