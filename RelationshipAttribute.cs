using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the type of relationship for the given property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class RelationshipAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="type"></param>
        public RelationshipAttribute(RelationshipType type = RelationshipType.Has)
        {
            this.Type = type;
        }

        /// <summary>
        /// The type of relationship
        /// </summary>
        public RelationshipType Type { get; set; }
    }
}