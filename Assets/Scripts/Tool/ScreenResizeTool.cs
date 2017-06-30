using UnityEngine;
using System.Collections;

public class ScreenResizeTool : MonoBehaviour
{

    public int ManualWidth = 640;
    public int ManualHeight = 960;

    void Awake()
    {
        AdaptiveUI();
    }

    void AdaptiveUI()
    {
        UIRoot uiRoot = GetComponent<UIRoot>();
        if (uiRoot != null)
        {
            //            Debug.LogError(System.Convert.ToSingle(Screen.height) / Screen.width);
            //            Debug.LogError(System.Convert.ToSingle(ManualHeight) / ManualWidth);
            if (System.Convert.ToSingle(Screen.height) / Screen.width > System.Convert.ToSingle(ManualHeight) / ManualWidth)
                uiRoot.manualHeight = Mathf.RoundToInt(System.Convert.ToSingle(ManualWidth) / Screen.width * Screen.height);
            else
                uiRoot.manualHeight = ManualHeight; 
        } 
        //        Debug.LogError(uiRoot.manualHeight);
    }
}