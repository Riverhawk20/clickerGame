using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public GameObject MoneyText;
    public GameObject MoneyTextShop;
    public Button SwordUpgrade;
    public Button VaultUpgrade;
    public int swordUpgradeCost;
    public int swordUpgradeCPH;
    public int vaultUpgradeCost;
    string vaultText;
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
        VaultUpgrade.onClick.AddListener(VaultUpgradeOnClick);
        coinChance = 50;
        vaultLevel = 1;
        vaultUpgradeCost=10;
        vaultText = "Upgrade Vault $" + vaultUpgradeCost;
    }
    void Update()
    {
        MoneyText.GetComponent<Text>().text = "" + cash;
        MoneyTextShop.GetComponent<Text>().text = "" + cash;
        SwordUpgrade.GetComponentInChildren<Text>().text= "Sharper Sword $" + swordUpgradeCost;
        VaultUpgrade.GetComponentInChildren<Text>().text= vaultText;
    }
    void SwordUpgradeOnClick(){
        if(cash >= swordUpgradeCost){
            cash -= swordUpgradeCost;
            CPH +=  swordUpgradeCPH;
            swordUpgradeCost *= 2;
            swordUpgradeCPH *= 2; 
        }
    }
    void VaultUpgradeOnClick(){
        if (cash >= vaultUpgradeCost && vaultLevel!=4){
            cash-= vaultUpgradeCost;
            vaultLevel+=1;
            vaultUpgradeCost +=10;
            vaultText = "Upgrade Vault $" + vaultUpgradeCost;
            Vault.destroy=true;
            if(vaultLevel==4){
                vaultText = "Completed (Vault LEVEL)";
            }        
        }
    }
}
