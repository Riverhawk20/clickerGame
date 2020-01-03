using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{

    public static int CookieCount;
    public GameObject CookieDisplay;
    public int internalCookie;

    void Update()
    {
        internalCookie = CookieCount;
        CookieDisplay.GetComponent<Text>().text = "Cookies: " + internalCookie;  
    }
}
