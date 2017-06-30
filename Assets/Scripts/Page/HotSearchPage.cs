using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSearchPage : MonoBehaviour
{

    void Start()
    {
        
        UniWebView _webView = GetComponent<UniWebView>();
        _webView.Show();

        _webView.url = "https://aso100.com/trend/hotSearch";

        _webView.insets = new UniWebViewEdgeInsets(0, 0, 160, 0);
        _webView.OnLoadComplete += OnLoadComplete;

        _webView.Load();

    }

    void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success)
        {
            Main.Instants.WaitingPanel(false);
            webView.Show();
        }
        else
        {
            // Oops, something wrong.
            Debug.LogError("Something wrong in web view loading: " + errorMessage);
        }
    }
}
