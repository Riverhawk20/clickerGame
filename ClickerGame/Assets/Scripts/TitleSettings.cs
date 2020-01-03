using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSettings : MonoBehaviour
{
    public GameObject TitlePanel;
    public GameObject GamePanel;
    void Start()
    {
        TitlePanel.SetActive(true);
        GamePanel.SetActive(false);
    }
    void StartGame(){
        TitlePanel.SetActive(false);
        GamePanel.SetActive(true);
    }
}
