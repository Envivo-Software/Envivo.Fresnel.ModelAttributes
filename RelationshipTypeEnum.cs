// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// The types of relationships between objects
    /// </summary>
    public enum RelationshipType
    {
        /// <summary>
        /// The relationship has not been specified
        /// </summary>
        Unspecified,

        /// <summary>
        /// Aka Aggregation. This object is related to the property's content(s). Deleting this object will not affect these contents.
        /// </summary>
        Has,

        /// <summary>
        /// Aka Composition. This object owns the properties content(s) . Deleting this object should delete the contents too.
        /// </summary>
        Owns,

        /// <summary>
        /// This object is owned by the property's content. This is only relevant for objects, not collections.
        /// </summary>
        OwnedBy
    }
}