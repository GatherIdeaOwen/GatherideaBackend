using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserData
{
	public string userAccount{ get; private set; }
//	public string userPassword{ get; private set; }
	public string userAuthorKey{ get; private set; }
	public int userId{ get; private set; }
	public int userLv{ get; private set; }

	/// <summary>AuthorKey 已失效</summary>
	public bool authorKeyIsField{ get; private set; }

	/// <summary>設定 AuthorKey 已失效</summary>
	public void setAuthorKeyIsField(){
		authorKeyIsField = true;
	}

    public UserData(string userAcc, string userAuth, int uid, int ulv)
    {
        userAccount = userAcc;
    //    userPassword = userPass;
        userAuthorKey = userAuth;
        userId = uid;
        userLv = ulv;
    }
  
}
