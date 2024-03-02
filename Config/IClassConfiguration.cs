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
        IReadOnlyCollection<Attribute> ClassAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class' Constructors
        /// </summary>
        IReadOnlyCollection<Attribute> ConstructorAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class Constructor's Parameters
        /// </summary>
        IDictionary<string, IReadOnlyCollection<Attribute>> ConstructorParameterAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class' Properties
        /// </summary>
        IDictionary<string, IReadOnlyCollection<Attribute>> PropertyAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class' Methods
        /// </summary>
        IDictionary<string, IReadOnlyCollection<Attribute>> MethodAttributes { get; }

        /// <summary>
        /// Returns all Attributes that are applied to a Domain Class Method's Parameters
        /// </summary>
        IDictionary<string, IDictionary<string, IReadOnlyCollection<Attribute>>> MethodParameterAttributes { get; }
    }
}