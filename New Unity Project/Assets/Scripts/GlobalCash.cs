using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{

    public static int CashCount;
    public GameObject CashDisplay;
    public int internalCash;

    void Update()
    {
        internalCash = CashCount;
        CashDisplay.GetComponent<Text>().text = "$" + internalCash;  
    }
}
