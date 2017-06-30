using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeywordPage : MonoBehaviour
{
    void Start()
    {
     
        UniWebView _webView = GetComponent<UniWebView>();
        _webView.Show();

        _webView.url = "http://112.74.48.207:8888/51lvye/priority/search.do";

        _webView.insets = new UniWebViewEdgeInsets(0, 0, 160, 0);
        _webView.OnLoadComplete += OnLoadComplete;

        _webView.Load();

    }

    void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success)
        {
            // Great, everything goes well. Show the web view now.
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
