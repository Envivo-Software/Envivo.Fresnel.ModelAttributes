// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: LicenseRef-proprietary=www.envivo.co.uk/fresnel-eula
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Envivo.Fresnel.ModelAttributes
{
    /// <summary>
    /// Declares the member names that are hidden in the UI
    /// </summary>
    public class HiddenMembersAttribute : Attribute
    {
        private readonly static Dictionary<string, string> _FrameworkMemberNameMap = CreateFrameworkMemberNameMap();
        private readonly Dictionary<string, string> _HiddenMemberNamesMap = new(StringComparer.OrdinalIgnoreCase);

        private static Dictionary<string, string> CreateFrameworkMemberNameMap()
        {
            // Note that the list also contains members from the Object:
            var namesToHide = new List<string>();

            namesToHide.AddRange(GetMethodNames(typeof(object)));
            namesToHide.AddRange(GetMethodNames(typeof(IDisposable)));
            namesToHide.AddRange(GetMethodNames(typeof(Array)));
            namesToHide.AddRange(GetMethodNames(typeof(IEnumerable<>)));
            namesToHide.AddRange(GetMethodNames(typeof(List<>)));
            namesToHide.AddRange(GetMethodNames(typeof(Dictionary<,>)));

            // Typed Arrays contain these:
            namesToHide.AddRange(new string[] { "Get", "Set" });

            // Records contain these:
            namesToHide.AddRange(new string[] { "Equals", "Equals_1", "<Clone>$" });

            var results =
                namesToHide
                .Distinct()
                .ToDictionary(n => n);
            return results;
        }

        private static IEnumerable<string> GetMethodNames(Type type)
        {
            const BindingFlags flags =
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.FlattenHierarchy;

            var memberNames = type.GetMembers(flags).Select(m => m.Name).Distinct().ToList();
            return memberNames;
        }

        /// <summary>
        /// The hidden names
        /// </summary>
        public string[] Names
        {
            get { return _HiddenMemberNamesMap.Values.ToArray(); }

            set
            {
                foreach (var name in value)
                {
                    _HiddenMemberNamesMap[name] = name;
                }
            }
        }

        /// <summary>
        /// Returns TRUE if the Member with the given name should be hidden
        /// </summary>
        /// <param name="memberName"></param>
        public bool Contains(string memberName) => _HiddenMemberNamesMap.GetValueOrDefault(memberName) != null;

        /// <summary>
        /// Returns TRUE if the Member with the given name is a Framework member
        /// </summary>
        /// <param name="memberName"></param>
        public bool ContainsFrameworkMember(string memberName) => _FrameworkMemberNameMap.GetValueOrDefault(memberName) != null;
    }
}