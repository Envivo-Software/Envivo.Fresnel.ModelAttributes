using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public abstract class ModelConfigBase : IModelConfig
    {
        private Dictionary<Type, IClassConfiguration> _ClassConfigurations = new();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Configure()
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ClassConfiguration<T> ConfigureClass<T>()
            where T : class
        {
            var classConfiguration = new ClassConfiguration<T>();
            _ClassConfigurations.Add(typeof(T), classConfiguration);

            return classConfiguration;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ClassConfiguration<T> ConfigureClass<T>(Attribute attribute, params Attribute[] additionalAttributes)
            where T : class
        {
            var classConfiguration = new ClassConfiguration<T>();
            classConfiguration.AddClassAttributes(attribute, additionalAttributes);
            _ClassConfigurations.Add(typeof(T), classConfiguration);

            return classConfiguration;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IDictionary<Type, IClassConfiguration> GetClassConfigurations()
        {
            return _ClassConfigurations;
        }
    }
}