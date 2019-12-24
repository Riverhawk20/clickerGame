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
    public Button LuckyChanceUpgrade;
    public Button LuckyValueUpgrade;
    public Button CoinChanceUpgrade;
    public double CoinChanceUpgradeCost;
    //Random numbers adds up to 88
    public int[] coinChanceUgradeAmount = {17, 10, 8, 6, 12, 10, 9, 12};
    int coinChanceUgradeAmountIndex;
    public double luckyChanceUpgradeCost;
    public double swordUpgradeCost;
    public double swordUpgradeCPH;
    public double vaultUpgradeCost;
    string vaultText;
    public static double cash;
    //cash per hit
    public static double CPH;
    public static int coinChance;
    public static int vaultLevel;
    public static double luckyValue;
    //remember this is chance once a coin is generated
    public static int luckyChance;
    public double luckyValueUpgradeCost;
    public double displayCash;
    public string dispUnit;
    double temp;
    string[] units = {"K","M","B","T","AA","BB","CC","DD","EE","FF","GG","HH","II","jj","kk","ll","mm","nn","oo","pp","qq","rr","ss","tt","uu","vv","ww","xx","yy","zz"}; 
    // Update is called once per frame
    void Start(){
        CPH=1;
        swordUpgradeCost=10;
        swordUpgradeCPH=2;
        SwordUpgrade.onClick.AddListener(SwordUpgradeOnClick);
        VaultUpgrade.onClick.AddListener(VaultUpgradeOnClick);
        LuckyChanceUpgrade.onClick.AddListener(LuckyChanceOnClick);
        LuckyValueUpgrade.onClick.AddListener(LuckyValueOnClick);
        CoinChanceUpgrade.onClick.AddListener(CoinChanceOnClick);
        coinChance = 16;
        vaultLevel = 1;
        vaultUpgradeCost=10;
        luckyValue= 5000;
        luckyChance = 5;
        luckyChanceUpgradeCost = 50;
        luckyValueUpgradeCost = 50;
        CoinChanceUpgradeCost = 10;
        coinChanceUgradeAmountIndex=0;
        vaultText = "Upgrade Vault $" + vaultUpgradeCost;
    }
    void Update()
    {   displayCash=cash;
        dispUnit=numFormat(cash, displayCash);
        displayCash=numFormatNum(cash,displayCash);
        if (dispUnit==""){
            MoneyText.GetComponent<Text>().text = displayCash + dispUnit;
            MoneyTextShop.GetComponent<Text>().text = "" + displayCash + dispUnit;
        }
        else{
            MoneyText.GetComponent<Text>().text = displayCash.ToString("F3") +dispUnit;
            MoneyTextShop.GetComponent<Text>().text = "" + displayCash.ToString("F3") + dispUnit;
        }
        
        temp=swordUpgradeCost;
        dispUnit=numFormat(swordUpgradeCost, temp);
        displayCash=numFormatNum(swordUpgradeCost, temp);
        SwordUpgrade.GetComponentInChildren<Text>().text= "Sharper Sword $" + displayCash.ToString("F3") + dispUnit;

        VaultUpgrade.GetComponentInChildren<Text>().text= vaultText;

        temp=luckyChanceUpgradeCost;
        dispUnit=numFormat(luckyChanceUpgradeCost, temp);
        displayCash=numFormatNum(luckyChanceUpgradeCost, temp);
        LuckyChanceUpgrade.GetComponentInChildren<Text>().text = "Lucky Coin Chance +1% $" + displayCash.ToString("F3") + dispUnit; 

        temp=luckyValueUpgradeCost;
        dispUnit=numFormat(luckyValueUpgradeCost, temp);
        displayCash=numFormatNum(luckyValueUpgradeCost, temp);
        LuckyValueUpgrade.GetComponentInChildren<Text>().text = "Double Lucky Coin Value $" + displayCash.ToString("F3") + dispUnit; 

        temp=CoinChanceUpgradeCost;
        dispUnit=numFormat(CoinChanceUpgradeCost, temp);
        displayCash=numFormatNum(CoinChanceUpgradeCost, temp);
        CoinChanceUpgrade.GetComponentInChildren<Text>().text = "Coin Chance +" + coinChanceUgradeAmount[coinChanceUgradeAmountIndex] + "% $"+ displayCash.ToString("F3") + dispUnit;

    }
    string numFormat(double num, double disp){
       double n = num; 
       double bigNumber = 1000;
       int pos = -1;
       string unit;
       if (n >= bigNumber){
           while( n >= bigNumber){
            bigNumber *= 1000;
            pos++;
           }
           n /= (bigNumber/1000);
           unit = units[pos];
       } 
       else unit="";
       disp=n;
       return unit;
    }
    double numFormatNum(double num, double disp){
       double n = num; 
       double bigNumber = 1000;
       int pos = -1;
       string unit;
       if (n >= bigNumber){
           while( n >= bigNumber){
            bigNumber *= 1000;
            pos++;
           }
           n /= (bigNumber/1000);
           unit = units[pos]; 
       } 
       else unit="";
       disp=n;
       return disp;
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
            vaultUpgradeCost *=1000;

            temp=vaultUpgradeCost;
            dispUnit=numFormat(vaultUpgradeCost, temp);
            displayCash=numFormatNum(vaultUpgradeCost, temp);

            vaultText = "Upgrade Vault $" + displayCash.ToString("F3") + dispUnit;
            Vault.destroy=true;
            if(vaultLevel==4){
                vaultText = "Completed (Vault LEVEL)";
            }        
        }
    }
    void LuckyChanceOnClick(){
        if (cash >= luckyChanceUpgradeCost && luckyChance<=99){
            cash-= luckyChanceUpgradeCost;
            luckyChanceUpgradeCost*=2;
            luckyChance ++;
        }
        if(luckyChance==99){
           LuckyChanceUpgrade.GetComponentInChildren<Text>().text = "Completed (Lucky Chance)"; 
        }
    }
    void LuckyValueOnClick(){
        if (cash >= luckyValueUpgradeCost){
            cash-= luckyValueUpgradeCost;
            luckyValueUpgradeCost*=2;
            luckyValue *= 2;
        }
    }
    void CoinChanceOnClick(){
        if(cash >= CoinChanceUpgradeCost && coinChanceUgradeAmountIndex!=8){
            cash-= CoinChanceUpgradeCost;
            CoinChanceUpgradeCost *= 2;
            coinChance+= coinChanceUgradeAmount[coinChanceUgradeAmountIndex];
            coinChanceUgradeAmountIndex++;
            if(coinChanceUgradeAmountIndex==8){
                CoinChanceUpgrade.GetComponentInChildren<Text>().text = "Completed (Coin Chance)";
            }
        }
    }
    
}
