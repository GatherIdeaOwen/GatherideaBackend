using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserModel : DataSingleton<UserModel> {

	/// <summary>使用者登入資料</summary>
	public UserData userData{ get; private set; }

	/// <summary>使用者資料是否有效（正常登入中）</summary>
	public bool userDataValide{
		get{
			if (userData == null)
				return false;
			if (userData.authorKeyIsField)
				return false;
			return true;
		}
	}

	public void Login(string account, string password, Action<bool> endFunc = null){

		if (string.IsNullOrEmpty (account) || string.IsNullOrEmpty (password)) {
			Debug.LogError ("帳號或密碼為空");
			if (endFunc != null)
				endFunc (false);
			return;
		}

		Action<APIResult> callback = (res) => {
			if(res.success){
				JSONObject userInfo = res.jsonData["user_info"];
				if(userInfo != null){
					userData = new UserData(
						userInfo["user_account"].str,
						userInfo["user_authorkey"].str,
						int.Parse(userInfo["user_id"].str),
						int.Parse(userInfo["user_lv"].str)
					);
				}
			}

			if(endFunc != null)
				endFunc(userData != null);
		};


		ProjectAPI.Inst.CallJsonAPIA (ProjectDefine.LoginApi, callback, account, password);
		
	}


}
