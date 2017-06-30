using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIResult {
	/// <summary>原始字串資料</summary>
	public string jsonStr{ get; private set; }
	/// <summary>結果代號</summary>
	public int result_id{ get; private set; }
	/// <summary>是否傳輸成功</summary>
	public bool success{ get; private set; }
	/// <summary>錯誤訊息</summary>
	public string error{ get; private set; }
	public string message{ get; private set; }
	/// <summary>Ios App 版號</summary>
	public string game_ios_version{ get; private set; }
	/// <summary>Android App 版號</summary>
	public string game_android_version{ get; private set; }
	/// <summary>Ios Patch 版號</summary>
	public string patch_ios_version{ get; private set; }
	/// <summary>Android Patch 版號</summary>
	public string patch_android_version{ get; private set; }
	/// <summary>所有資料集</summary>
	public JSONObject jsonData;
	public float getIntVal(string key){ return GetIntVal (jsonData, key); }
	public float getFloatVal(string key){ return GetFloatVal (jsonData, key); }
	public string getStrVal(string key){ return GetStrVal (jsonData, key); }

	private APIResult(){}

	public static APIResult Create(string jsonStr){

		if (string.IsNullOrEmpty (jsonStr)) {
			APILog.LogError("jsonStr 為空值");
			return null;
		}

		JSONObject jsonData = null;
		try{
			jsonData = new JSONObject(jsonStr);

		}catch(Exception e){
			APILog.LogError ("Server 回傳結果解析失敗！回傳值：" + jsonStr + "\nErrMes：" + e.Message + "\n堆疊：" + e.StackTrace + "\n[End]\n\n");
			return null;
		}


		APIResult result = new APIResult ();

		result.jsonStr = jsonStr;
		result.jsonData = jsonData;
		result.result_id = GetIntVal(jsonData, "result_id");// GetStrVal (resData, "result_id");
		result.success = result.result_id == 1;
		result.error = GetStrVal(jsonData, "error");
		result.message = GetStrVal (jsonData, "message");
		result.game_ios_version = GetStrVal (jsonData, "game_ios_version");
		result.game_android_version = GetStrVal (jsonData, "game_android_version");
		result.patch_ios_version = GetStrVal (jsonData, "patch_ios_version");
		result.patch_android_version = GetStrVal (jsonData, "patch_android_version");

		return result;
	}
	public static int GetIntVal(JSONObject jsonObj, string key){
		if (jsonObj == null)
			return 0;
		JSONObject valJson = jsonObj [key];
		if (valJson == null)
			return 0;
		if (valJson.IsNumber)
			return (int)valJson.f;
		int val = 0;
		int.TryParse (jsonObj [key].str, out val);
		return val;
	}
	public static float GetFloatVal(JSONObject jsonObj, string key){
		if (jsonObj == null)
			return 0;
		JSONObject valJson = jsonObj [key];
		if (valJson == null)
			return 0;
		if (valJson.IsNumber)
			return (int)valJson.f;
		float val = 0;
		float.TryParse (jsonObj [key].str, out val);
		return val;
	}
	public static string GetStrVal(JSONObject jsonObj, string key){
		if (jsonObj == null)
			return null;
		if (!jsonObj.HasField (key))
			return null;
		
		return jsonObj [key].str;
	}
}

