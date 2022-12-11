using System.Collections.Generic;
using System;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    /// <summary>
    /// Used to configure a set of Domain Classes
    /// </summary>
    public interface IModelConfig
    {
        /// <summary>
        /// Used to configure classes within the Domain Model
        /// </summary>
        public void Configure();

        /// <summary>
        /// Returns a ClassConfiguration for the given class type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ClassConfiguration<T> ConfigureClass<T>() where T : class;

        /// <summary>
        /// Returns all custom Class Configurations
        /// </summary>
        public IDictionary<Type, IClassConfiguration> GetClassConfigurations();
    }
}