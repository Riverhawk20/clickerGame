using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public GameObject MoneyText;
    public Button SwordUpgrade;
    public int swordUpgradeCost;
    public int swordUpgradeCPH;
    public static int cash;
    //cash per hit
    public static int CPH;
    // Update is called once per frame
    void Start(){
        CPH=1;
        swordUpgradeCost=50;
        swordUpgradeCPH=2;
        SwordUpgrade.onClick.AddListener(SwordUpgradeOnClick);
    }
    void Update()
    {
        MoneyText.GetComponent<Text>().text= "" +cash;
        SwordUpgrade.GetComponentInChildren<Text>().text= "Sword Upgrade - $" + swordUpgradeCost;
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
