using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : MonoBehaviour
{

    public void GotoCustomerAddressBook()
    {
		Action<bool> endFunc = (success) => {
			if(success)
				Main.Instants.GotoCustomerTypePage();
		};

		CustomerModel.Inst.renewCustomerTypesFromServer (endFunc);
    }

    public void GotoKeyword()
    {
        Main.Instants.GotoKeywordPage();
    }

    public void GotoLeaderBoard()
    {
        Main.Instants.GotoHotSearchPage();
    }

    public void GotoCooperationeVndor()
    {
        Main.Instants.GotoCooperationPage();
    }

    public void GotoOnlineOrder()
    {
        Main.Instants.GotoOrderPage();
    }

}
