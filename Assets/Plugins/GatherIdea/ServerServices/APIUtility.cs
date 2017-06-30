using System;

//namespace com.Skylink
//{
public class APIUtility
{
	/// <summary>
	/// 將 Object 轉型成 JSONObject.
	/// </summary>
	/// <returns>回傳 (Int32)JSONObject.n, (String)JSONObject.str, (Boolean)JSONObject.b, null</returns>
	/// <param name="obj">支援型別: Int32, String, Boolean</param>
	public static JSONObject ToJSONObject (Object obj)
	{
		JSONObject json;
			
		if (obj is Int32) {
			json = new JSONObject (JSONObject.Type.NUMBER);
			json.n = (Int32)obj;
		} else if (obj is String) {
			json = new JSONObject (JSONObject.Type.STRING);
			json.str = (String)obj;
		} else if (obj is Boolean) {
			json = new JSONObject (JSONObject.Type.BOOL);
			json.b = (Boolean)obj;
		} else {
			json = new JSONObject (JSONObject.Type.NULL);
		}
		return json;
	}

	public static string ConvertUTF8toBIG5 (string strInput)
	{
		int checkIdx = strInput.IndexOf ("\\u");
		while (checkIdx != -1) {
			string orgStr = strInput.Substring (checkIdx, 6);
			string orgStrInt = orgStr.Substring (2);
			int strInt = -1;
			if(int.TryParse(orgStrInt, System.Globalization.NumberStyles.HexNumber, null, out strInt)){
				char newStr = (char)strInt;
				strInput = strInput.Replace (orgStr, newStr.ToString());
			}
			checkIdx = strInput.IndexOf ("\\u", checkIdx);
		}

		return strInput;

//		string[] strlist = strInput.Replace("//","").Replace("\\","").Split('u');
//		string outStr = null;
//		try  
//		{  
//			for (int i = 1; i < strlist.Length; i++)  
//			{  
//				//将unicode字符转为10进制整数，然后转为char中文字符  
//				outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);  
//			}  
//		}  
//		catch (FormatException ex)  
//		{  
//			outStr = strInput;
//		}  
//		return outStr;
	}

	/// <summary>
	/// 將 JSOObject 轉成單引號格式 string.
	/// </summary>
	public static string ToApostrophesJSON (JSONObject json, int depth = 0)
	{
		if (depth++ > 1000) {
			return "";
		}
		string str = "";
		switch (json.type) {
		case JSONObject.Type.STRING:
			str = "\\\"" + json.str + "\\\"";
			break;
		case JSONObject.Type.NUMBER:
				#if USEFLOAT
				if(float.IsInfinity(json.n))
					str = "\"INFINITY\"";
				else if(float.IsNegativeInfinity(json.n))
					str = "\"NEGINFINITY\"";
				else if(float.IsNaN(json.n))
					str = "\"NaN\"";
				#else
			if (double.IsInfinity (json.n))
				str = "\"INFINITY\"";
			else if (double.IsNegativeInfinity (json.n))
				str = "\"NEGINFINITY\"";
			else if (double.IsNaN (json.n))
				str = "\"NaN\"";
				#endif
				else
				str += json.n;
			break;
		case JSONObject.Type.OBJECT:
			str = "{";
			if (json.list.Count > 0) {
				for (int i = 0; i < json.list.Count; i++) {
					string key = (string)json.keys [i];
					JSONObject obj = (JSONObject)json.list [i];
					if (obj) {
						str += "\\\"" + key + "\\\":";
						str += ToApostrophesJSON (obj, depth) + ",";
					}
				}
				str = str.Substring (0, str.Length - 1);
			}
			str += "}";
			break;
		case JSONObject.Type.ARRAY:
			str = "[";
			if (json.list.Count > 0) {
				foreach (JSONObject obj in json.list) {
					if (obj) {
						str += ToApostrophesJSON (obj, depth) + ",";
					}
				}
				str = str.Substring (0, str.Length - 1);
			}
			str += "]";
			break;
		case JSONObject.Type.BOOL:
			if (json.b)
				str = "true";
			else
				str = "false";
			break;
		case JSONObject.Type.NULL:
			str = "null";
			break;
		}
		return str;
	}

	/// <summary>
	/// 取得物件的值
	/// </summary>
	/// <returns>The property value.</returns>
	/// <param name="src">物件名</param>
	/// <param name="propName">要取的值名</param>
	public static object GetPropValue (object src, string propName)
	{
		return src.GetType ().GetProperty (propName).GetValue (src, null);
	}

	/// <summary>
	/// 設定物件的值
	/// </summary>
	/// <param name="src">物件名</param>
	/// <param name="propName">要設定的值名</param>
	/// <param name="value">值</param>
	public static void SetPropValue (object src, string propName, object value)
	{
		src.GetType ().GetProperty (propName).SetValue (src, value, null);    
	}
}
//}

