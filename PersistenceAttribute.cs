// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Delcares the persistence behaviour of the associated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Property)]
    public class PersistenceAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="isPersistable"></param>
        /// <param name="isLazyLoaded"></param>
        /// <param name="isPessimisticLockingAllowed"></param>
        /// <param name="isPessimisticLockingForced"></param>
        /// <param name="isImmutable"></param>
        /// <param name="backingFieldName"></param>
        public PersistenceAttribute
        (
            bool isPersistable,
            bool isLazyLoaded,
            bool isPessimisticLockingAllowed,
            bool isPessimisticLockingForced,
            bool isImmutable,
            string backingFieldName
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