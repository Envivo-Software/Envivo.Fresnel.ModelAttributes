using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public sealed class ClassConfiguration<TClass> : IClassConfiguration
        where TClass : class
    {
        private readonly List<Attribute> _ClassAttributes = new();

        private readonly List<Attribute> _ConstructorAttributes = new();
        private readonly Dictionary<string, List<Attribute>> _ConstructorParameterAttributes = new();

        private readonly Dictionary<PropertyInfo, List<Attribute>> _PropertyAttributes = new();

        private readonly Dictionary<MethodInfo, List<Attribute>> _MethodAttributes = new();
        private readonly Dictionary<MethodInfo, Dictionary<string, List<Attribute>>> _MethodParameterAttributes = new();

        public IEnumerable<Attribute> ClassAttributes => _ClassAttributes;

        public IEnumerable<Attribute> ConstructorAttributes => _ConstructorAttributes;

        public IDictionary<string, IEnumerable<Attribute>> ConstructorParameterAttributes => AsDictionaryOfIEnumerable(_ConstructorParameterAttributes);

        public IDictionary<PropertyInfo, IEnumerable<Attribute>> PropertyAttributes => AsDictionaryOfIEnumerable(_PropertyAttributes);

        public IDictionary<MethodInfo, IEnumerable<Attribute>> MethodAttributes => AsDictionaryOfIEnumerable(_MethodAttributes);

        public IDictionary<MethodInfo, IDictionary<string, IEnumerable<Attribute>>> MethodParameterAttributes => AsDictionaryOfIEnumerable(_MethodParameterAttributes);

        private IDictionary<TKey, IEnumerable<Attribute>> AsDictionaryOfIEnumerable<TKey>(Dictionary<TKey, List<Attribute>> values)
        {
            return
                values
                .ToDictionary(i => i.Key,
                              i => i.Value.AsEnumerable());
        }

        private IDictionary<TKey, IDictionary<string, IEnumerable<Attribute>>> AsDictionaryOfIEnumerable<TKey>(Dictionary<TKey, Dictionary<string, List<Attribute>>> values)
        {
            return
                values
                .ToDictionary(i => i.Key,
                              i => (IDictionary<string, IEnumerable<Attribute>>)i.Value.ToDictionary(j => j.Key, j => j.Value.AsEnumerable()));
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

            var cachedAttributes = _PropertyAttributes.GetValueOrDefault(propInfo);
            if (cachedAttributes == null)
            {
                cachedAttributes = new List<Attribute>();
                _PropertyAttributes.Add(propInfo, cachedAttributes);
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

            var cachedAttributes = _MethodAttributes.GetValueOrDefault(methodInfo);
            if (cachedAttributes == null)
            {
                cachedAttributes = new List<Attribute>();
                _MethodAttributes.Add(methodInfo, cachedAttributes);
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

            var methodAttributes = _MethodParameterAttributes.GetValueOrDefault(methodInfo);
            if (methodAttributes == null)
            {
                methodAttributes = new Dictionary<string, List<Attribute>>();
                _MethodParameterAttributes.Add(methodInfo, methodAttributes);
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

        public IEnumerable<Attribute> GetClassAttributes()
        {
            return _ClassAttributes;
        }

        public IDictionary<PropertyInfo, IEnumerable<Attribute>> GetPropertyAttributes()
        {
            var results =
                _PropertyAttributes
                .ToDictionary(kv => kv.Key, kv => kv.Value.AsEnumerable());
            return results;
        }

        public IDictionary<MethodInfo, IEnumerable<Attribute>> GetMethodAttributes()
        {
            var results =
                _MethodAttributes
                .ToDictionary(kv => kv.Key, kv => kv.Value.AsEnumerable());
            return results;
        }
    }
}