using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooperationDataPrefab : MonoBehaviour
{

    [SerializeField] UITable table;
    [SerializeField] UILabel companyName;
    [SerializeField] UILabel uniformNumber;
    [SerializeField] UILabel address;
    [SerializeField] UILabel contact;
    [SerializeField] UILabel phone;
    [SerializeField] UILabel email;

    [SerializeField] GameObject scaleItem;

    CooperationDataPage.OnToggleClick onToggleAction;

    public void SetData(CooperationData cData, CooperationDataPage.OnToggleClick onToggleClick)
    {
        companyName.text = cData.company_Name;
        uniformNumber.text = cData.contact_UniformNumber;
        address.text = cData.contact_Address;
        contact.text = cData.contact_Person;
        phone.text = cData.contact_Phone;
        email.text = cData.contact_Email;
        onToggleAction = onToggleClick;
    }

    public void SetToggle(UIToggle toggle)
    {
        scaleItem.SetActive(toggle.value);
        table.Reposition();
        if (onToggleAction != null)
        {
            onToggleAction(toggle);
        }
    }
}
