using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Buttons : MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject GamePanel;
    // Start is called before the first frame update
    void Start()
    {
        ShopPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    // Update is called once per frame
    public void ShowShopPanel(){
            ShopPanel.SetActive(true);
            GamePanel.SetActive(false);
    }
     public void closeShopPanel(){
            ShopPanel.SetActive(false);
            GamePanel.SetActive(true);
    }
}
