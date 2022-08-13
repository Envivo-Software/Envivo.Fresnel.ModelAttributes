using System;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the visibility of the associated item
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Parameter)]
    public class VisibleAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="isVisible"></param>
        public VisibleAttribute(bool isVisible = true)
        {
            IsVisible = isVisible;
        }

        /// <summary>
        /// Determines if the item is visible in the UI
        /// </summary>
        public bool IsVisible { get; }
    }
}