using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerData
{
    /// <summary>流水號</summary>
    public int customerId { get; private set; }

    /// <summary>所屬群組</summary>
    public int customerType { get; private set; }

    /// <summary>所屬群組資料</summary>
    public CustomerTypeData customerTypeData{ get { return CustomerModel.Inst.getCustomerTypeData(customerType); } }

    /// <summary>公司名稱</summary>
    public string companyName;
    /// <summary>負責人名稱</summary>
    public string personName;
    /// <summary>負責人職位</summary>
    public string personPosition;
    /// <summary>負責人電話</summary>
    public string personTel;
    /// <summary>負責人 QQ</summary>
    public string personQQ;
    /// <summary>負責人行動</summary>
    public string personMobile;
    /// <summary>負責人 Mail</summary>
    public string personMail;
    /// <summary>公司產品</summary>
    public string customerProduct;
    /// <summary>公司地址</summary>
    public string customerAddress;
    /// <summary>??</summary>
    public string customerType2;
    /// <summary>??</summary>
    public string customerType3;
    /// <summary>??</summary>
    public string other;
    /// <summary>備註</summary>
    public string remark;

    public string[] contactGames;

    /// <summary>是否已親自面提</summary>
    public bool meetingCheck;
    /// <summary>是否已寄陌生開發信</summary>
    public bool mailedCheck;



    //    public int dataIndex;
    //    public bool meetingCheck;
    //    public int dataType;
    //    public string dataID;
    //    public string company_Name;
    //    public string contact_Person;
    //    public string contact_Position;
    //    public string contact_Tel;
    //    public string contact_QQ;
    //    public string contact_Phone;
    //    public string contact_Email;
    //    public string contact_Other;
    //    public string contact_Remarks;
    //    public List<string> contact_Games;
    //    public string contact_Address;

    //    public CustomerData(
    ////        int index,
    //        bool meeted,
    //        int dType,
    //        string dID,
    //        string companyName,
    //        string contactPerson,
    //        string contactPosition,
    //        string contactTel,
    //        string contactQQ,
    //        string contactPhone,
    //        string contactEmail,
    //        string contactOther,
    //        string contactRemarks,
    //        List<string> contactGames,
    //        string contactAddress
    //    )
    //    {
    //        dataIndex = index;
    //        meetingCheck = meeted;
    //        dataType = dType;
    //        dataID = dID;
    //        company_Name = companyName;
    //        contact_Person = contactPerson;
    //        contact_Position = contactPosition;
    //        contact_Tel = contactTel;
    //        contact_QQ = contactQQ;
    //        contact_Phone = contactPhone;
    //        contact_Email = contactEmail;
    //        contact_Other = contactOther;
    //        contact_Remarks = contactRemarks;
    //        contact_Games.AddRange(contactGames);
    //        contact_Address = contactAddress;
    //    }

    public CustomerData(int customerType, int customerId)
    {
        this.customerId = customerId;
        this.customerType = customerType;
    }

    public static CustomerData Create(JSONObject jsonData)
    {
        if (jsonData == null)
            return null;
        if (!jsonData.HasFields(new string[]{ "customer_id", "customer_type" }))
            return null;
		
        CustomerData data = new CustomerData(APIResult.GetIntVal(jsonData, "customer_type"), APIResult.GetIntVal(jsonData, "customer_id"));
        data.companyName = APIResult.GetStrVal(jsonData, "company_name");
        data.personName = APIResult.GetStrVal(jsonData, "contact_person_name");
        data.personPosition = APIResult.GetStrVal(jsonData, "contact_person_position");
        data.personTel = APIResult.GetStrVal(jsonData, "contact_person_tel");
        data.personQQ = APIResult.GetStrVal(jsonData, "contact_person_qq");
        data.personMobile = APIResult.GetStrVal(jsonData, "contact_person_mobile");
        data.personMail = APIResult.GetStrVal(jsonData, "contact_person_email");
        data.customerProduct = APIResult.GetStrVal(jsonData, "customer_product");
        data.customerAddress = APIResult.GetStrVal(jsonData, "customer_address");
        data.customerType2 = APIResult.GetStrVal(jsonData, "customer_type2");
        data.customerType3 = APIResult.GetStrVal(jsonData, "customer_type3");
        data.other = APIResult.GetStrVal(jsonData, "other");
        data.remark = APIResult.GetStrVal(jsonData, "remark");

        return data;
    }
}

