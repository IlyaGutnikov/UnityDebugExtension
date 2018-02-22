#if UNITY_EDITOR || DEVELOPMENT_BUILD
#define DEBUG_LOG_OVERWRAP
#endif
using System.Linq;
using UnityDebug.DebugPrefixes;
using UnityEngine;
 
#if DEBUG_LOG_OVERWRAP
public static class Debug
{

    static Prefix[] EnabledPrefixes;

    static bool IsEnable(DebugPrefixEnum prefix)
    {
        if (EnabledPrefixes == null)
        {
            var prefixes = Resources.LoadAll<DebugPrefix>("DebugPrefix");
            DebugPrefix debugPrefix = prefixes[0];
            EnabledPrefixes = debugPrefix.EnabledPrefixes;
        }

        return EnabledPrefixes.FirstOrDefault(x => x.PrefixName == prefix.ToString()) != null;
    }

    static string PrefixToString(DebugPrefixEnum prefix)
    {
        return "[" + prefix.ToString() + "]: ";
    }

    public static void Break ()
    {
        UnityEngine.Debug.Break ();
    }
 
    public static void Log (DebugPrefixEnum prefix, object message)
    {
        if (IsEnable (prefix))
        {
            UnityEngine.Debug.Log (PrefixToString(prefix) + message);
        }
    }
    
    public static void Log (object message)
    {
        UnityEngine.Debug.Log (message);      
    }
 
    public static void Log (DebugPrefixEnum prefix, object message, Object context)
    {
        if (IsEnable (prefix)) {
            UnityEngine.Debug.Log (PrefixToString(prefix) + message, context);
        }
    }
    
    public static void Log (object message, Object context)
    {
        UnityEngine.Debug.Log (message, context);
    }
 
    public static void LogWarning (DebugPrefixEnum prefix, object message)
    {
        if (IsEnable (prefix)) {
            UnityEngine.Debug.LogWarning (PrefixToString(prefix) + message);
        }
    }
    
    public static void LogWarning (object message)
    {
        UnityEngine.Debug.LogWarning (message);
    }
 
    public static void LogWarning (DebugPrefixEnum prefix, object message, Object context)
    {
        if (IsEnable (prefix)) {
            UnityEngine.Debug.LogWarning (PrefixToString(prefix) + message, context);
        }
    }
    
    public static void LogWarning (object message, Object context)
    {
            UnityEngine.Debug.LogWarning (message, context);
    }
 
    public static void LogError (DebugPrefixEnum prefix, object message)
    {
        if (IsEnable (prefix)) {
            UnityEngine.Debug.LogError (PrefixToString(prefix) + message);
        }
    }
    
    public static void LogError (object message)
    {
        UnityEngine.Debug.LogError (message);
    }
 
    public static void LogError (DebugPrefixEnum prefix, object message, Object context)
    {
        if (IsEnable (prefix)) {
            UnityEngine.Debug.LogError (PrefixToString(prefix) + message, context);
        }
    }
    
    public static void LogError (object message, Object context)
    {
        UnityEngine.Debug.LogError (message, context);
    }
 
    public static void DrawLine (Vector3 start, Vector3 end, Color color, float duration = 0.0F, bool depthTest = true)
    {
        UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
    }
}
#endif