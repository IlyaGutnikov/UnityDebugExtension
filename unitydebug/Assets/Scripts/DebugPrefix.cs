using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDebug.DebugPrefixes
{
    [CreateAssetMenu(fileName = "DebugPrefixes", menuName = "NewDebugPrefixes")]
    public class DebugPrefix : ScriptableObject
    {
        public string[] DebugPrefixes;
        
        public DebugPrefix()
        {
            DebugPrefixes = new string[1];
        }

        public List<string> PrefixesToList()
        {
            var list = new List<string>();

            foreach (var prefix in DebugPrefixes)
            {
                list.Add(prefix);
            }

            return list;
        }

        public string[] PrefixesToArray(List<string> prefixesInList)
        {
            if (prefixesInList.Count == 0)
            {
                Debug.LogError("Лист префиксов пуст");
            }

            string[] array = new string[prefixesInList.Count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = prefixesInList[i];
            }

            DebugPrefixes = array;

            return array;
        }

    }
}
