using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTypeData
{
    public List<CustomerData> customers{ get; private set; }

    public Dictionary<int, CustomerData> customerMap_id_data{ get; private set; }

    public int customerType{ get; private set; }

    public string typeDesc{ get; private set; }
    //	public int typeIndex{ get; private set; }

    public CustomerTypeData(int customerType, string typeDesc)
    {
        this.customerType = customerType;
        this.typeDesc = typeDesc;
    }

    public void renewCustomersFromServer(Action<bool> endFunc = null)
    {

        Action<APIResult> callback = (res) =>
        {
            if (customers == null)
            {
                customers = new List<CustomerData>();
                customerMap_id_data = new Dictionary<int, CustomerData>();
            }
            else
            {
                customers.Clear();
                customerMap_id_data.Clear();
            }

            if (res.success)
            {
                JSONObject datas = res.jsonData["customer"];
                if (datas != null || !datas.IsArray)
                {
                    for (int i = 0; i < datas.Count; i++)
                    {
                        CustomerData data = CustomerData.Create(datas[i]);
                        if (data == null)
                            continue;
                        if (customerMap_id_data.ContainsKey(data.customerId))
                        {
                            Debug.LogError("重複的客戶 ID：" + data.customerId);
                            continue;
                        }
                        customers.Add(data);
                        customerMap_id_data.Add(data.customerId, data);
                    }
                }
            }

            if (endFunc != null)
                endFunc(res.success);
        };

        ProjectAPI.Inst.CallJsonAPIA("get_customer", callback, customerType);
    }

    public static CustomerTypeData Create(JSONObject typeData)
    {
        if (typeData == null)
        {
            Debug.LogError("沒有 typeData");
            return null;
        }
		
        if (!typeData.HasFields(new string[]{ "customer_type_id", "customer_type_desc" }))
        {
            Debug.LogError("沒有 customer_type 或 customer_type_desc 資料！" + typeData.str);
            return null;
        }
		
        CustomerTypeData data = new CustomerTypeData(APIResult.GetIntVal(typeData, "customer_type_id"), typeData["customer_type_desc"].str);
//		data.customerType = (int)APIResult.GetFloatVal(typeData, "customer_type");
//		data.typeDesc = typeData ["customer_type_desc"].str;
        return data;
    }
}
