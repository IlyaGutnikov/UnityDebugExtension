using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace UnityDebug.DebugPrefixes
{
    public class DebugPrefixesEditor : EditorWindow
    {
        private DebugPrefix _debugPrefix;

        private List<Prefix> _debugPrefixList;
        Vector2 _scrollPos;
        
        [MenuItem("Tools/DebugPrefixes")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<DebugPrefixesEditor>("Set Debug Prefixes");
        }

        private void OnEnable()
        {
            _debugPrefixList = new List<Prefix>();
            
            var prefixes = Resources.LoadAll<DebugPrefix>("DebugPrefix");
            _debugPrefix = prefixes[0];
            //TODO подгрузить ассет с данными листа

            if (_debugPrefix == null)
            {
                Debug.LogError("Can't find prefix");
            }

            _debugPrefixList = _debugPrefix.PrefixesToList();
        }

        private void RefreshList()
        {
            if (_debugPrefixList.Count == 0)
            {
                Debug.LogError("В список не может быть пуст");
                _debugPrefixList.Add(new Prefix(true,"TEST1"));
            }

            for (int i = 0; i <_debugPrefixList.Count; i++)
            {
                if (String.IsNullOrEmpty(_debugPrefixList[i].PrefixName))
                {
                    _debugPrefixList.Remove(_debugPrefixList[i]);
                }
            }

            var ebabledPrefixes = _debugPrefixList.Where(x => x.IsEnabled);
            _debugPrefix.EnabledPrefixes = new Prefix[ebabledPrefixes.ToArray().Length];
            _debugPrefix.EnabledPrefixes = ebabledPrefixes.ToArray();
        }

        private bool CheckListForDuplicates()
        {
            if (_debugPrefixList.Count == 0 || _debugPrefixList == null)
            {
                return true;
            }

            return _debugPrefixList.GroupBy(n => n.PrefixName).Any(c => c.Count() > 1);
        }

        private void CreateEnum()
        {
            var debugScriptsFolder = Application.dataPath + "/Scripts/DebugPrefix";

            if (!Directory.Exists(debugScriptsFolder))
            {
                Directory.CreateDirectory(debugScriptsFolder);
            }
            var filePath = debugScriptsFolder + "/DebugPrefixEnum.cs";
            var stringToWrite = "public enum DebugPrefixEnum { \n";
            for (int i = 0; i < _debugPrefixList.Count; i++)
            {
                if (i != _debugPrefixList.Count - 1)
                {
                    stringToWrite += _debugPrefixList[i].PrefixName + ",\n";
                }
                else
                {
                    stringToWrite += _debugPrefixList[i].PrefixName + "\n" + "}";
                }
            }
            File.WriteAllText(filePath, stringToWrite, Encoding.UTF8);
            AssetDatabase.ImportAsset(filePath);
            AssetDatabase.Refresh();
        }

        void OnGUI()
        {
            if (_debugPrefixList == null) 
                return;

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Refresh"))
            {
                RefreshList();
            }
            if (GUILayout.Button("Save"))
            {
                RefreshList();
                if (CheckListForDuplicates())
                {
                    return;
                }

                _debugPrefix.DebugPrefixes = _debugPrefixList.ToArray();
                EditorUtility.SetDirty(_debugPrefix);
                AssetDatabase.SaveAssets();
            }
            
            if (GUILayout.Button("(Re)Create enum"))
            {
                CreateEnum();
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginVertical();

            if (CheckListForDuplicates())
            {
                GUILayout.Label("Prefixes have duplicates!");
            }
            _scrollPos =
                EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(500));
            for (int i = 0; i < _debugPrefixList.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                _debugPrefixList[i].PrefixName = EditorGUILayout.TextField(i.ToString(), _debugPrefixList[i].PrefixName);
                _debugPrefixList[i].IsEnabled = EditorGUILayout.Toggle(_debugPrefixList[i].IsEnabled);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Add item"))
            {
                _debugPrefixList.Add(new Prefix(false, "NewField" + _debugPrefixList.Count));
            }

            EditorGUILayout.EndVertical();
        }
    }
}


