
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class BaseAPIManager<TAPIManager> : UnityEngine.MonoBehaviour where TAPIManager : BaseAPIManager<TAPIManager>
{
	public const string ServiceName = "ceinterface";
	public const string ApiURL = "http://54.250.203.224/ga/Amfphp/index.php?contentType=application/json";

	private static TAPIManager _Inst;
	public static TAPIManager Inst{
		get{
			if (_Inst == null) {
				_Inst = new UnityEngine.GameObject (typeof(TAPIManager).Name).AddComponent<TAPIManager> ();
				DontDestroyOnLoad (_Inst.gameObject);
			}
			return _Inst;
		}
	}
//	public static UnityEngine.GameObject LoadingUI = null;
//	public string LoadingPath = "";
//	public static  bool ShowLoading = true;

	private bool LastIsJsonRes;
	private string LastMethodName;
	private Action<string> LastCallbackStr;
	private Action<APIResult> LastCallbackRes;
	private object[] LastValues;
	private Action<string> LastDateTimeCallback;

	void Awake ()
	{
		if (_Inst == null) {
			_Inst = this as TAPIManager;
		} else if (_Inst != this) {
			Destroy (gameObject);	//重複出現
		}
	}

	/// <summary>
	/// 呼叫 API (Server 回傳值只當字串使用，不當 Json 使用)
	/// </summary>
	/// <param name="methodName">API 方法名稱.</param>
	/// <param name="callback">API 呼叫成功後的回呼函式</param>
	/// <param name="values">API 參數</param>
	public virtual void CallStrAPIA (string methodName, Action<string> callback, params object[] values){ CallStrAPIB(methodName, callback, values); }
	public virtual void CallStrAPIB (string methodName, Action<string> callback, object[] values)
	{
//		if (ShowLoading)
//			ShowLoadingHUD ();
		Inst.StartCoroutine (send (false, methodName, callback, null, values));
	}

	/// <summary>
	/// 呼叫 API
	/// </summary>
	/// <param name="methodName">API 方法名稱, 使用 APIMethod</param>
	/// <param name="callback">API 呼叫成功後的回呼函式, 帶一個 JSONObject 參數, ex: callback(JSONObject data)</param>
	/// <param name="values">API 參數</param>
	public virtual void CallJsonAPIA (string methodName, Action<APIResult> callback, params object[] values){ CallJsonAPIB(methodName, callback, values); }
	public virtual void CallJsonAPIB (string methodName, Action<APIResult> callback, object[] values)
	{
//		if (ShowLoading)
//			ShowLoadingHUD ();
		Inst.StartCoroutine (send (true, methodName, null, callback, values));
	}

	/// <summary>
	/// API 實做介面
	/// </summary>
	/// 
	protected virtual IEnumerator send (bool isJsonRes, string methodName, Action<string> callbackStr, Action<APIResult> callbackRes, object[] values)
	{
		LastIsJsonRes = isJsonRes;
		LastMethodName = methodName;
		LastCallbackStr = callbackStr;
		LastCallbackRes = callbackRes;
		LastValues = values;



		// STEP1: 將參數轉成 JSONObject Array 格式
		JSONObject parameters = new JSONObject(JSONObject.Type.ARRAY);
		foreach (Object value in values)
		{
			parameters.Add(APIUtility.ToJSONObject(value));
		}

		// STEP2: 設定 AmfPHP 參數
		JSONObject obj = new JSONObject(JSONObject.Type.OBJECT);
		//利用 Config Manager 取得 ServiceName
		obj.AddField("serviceName",ServiceName);
		obj.AddField("methodName", methodName);
		obj.AddField("parameters", parameters);
		string rawData = obj.print();

//		// 設定 AmfPHP 參數
//		APIRequest req = new APIRequest ();
//		req.serviceName = ServerName;
//		req.methodName = methodName;
//		req.parameters = values;

//		string rawData = JsonMapper.ToJson (req);
		APILog.Log ("送出：" + rawData);

		Dictionary<string, string> header = new Dictionary<string, string> ();
		header.Add ("Content-Type", "text/json");
		header.Add ("Content-Encoding", "UTF-8");

		// \魔法勿動/ 解決 Android 傳送中文編碼長度問題
		if (UnityEngine.Application.platform != UnityEngine.RuntimePlatform.Android) {
			header.Add ("Content-Length", rawData.Length.ToString ());
		}

		System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding ();

		// STEP3: 呼叫 AmfPHP service
		UnityEngine.WWW www = new UnityEngine.WWW (
			ApiURL,
			utf8.GetBytes (rawData), 
			header);
		APILog.Log ("送出111：" + www.url);
		yield return www;

		if (Object.ReferenceEquals (www.error, null)) {
			string wwwText = APIUtility.ConvertUTF8toBIG5 (www.text);
			UnityEngine.Debug.Log ("收到：" + wwwText);
			// Server request 成功
			if (isJsonRes) {
				// 將 server 回傳字串轉成 JSONObject 傳給回呼函式
				APIResult res = APIResult.Create (wwwText);

				if (res.result_id == 1) {
					//回傳成功
					if (callbackRes != null)
						callbackRes (res);

				} else if (res.error == "ERROR_1000") {
					APILog.LogError ("待處理特殊錯誤代碼：ERROR_1000");
				} else {
					APILog.LogError ("待處理錯誤代碼：" + res.error);
				}

				
			} else {
				// 一般字串回傳值
				if (callbackStr != null)
					callbackStr (www.text);
			}
		} else {
			APILog.LogError ("API 送出失敗 Error: " + www.error);
			// TODO: request 失敗處理
			// ...
			//				MsgManager.Instance.ShowMsgBox(new MsgBoxData(){
			//					Text = "通信エラー｡通信状態を確認してください｡",
			//					DefineLabelText = "OK",
			//					ButtonDefine = ReConnect,
			//					ButtonClose = ReConnect,
			//				});
		}
//		ShowLoading = true;
//		if (LoadingUI != null)
//			Destroy (LoadingUI);

	}

	// 重新傳送
	public void ReConnect ()
	{
//		if (ShowLoading) {
//			ShowLoadingHUD ();
//		}
		Inst.StartCoroutine (send (LastIsJsonRes, LastMethodName, LastCallbackStr, LastCallbackRes, LastValues));
	}

	/// <summary>顯示 Loading 介面</summary>
	protected virtual void ShowLoadingHUD ()
	{
//		UnityEngine.GameObject loadingPrefab = (UnityEngine.GameObject)UnityEngine.Resources.Load (LoadingPath, typeof(UnityEngine.GameObject));
//		if (loadingPrefab != null) {
//			if (LoadingUI == null) {
//				LoadingUI = Instantiate (loadingPrefab) as UnityEngine.GameObject;
//				LoadingUI.transform.parent = transform;
//				LoadingUI.transform.localPosition = UnityEngine.Vector3.zero;
//				LoadingUI.transform.localScale = UnityEngine.Vector3.one;
//			}
//			loadingPrefab = null;
//			UnityEngine.Resources.UnloadUnusedAssets ();
//			System.GC.Collect ();
//		}
	}
}



//[Serializable]
//public class APIParam{
//	public string Key;
//	public string Value;
//	public APIParam(string Key, string Val){
//		this.Key = Key;
//		this.Value = Val;
//	}
//}