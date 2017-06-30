using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooperationDataPage : MonoBehaviour
{


    [SerializeField] UIScrollView scrollview;
    [SerializeField] UIWrapContent wrapContent;
    [SerializeField] UIInput uiInput;

    UIWrapContentHelper wrapContentHelper;

    List<CooperationData> cooperationDataList = new List<CooperationData>();

    public delegate void OnToggleClick(UIToggle btn);


    void Start()
    {
        prepareData();

        if (cooperationDataList.Count >= 4)
        {
            wrapContent.minIndex = 0;
            wrapContent.maxIndex = cooperationDataList.Count - 1;
        }
        else
        {
            CooperationDataPrefab[] goList = wrapContent.GetComponentsInChildren<CooperationDataPrefab>();
            for (int i = 0; i < goList.Length; i++)
            {
                if (i < cooperationDataList.Count)
                {
                    goList[i].gameObject.SetActive(true);
                    goList[i].SetData(cooperationDataList[i], OnToggleAction);
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
        int max = cooperationDataList.Count;//要渲染数据
        wrapContentHelper.Refresh(max, true);
    }

    //具体的渲染逻辑
    private void OnRenderWrapContent(GameObject gameObj, int idx)
    {
        if (idx >= cooperationDataList.Count)
        {
            gameObj.SetActive(false);
            Debug.LogWarning("超出索引");
            return;
        }
        CooperationData cData = cooperationDataList[idx];
        gameObj.GetComponent<CooperationDataPrefab>().SetData(cData, OnToggleAction);
    }

    void prepareData()
    {
        cooperationDataList.Clear();

        cooperationDataList.AddRange(TestData.cooperationDataList());

    }

    void OnToggleAction(UIToggle toggle)
    {
//        if (toggle.value)
//        {
//            wrapContent.itemSize = 320;
//        }
//        else
//        {
//            wrapContent.itemSize = 60;
//        }
//        wrapContent.WrapContent();
    }

}
