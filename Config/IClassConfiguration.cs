using System;
using System.Collections.Generic;
using System.Reflection;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    /// <summary>
    /// Contains all Attributes used to configure a Domain Class
    /// </summary>
    public interface IClassConfiguration
    {
        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class
        /// </summary>
        IEnumerable<Attribute> ClassAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class' Constructors
        /// </summary>
        IEnumerable<Attribute> ConstructorAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class Constructor's Parameters
        /// </summary>
        IDictionary<string, IEnumerable<Attribute>> ConstructorParameterAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class' Properties
        /// </summary>
        IDictionary<PropertyInfo, IEnumerable<Attribute>> PropertyAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class' Methods
        /// </summary>
        IDictionary<MethodInfo, IEnumerable<Attribute>> MethodAttributes { get; }

        /// Returns all Attributes that are applied to a Domain Class Method's Parameters
        IDictionary<MethodInfo, IDictionary<string, IEnumerable<Attribute>>> MethodParameterAttributes { get; }
    }
}