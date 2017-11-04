using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDebug.DebugPrefixes
{
    [CreateAssetMenu(fileName = "DebugPrefixes", menuName = "NewDebugPrefixes")]
    public class DebugPrefix : ScriptableObject
    {
        public Prefix[] DebugPrefixes;
        
        public DebugPrefix()
        {
            DebugPrefixes = new Prefix[1];
        }

        public List<Prefix> PrefixesToList()
        {
            var list = new List<Prefix>();

            foreach (var prefix in DebugPrefixes)
            {
                list.Add(prefix);
            }

            return list;
        }
    }
    
    [Serializable]
    public class Prefix
    {
        public bool IsEnabled;
        public string PrefixName;

        public Prefix(bool isEnabled, string prefixName)
        {
            IsEnabled = isEnabled;
            PrefixName = prefixName;
        }
    }
}
