using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] LoginPage loginPageObject;
    [SerializeField] MenuPage menuPageObject;
    [SerializeField] GameObject customerTypePageObject;
    [SerializeField] GameObject keywordPageObject;
    [SerializeField] GameObject hotSearchPageObject;
    [SerializeField] GameObject customerDataPageObject;
    [SerializeField] GameObject cooperationDataPageObject;

    [SerializeField] GameObject pageManager;
    [SerializeField] GameObject bottomBar;
    [SerializeField] GameObject waitingPanel;


    public CustomerTypeData nowCustomerType;


    enum PageType
    {
        CustomerData,
        Keyword,
        HotSearch,
        Cooperation,
        Order,
        CustomerType,
        None
    }

    PageType nowPage = PageType.None;

    static Main mainIns;

    public static Main Instants
    {
        get
        {
            return mainIns;
        }
    }


    void Awake()
    {
        mainIns = this;
        Application.targetFrameRate = 10;
        if (pageManager.transform.GetChildCount() == 0)
        {
            NGUITools.AddChild(pageManager, loginPageObject.gameObject);
        }
        bottomBar.SetActive(false);
    }

    public void Reset()
    {
        if (pageManager.transform.GetChildCount() != 0)
        {
            for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
            {
                Destroy(pageManager.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            Awake();
        }
    }


    public void CloseApp()
    {
        Application.Quit();
    }


    public void LoginFinished()
    {

        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
        NGUITools.AddChild(pageManager, menuPageObject.gameObject);
        bottomBar.SetActive(true);
    }


    public void GotoCustomerTypePage()
    {
        WaitingPanel(false);
        if (nowPage == PageType.CustomerType)
            return;
        nowPage = PageType.CustomerType;
        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
        NGUITools.AddChild(pageManager, customerTypePageObject.gameObject);
    }

    public void GotoKeywordPage()
    {
        if (nowPage == PageType.Keyword)
            return;
        nowPage = PageType.Keyword;
        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
        WaitingPanel(true);
        NGUITools.AddChild(pageManager, keywordPageObject.gameObject);
    }

    public void GotoHotSearchPage()
    {
        if (nowPage == PageType.HotSearch)
            return;
        nowPage = PageType.HotSearch;
        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
        WaitingPanel(true);
        NGUITools.AddChild(pageManager, hotSearchPageObject.gameObject);
    }

    public void GotoCooperationPage()
    {
        WaitingPanel(false);
        if (nowPage == PageType.Cooperation)
            return;
        nowPage = PageType.Cooperation;
        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
        NGUITools.AddChild(pageManager, cooperationDataPageObject.gameObject);
    }

    public void GotoOrderPage()
    {
        WaitingPanel(false);
        if (nowPage == PageType.Order)
            return;
        nowPage = PageType.Order;
        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
//        NGUITools.AddChild(pageManager, hotSearchPageObject.gameObject);
    }

    public void GotoCustomerDataPage()
    {
        WaitingPanel(false);
        if (nowPage == PageType.CustomerData)
            return;
        nowPage = PageType.CustomerData;
        for (int i = 0; i < pageManager.transform.GetChildCount(); i++)
        {
            Destroy(pageManager.transform.GetChild(i).gameObject);
        }
        NGUITools.AddChild(pageManager, customerDataPageObject.gameObject);
    }



    public void WaitingPanel(bool isShow)
    {
        waitingPanel.SetActive(isShow);
    }



}
