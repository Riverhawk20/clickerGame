﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseLog : MonoBehaviour
{
    public GameObject AutoCookie;
    public AudioSource playSound;

    public void StartAutoCookie () {
        playSound.Play();
        AutoCookie.SetActive(true);
        GlobalCash.CashCount -= GlobalBaker.bakerValue;
        GlobalBaker.bakerValue *=2;
        GlobalBaker.turnOffButton=true;
        GlobalBaker.bakerPerSec += 1;
        GlobalBaker.numberOfBakers +=1;
        
    }
}
