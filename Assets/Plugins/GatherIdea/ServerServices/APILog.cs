using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APILog {

	#if UNITY_EDITOR

	public delegate void LogDelegate(object logMsg, UnityEngine.Object context = null);
	public static void DoNothing(object logMsg, UnityEngine.Object context = null){ }

	public static LogDelegate Log { get{ return UnityEngine.Debug.Log; } }
	public static LogDelegate LogError { get{ return UnityEngine.Debug.LogError; } }
	public static LogDelegate LogWarning { get{ return UnityEngine.Debug.LogWarning; } }

	#else

	[Conditional("DEBUG_SETTING")]
	public static void Log(string logMsg)
	{
	UnityEngine.Debug.Log (logMsg);
	}

	[Conditional("DEBUG_SETTING")]
	public static void Log(string logMsg, UnityEngine.Object context)
	{
	UnityEngine.Debug.Log (logMsg, context);
	}

	[Conditional("DEBUG_SETTING")]
	public static void LogError(string logMsg)
	{
	UnityEngine.Debug.LogError (logMsg);
	}

	[Conditional("DEBUG_SETTING")]
	public static void LogError(string logMsg, UnityEngine.Object context)
	{
	UnityEngine.Debug.LogError (logMsg, context);
	}

	[Conditional("DEBUG_SETTING")]
	public static void LogWarning(string logMsg)
	{
	UnityEngine.Debug.LogWarning (logMsg);
	}

	[Conditional("DEBUG_SETTING")]
	public static void LogWarning(string logMsg, UnityEngine.Object context)
	{
	UnityEngine.Debug.LogWarning (logMsg, context);
	}

	#endif
}
