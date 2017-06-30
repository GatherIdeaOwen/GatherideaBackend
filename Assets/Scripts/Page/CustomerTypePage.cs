using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTypePage : MonoBehaviour
{
	public delegate void OnButtonClick(CustomerTypeButton btn);

    [SerializeField] UIScrollView scrollView;
    [SerializeField] UIGrid grid;
    [SerializeField] GameObject buttonPrefab;

    void Start()
    {
//        foreach (CustomerTypeData ctd in TestData.customerTypeList())
//        {
//			NGUITools.AddChild(grid.gameObject, buttonPrefab).GetComponent<CustomerTypeButton>().SetData(ctd, OnBtnClick);
//
//        }

		foreach (CustomerTypeData ctd in CustomerModel.Inst.customerTypes)
			NGUITools.AddChild(grid.gameObject, buttonPrefab).GetComponent<CustomerTypeButton>().SetData(ctd, OnBtnClick);
		
        scrollView.ResetPosition();
        grid.Reposition();
    }

	void OnBtnClick(CustomerTypeButton btn)
    {
		if (btn == null || btn.data == null)
			return;
		
		Main.Instants.nowCustomerType = btn.data;
        
		Action<bool> endFunc = (success) => {
			if(!success)
				return;
			Main.Instants.GotoCustomerDataPage();
		};

		btn.data.renewCustomersFromServer (endFunc);
    }

}
