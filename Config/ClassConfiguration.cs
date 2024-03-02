using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    /// <summary>
    /// <inheritdoc cref="IClassConfiguration"/>
    /// </summary>
    /// <typeparam name="TClass">The Domain Class being configured</typeparam>
    public sealed class ClassConfiguration<TClass> : IClassConfiguration
        where TClass : class
    {
        private readonly List<Attribute> _ClassAttributes = new();

        private readonly List<Attribute> _ConstructorAttributes = new();
        private readonly Dictionary<string, List<Attribute>> _ConstructorParameterAttributes = new();

        private readonly Dictionary<string, List<Attribute>> _PropertyAttributes = new();

        private readonly Dictionary<string, List<Attribute>> _MethodAttributes = new();
        private readonly Dictionary<string, Dictionary<string, List<Attribute>>> _MethodParameterAttributes = new();

        /// <inheritdoc/>
        public IReadOnlyCollection<Attribute> ClassAttributes => _ClassAttributes;

        /// <inheritdoc/>
        public IReadOnlyCollection<Attribute> ConstructorAttributes => _ConstructorAttributes;

        /// <inheritdoc/>
        public IDictionary<string, IReadOnlyCollection<Attribute>> ConstructorParameterAttributes => AsDictionaryOfReadOnlyCollection(_ConstructorParameterAttributes);

        /// <inheritdoc/>
        public IDictionary<string, IReadOnlyCollection<Attribute>> PropertyAttributes => AsDictionaryOfReadOnlyCollection(_PropertyAttributes);

        /// <inheritdoc/>
        public IDictionary<string, IReadOnlyCollection<Attribute>> MethodAttributes => AsDictionaryOfReadOnlyCollection(_MethodAttributes);

        /// <inheritdoc/>
        public IDictionary<string, IDictionary<string, IReadOnlyCollection<Attribute>>> MethodParameterAttributes => AsDictionaryOfReadOnlyCollection(_MethodParameterAttributes);

        private IDictionary<TKey, IReadOnlyCollection<Attribute>> AsDictionaryOfReadOnlyCollection<TKey>(Dictionary<TKey, List<Attribute>> values)
        {
            return
                values
                .ToDictionary(i => i.Key,
                              i => (IReadOnlyCollection<Attribute>)i.Value.AsReadOnly());
        }

        private IDictionary<TKey, IDictionary<string, IReadOnlyCollection<Attribute>>> AsDictionaryOfReadOnlyCollection<TKey>(Dictionary<TKey, Dictionary<string, List<Attribute>>> values)
        {
            var stagingDict =
                values
                .Select(i =>
                {
                    var innerDictionary =
                        i.Value
                        .ToDictionary(i => i.Key, i => (IReadOnlyCollection<Attribute>)i.Value.AsReadOnly());

                    return new
                    {
                        i.Key,
                        InnerDictionary = (IDictionary<string, IReadOnlyCollection<Attribute>>)innerDictionary
                    };
                })
                .ToList();

            var result =
                stagingDict
                .ToDictionary(i => i.Key, i => i.InnerDictionary);

            return result;
        }

        /// <summary>
        /// Applies the given attributes to the Class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="additionalAttributes"></param>
        /// <returns></returns>
        public ClassConfiguration<TClass> WithAttributes(Attribute attribute, params Attribute[] additionalAttributes)
        {
            _ClassAttributes.Add(attribute);
            _ClassAttributes.AddRange(additionalAttributes);
            return this;
        }

        /// <summary>
        /// Applies the given attributes to the Class' Constructors
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="additionalAttributes"></param>
        /// <returns></returns>
        public ClassConfiguration<TClass> Constructor(Attribute attribute, params Attribute[] additionalAttributes)
        {
            _ConstructorAttributes.Add(attribute);
            _ConstructorAttributes.AddRange(additionalAttributes);
            return this;
        }

        /// <summary>
        /// Applies the given attributes to the named Constructor Parameter 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="attribute"></param>
        /// <param name="additionalAttributes"></param>
        /// <returns></returns>
        public ClassConfiguration<TClass> ConstructorParameter(string parameterName, Attribute attribute, params Attribute[] additionalAttributes)
        {
            var cachedAttributes = _ConstructorParameterAttributes.GetValueOrDefault(parameterName);
            if (cachedAttributes == null)
            {
                cachedAttributes = new List<Attribute>();
                _ConstructorParameterAttributes.Add(parameterName, cachedAttributes);
            }
            _ConstructorAttributes.Add(attribute);
            _ConstructorAttributes.AddRange(additionalAttributes);

            return this;
        }

        /// <summary>
        /// Applies the given attributes to the given Property lambda
        /// </summary>
        /// <param name="propIdentifier"></param>
        /// <param name="attribute"></param>
        /// <param name="additionalAttributes"></param>
        /// <returns></returns>
        public ClassConfiguration<TClass> Property(Expression<Func<TClass, object>> propIdentifier, Attribute attribute, params Attribute[] additionalAttributes)
        {
            var propInfo = propIdentifier.GetPropertyInfo();

            var cachedAttributes = _PropertyAttributes.GetValueOrDefault(propInfo.Name);
            if (cachedAttributes == null)
            {
                cachedAttributes = new List<Attribute>();
                _PropertyAttributes.Add(propInfo.Name, cachedAttributes);
            }
            cachedAttributes.Add(attribute);
            cachedAttributes.AddRange(additionalAttributes);

            return this;
        }

        /// <summary>
        /// Applies the given attributes to the given Method lambda
        /// </summary>
        /// <param name="methodIdentifier"></param>
        /// <param name="attribute"></param>
        /// <param name="additionalAttributes"></param>
        /// <returns></returns>
        public ClassConfiguration<TClass> Method(Expression<Func<TClass, Delegate>> methodIdentifier, Attribute attribute, params Attribute[] additionalAttributes)
        {
            var methodInfo = methodIdentifier.GetMethodInfo();

            var cachedAttributes = _MethodAttributes.GetValueOrDefault(methodInfo.Name);
            if (cachedAttributes == null)
            {
                cachedAttributes = new List<Attribute>();
                _MethodAttributes.Add(methodInfo.Name, cachedAttributes);
            }
            cachedAttributes.Add(attribute);
            cachedAttributes.AddRange(additionalAttributes);

            return this;
        }

        /// <summary>
        /// Applies the given attributes to the named Method Parameter
        /// </summary>
        /// <param name="methodIdentifier"></param>
        /// <param name="parameterName"></param>
        /// <param name="attribute"></param>
        /// <param name="additionalAttributes"></param>
        /// <returns></returns>
        public ClassConfiguration<TClass> MethodParameter(Expression<Func<TClass, Delegate>> methodIdentifier, string parameterName, Attribute attribute, params Attribute[] additionalAttributes)
        {
            var methodInfo = methodIdentifier.GetMethodInfo();

            var methodAttributes = _MethodParameterAttributes.GetValueOrDefault(methodInfo.Name);
            if (methodAttributes == null)
            {
                methodAttributes = new Dictionary<string, List<Attribute>>();
                _MethodParameterAttributes.Add(methodInfo.Name, methodAttributes);
            }

            var cachedAttributes = methodAttributes.GetValueOrDefault(parameterName);
            if (cachedAttributes == null)
            {
                cachedAttributes = new List<Attribute>();
                methodAttributes.Add(parameterName, cachedAttributes);
            }
            cachedAttributes.Add(attribute);
            cachedAttributes.AddRange(additionalAttributes);

            return this;
        }

        internal void AddClassAttributes(Attribute attribute, Attribute[] additionalAttributes)
        {
            if (attribute != null)
            {
                _ClassAttributes.Add(attribute);
            }

            if (additionalAttributes?.Any() == true)
            {
                _ClassAttributes.AddRange(additionalAttributes);
            }
        }
    }
}