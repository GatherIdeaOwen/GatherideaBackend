using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooperationData : MonoBehaviour
{
    public int dataIndex;
    public string dataID;
    public string company_Name;
    public string contact_Person;
    public string contact_UniformNumber;
    public string contact_Phone;
    public string contact_Email;
    public string contact_Address;

    public CooperationData(
        int index,
        string dID,
        string companyName,
        string contactPerson,
        string contactUniformNumber,
        string contactPhone,
        string contactEmail,
        string contactAddress
    )
    {
        dataIndex = index;
        dataID = dID;
        company_Name = companyName;
        contact_Person = contactPerson;
        contact_Phone = contactPhone;
        contact_Email = contactEmail;
        contact_Address = contactAddress;
        contact_UniformNumber = contactUniformNumber;
    }
}

