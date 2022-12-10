using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    /// <summary>
    /// Used to configure a set of Domain Classes
    /// </summary>
    public abstract class ModelConfigBase
    {

        private Dictionary<Type, IClassConfiguration> _ClassConfigurations = new();

        /// <summary>
        /// Used to configure classes within the Domain Model
        /// </summary>
        public virtual void Configure()
        {
        }

        /// <summary>
        /// Returns a ClassConfiguration for the given class type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ClassConfiguration<T> ConfigureClass<T>()
            where T : class
        {
            var classConfiguration = new ClassConfiguration<T>();
            _ClassConfigurations.Add(typeof(T), classConfiguration);

            return classConfiguration;
        }

        /// <summary>
        /// Returns all custom Class Configurations
        /// </summary>
        public IDictionary<Type, IClassConfiguration> GetClassConfigurations()
        {
            return _ClassConfigurations;
        }
    }
}