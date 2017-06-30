using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectAPI : BaseAPIManager<ProjectAPI> {



	protected override IEnumerator send (bool isJsonRes, string methodName, System.Action<string> callbackStr, System.Action<APIResult> callbackRes, object[] values)
	{
		if (methodName == ProjectDefine.LoginApi) {
			//登入 API 不用 AuthorKey
			yield return base.send (isJsonRes, methodName, callbackStr, callbackRes, values);

		} else if (UserModel.Inst.userDataValide) {
			//其他 API 需要帶入帳號 AuthorKey
			int valueCount = values == null ? 0 : values.Length;
			object[] newVals = new object[valueCount + 2];
			newVals [0] = UserModel.Inst.userData.userId;
			newVals [1] = UserModel.Inst.userData.userAuthorKey;
			for (int i = 0; i < valueCount; i++)
				newVals [i + 2] = values [i];
			yield return base.send (isJsonRes, methodName, callbackStr, callbackRes, newVals);

		} else {
			//需要重新登入
			Debug.LogError("需要重新登入！");
		}
	}

}
