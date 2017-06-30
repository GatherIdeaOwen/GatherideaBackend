using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTypeButton : MonoBehaviour
{

    [SerializeField] UILabel buttonLabel;
    [SerializeField] UIButton mButton;
    int btnIndex = 0;
    CustomerTypePage.OnButtonClick clickFunc;
	public CustomerTypeData data{ get; private set; }

	public void SetData(CustomerTypeData data, CustomerTypePage.OnButtonClick onClick)
    {
		this.data = data;
		buttonLabel.text = data.typeDesc;
//        btnIndex = typeIndex;
        clickFunc = onClick;
    }

    public void ButtonClick()
    {
        if (clickFunc != null)
        {
            clickFunc(this);
        }
    }
}
