using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtCode : MonoBehaviour
{
    
}

public static class ExtensionTransform
{
    public static void SetlocalPositionY(this Transform trans, float y)
    {  
        trans.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);  
    }

    public static void SetlocalPositionX(this Transform trans, float x)
    {  
        trans.localPosition = new Vector3(x, trans.localPosition.y, trans.localPosition.z);  
    }

}