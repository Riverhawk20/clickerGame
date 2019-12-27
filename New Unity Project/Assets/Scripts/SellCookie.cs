using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellCookie : MonoBehaviour
{
    public GameObject textBox;
    public GameObject StatusBox;

    public void ClickTheButton ()
    {
        if (GlobalCookies.CookieCount == 0){
            StatusBox.GetComponent<Text>().text = "Not enough cookies to sell. Make more!";
            StatusBox.GetComponent<Animation>().Play("StatusAnim");
        }
        else {
            GlobalCookies.CookieCount-=1;
            GlobalCash.CashCount+=1;
        }
    }

}
