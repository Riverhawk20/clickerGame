using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalBaker : MonoBehaviour
{
    public GameObject fakeButton;
    public GameObject fakeText;
    public GameObject realButton;
    public GameObject realText;
    public int currentCash;
    public static int bakerValue=5;
    public static bool turnOffButton = false;
    public GameObject bakerStats;
    public static int numberOfBakers; 
    public static int bakerPerSec;

    
    void Update()
    {
        currentCash = GlobalCash.CashCount;
        bakerStats.GetComponent<Text>().text = "Bakers: " + numberOfBakers + " @ " + bakerPerSec +" Cookies per second";
        fakeText.GetComponent<Text>().text = "Buy Baker - $" + bakerValue;
        realText.GetComponent<Text>().text = "Buy Baker - $" + bakerValue;
        if (currentCash >= bakerValue){
            fakeButton.SetActive(false);
            realButton.SetActive(true);
        }

        if (turnOffButton == true){
            realButton.SetActive(false);
            fakeButton.SetActive(true);
            turnOffButton=false;
        }
    }
}
