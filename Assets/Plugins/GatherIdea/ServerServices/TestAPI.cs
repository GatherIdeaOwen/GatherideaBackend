#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamapleAPIManager : BaseAPIManager<SamapleAPIManager>{

}


public class TestAPI : MonoBehaviour {
	
	[Serializable]
	public class Item
	{
		public bool callServer;
		public bool isJsonRes;
		public string methodName;
		public string[] param;
		public Item(bool isJsonRes, string methodName, params string[] param){
			this.isJsonRes = isJsonRes;
			this.methodName = methodName;
			this.param = param;
		}
	}

	[SerializeField] private Item[] testItems;
	private Item[] _testItems = new Item[]{
		new Item (false, "get_time"),
		new Item (true, "login", new string[]{ "aaaaa", "ppppppp" }),
		new Item (true, "get_company_info_name", new string[] { "9999" }),
		new Item (true, "get_company_info_all"),
		new Item (true, "get_keywords_info_all"),
	};

	// Use this for initialization
	void Start () {
		testItems = _testItems;
	}

	void callBackStr(string res){
		Debug.Log ("Get!!!!! " + res);
	}
	void callBackJson(APIResult res){
		Debug.Log ("Get!!!!! " + res);
	}

	// Update is called once per frame
	void Update () {
		if (testItems != null) {
			for (int i = 0; i < testItems.Length; i++) {
				Item item = testItems [i];
				if (item == null)
					continue;
				if (!item.callServer)
					continue;
				item.callServer = false;
				if (item.isJsonRes) {
					SamapleAPIManager.Inst.CallJsonAPIB (item.methodName, callBackJson, item.param);
				} else {
					SamapleAPIManager.Inst.CallStrAPIB (item.methodName, callBackStr, item.param);
				}
				break;
			}
		}
	}
}
#endif