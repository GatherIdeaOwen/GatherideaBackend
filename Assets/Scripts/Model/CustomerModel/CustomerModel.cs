using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CustomerModel : DataSingleton<CustomerModel> {

	public List<CustomerTypeData> customerTypes{ get; private set; }

	public Dictionary<int, CustomerTypeData> customerTypeMap_type_data{ get; private set; }

	/// <summary>取得客戶群組資料</summary>
	public CustomerTypeData getCustomerTypeData(int type){
		if (customerTypeMap_type_data == null)
			return null;
		if (!customerTypeMap_type_data.ContainsKey (type))
			return null;
		return customerTypeMap_type_data [type];
	}

	/// <summary>更新客戶群組列表</summary>
	public void renewCustomerTypesFromServer(Action<bool> endFunc = null){
		Action<APIResult> callback = (res) => {
			if(customerTypes == null){
				customerTypes = new List<CustomerTypeData>();
				customerTypeMap_type_data = new Dictionary<int, CustomerTypeData>();
			}else{
				customerTypes.Clear();
				customerTypeMap_type_data.Clear();
			}

			if(res.success){
				JSONObject datas = res.jsonData["customer_type"];
				if(datas != null && datas.IsArray){
					for(int i=0; i<datas.Count; i++)
					{
						CustomerTypeData data = CustomerTypeData.Create(datas[i]);
						if(data == null)
							continue;
						if(customerTypeMap_type_data.ContainsKey(data.customerType)){
							Debug.LogError("重複的客戶群組：" + data.customerType);
							continue;
						}
						customerTypes.Add(data);
						customerTypeMap_type_data.Add(data.customerType, data);
					}
				}
			}

			if(endFunc != null)
				endFunc(res.success);
		};

		ProjectAPI.Inst.CallJsonAPIA ("get_customer_type", callback);
	}

}
