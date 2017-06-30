using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDataPrefab : MonoBehaviour
{
    [SerializeField] UITable table;
    [SerializeField] UISprite meetedCheck;
    [SerializeField] UISprite mailedCheck;
    [SerializeField] UILabel companyName;
    [SerializeField] UILabel contactPerson;
    [SerializeField] UILabel contactPosition;
    [SerializeField] UILabel contactTel;
    [SerializeField] UILabel contactQQ;
    [SerializeField] UILabel contactMobile;
    [SerializeField] UILabel contactEmail;
    [SerializeField] UILabel contactOther;
    [SerializeField] UILabel contactRemarks;
    [SerializeField] UILabel contactProjects;
    [SerializeField] UILabel contactAddress;

	

    public void SetData(CustomerData cData)
    {
        if (cData.meetingCheck)
        {
            meetedCheck.spriteName = "Black";
        }
        else
        {
            meetedCheck.spriteName = "frame";
        }
        if (cData.mailedCheck)
        {
            mailedCheck.spriteName = "Black";
        }
        else
        {
            mailedCheck.spriteName = "frame";
        }
		companyName.text = cData.companyName;
		contactPerson.text = cData.personName;
		contactPosition.text = cData.personPosition;
		contactTel.text = cData.personTel;
		contactQQ.text = cData.personQQ;
		contactMobile.text = cData.personMobile;
		contactEmail.text = cData.personMail;
		contactOther.text = cData.other;
		contactRemarks.text = cData.remark;
        string projectName = string.Empty;
		if (cData.contactGames != null && cData.contactGames.Length > 0) {
			foreach (string games in cData.contactGames) {
				projectName += games + ",";
			}
		}
        contactProjects.text = projectName;
		contactAddress.text = cData.customerAddress;
    }
}
