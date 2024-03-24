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
        private static Dictionary<string, string> _FrameworkMemberNameMap = CreateFrameworkMemberNameMap();

        private List<string> _HiddenMemberNames = new List<string>();
        private Dictionary<string, string> _HiddenMemberNamesMap = new Dictionary<string, string>();

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
                .ToDictionary(n => n.ToLower());
            return results;
        }

        private static IEnumerable<string> GetMethodNames(Type type)
        {
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
            var memberNames = type.GetMembers(flags).Select(m => m.Name).ToList();

            return memberNames;
        }

        private void CacheHiddenMemberNames()
        {
            foreach (var name in _HiddenMemberNames)
            {
                _HiddenMemberNamesMap[name.ToLower()] = name;
            }
        }

        /// <summary>
        /// The hidden names
        /// </summary>
        public string[] Names
        {
            get { return _HiddenMemberNames.ToArray(); }

            set
            {
                // Instead of replacing the existing list, we'll append to it:
                _HiddenMemberNames.AddRange(value);
                foreach (var name in value)
                {
                    _HiddenMemberNamesMap[name.ToLower()] = name;
                }
            }
        }

        /// <summary>
        /// Returns TRUE if the Member with the given name should be hidden
        /// </summary>
        /// <param name="memberName"></param>
        public bool Contains(string memberName)
        {
            if (_HiddenMemberNamesMap.Count == 0)
            {
                this.CacheHiddenMemberNames();
            }

            return _HiddenMemberNamesMap.GetValueOrDefault(memberName.ToLower()) != null;
        }

        /// <summary>
        /// Returns TRUE if the Member with the given name is a Framework member
        /// </summary>
        /// <param name="memberName"></param>
        public bool ContainsFrameworkMember(string memberName)
        {
            return _FrameworkMemberNameMap.ContainsKey(memberName.ToLower());
        }
    }
}