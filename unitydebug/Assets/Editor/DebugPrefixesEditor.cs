using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UnityDebug.DebugPrefixes
{
    public class DebugPrefixesEditor : EditorWindow
    {
        private DebugPrefix _debugPrefix;

        private List<string> _debugPrefixList;
        
        [MenuItem("Tools/DebugPrefixes")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<DebugPrefixesEditor>("Set Debug Prefixes");
        }

        private void OnEnable()
        {
            _debugPrefixList = new List<string>();
            
            var prefixes = Resources.LoadAll<DebugPrefix>("DebugPrefix");
            _debugPrefix = prefixes[0];
            //TODO подгрузить ассет с данными листа

            if (_debugPrefix == null)
            {
                Debug.LogError("Can't find prefix");
            }

            _debugPrefixList = _debugPrefix.PrefixesToList();
        }

        void OnGUI()
        {
            if (_debugPrefixList == null) 
                return;
            
            EditorGUILayout.BeginVertical();

            for (int i = 0; i < _debugPrefixList.Count; i++)
            {
                _debugPrefixList[i] = EditorGUILayout.TextField(i.ToString(), _debugPrefixList[i]);
            }
            
            EditorGUILayout.EndVertical();
        }
    }
}


