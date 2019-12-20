using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public GameObject MoneyText;
    public GameObject MoneyTextShop;
    public Button SwordUpgrade;
    public int swordUpgradeCost;
    public int swordUpgradeCPH;
    public static int cash;
    //cash per hit
    public static int CPH;
    public static int coinChance;
    public static int vaultLevel;
    // Update is called once per frame
    void Start(){
        CPH=1;
        swordUpgradeCost=10;
        swordUpgradeCPH=2;
        SwordUpgrade.onClick.AddListener(SwordUpgradeOnClick);
        coinChance = 10;
        vaultLevel=1;
    }
    void Update()
    {
        MoneyText.GetComponent<Text>().text = "" + cash;
        MoneyTextShop.GetComponent<Text>().text = "" + cash;
        SwordUpgrade.GetComponentInChildren<Text>().text= "Sharper Sword $" + swordUpgradeCost;
    }
    void SwordUpgradeOnClick(){
        if(cash >= swordUpgradeCost){
            cash -= swordUpgradeCost;
            CPH +=  swordUpgradeCPH;
            swordUpgradeCost *= 2;
            swordUpgradeCPH *= 2;            
        }
      
    }
}
