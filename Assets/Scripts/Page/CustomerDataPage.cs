using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDataPage : MonoBehaviour
{

    [SerializeField] UIScrollView scrollview;
    [SerializeField] UIWrapContent wrapContent;
    [SerializeField] UIInput uiInput;
    [SerializeField] UILabel titleLabel;

    UIWrapContentHelper wrapContentHelper;

    List<CustomerData> customerDataList = new List<CustomerData>();


    void Start()
    {
        titleLabel.text = Main.Instants.nowCustomerType.typeDesc;
        prepareData();

        if (customerDataList.Count >= 4)
        {
            wrapContent.minIndex = 0;
            wrapContent.maxIndex = customerDataList.Count - 1;
        }
        else
        {
            CustomerDataPrefab[] goList = wrapContent.GetComponentsInChildren<CustomerDataPrefab>();
            for (int i = 0; i < goList.Length; i++)
            {
                if (i < customerDataList.Count)
                {
                    goList[i].gameObject.SetActive(true);
                    goList[i].SetData(customerDataList[i]);
                }
                else
                {
                    goList[i].gameObject.SetActive(false);
                }
            }
            wrapContent.enabled = false;
        }
        wrapContentHelper = UIWrapContentHelper.Create(wrapContent);
        wrapContentHelper.OnRenderEvent = OnRenderWrapContent;
        RefreshUI();
    }

    public void OnTextSubmit()
    {
        if (!string.IsNullOrEmpty(uiInput.value))
        {
            Debug.LogError(uiInput.value);
            string searchWord = uiInput.value;


            CleanInput();
        }
    }

    public void CleanInput()
    {
        uiInput.value = "";
    }


    private void RefreshUI()
    {
        int max = customerDataList.Count;//要渲染数据
        wrapContentHelper.Refresh(max, true);
    }

    //具体的渲染逻辑
    private void OnRenderWrapContent(GameObject gameObj, int idx)
    {
        if (idx >= customerDataList.Count)
        {
            gameObj.SetActive(false);
            Debug.LogWarning("超出索引");
            return;
        }
        CustomerData cData = customerDataList[idx];
        gameObj.GetComponent<CustomerDataPrefab>().SetData(cData);
    }

    void prepareData()
    {
        customerDataList.Clear();

        if (Main.Instants.nowCustomerType != null)
        {
            customerDataList.AddRange(Main.Instants.nowCustomerType.customers);
//            customerDataList.Reverse();
        }

//		if (Main.Instants.nowCustomerType == null)
//        {
//            customerDataList.AddRange(TestData.customerDataList());
//        }
//        else
//        {
//            foreach (CustomerData cd in TestData.customerDataList())
//            {
//				if (cd.customerTypeData == Main.Instants.nowCustomerType)
//                {
//                    customerDataList.Add(cd);
//                }
//            }
//        }
    }
}
