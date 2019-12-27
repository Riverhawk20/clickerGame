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
    public Button MagnetUpgrade;
    public Button CPJUpgrade;
    public Button AutoUpgrade;
    public double APS;
    double autoUpgradeCost;
    double autoUpgradeAmount;
    public double CoinChanceUpgradeCost;
    //Random numbers adds up to 84
    int[] coinChanceUgradeAmount = {17, 10, 8, 6, 12, 10, 9, 12};
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
    string dispUnit2;
    double dispCash2;
    double magnetUpgradeCost;
    float magnetRadius;
    public static double CPJ;
    double CPJUpgradeCost;
    double CPJUpgradeAmount;
    double temp;
    double temp2;
    int swordLevel;
    int jumpLevel;
    //font makes this all automatically uppercase
    string[] units = {"K","M","B","T","aa","bb","cc","dd","ee","ff","gg","gg","ii","jj","kk","ll","mm","nn","oo","pp","qq","rr","ss","tt","uu","vv","ww","xx","yy","zz"}; 
    CircleCollider2D magnetCollider;
    void Start(){
        magnetCollider = GameObject.Find("Player").transform.GetChild(0).GetComponent<CircleCollider2D>();
        magnetCollider.enabled=false;
        CPH=1;
        CPJ=1;
        CPJUpgradeAmount=9;
        CPJUpgradeCost=5;
        swordUpgradeCost=40;
        swordUpgradeCPH=1;
        SwordUpgrade.onClick.AddListener(SwordUpgradeOnClick);
        VaultUpgrade.onClick.AddListener(VaultUpgradeOnClick);
        LuckyChanceUpgrade.onClick.AddListener(LuckyChanceOnClick);
        LuckyValueUpgrade.onClick.AddListener(LuckyValueOnClick);
        CoinChanceUpgrade.onClick.AddListener(CoinChanceOnClick);
        MagnetUpgrade.onClick.AddListener(MagnetUpgradeOnClick);
        CPJUpgrade.onClick.AddListener(CPJUpgradeOnClick);
        AutoUpgrade.onClick.AddListener(AutoUpgradeOnClick);
        APS=0;
        autoUpgradeAmount = 5;
        autoUpgradeCost=3;
        coinChance = 10;
        vaultLevel = 1;
        vaultUpgradeCost=10;
        luckyValue= 5000;
        luckyChance = 5;
        luckyChanceUpgradeCost = 50;
        luckyValueUpgradeCost = 50;
        CoinChanceUpgradeCost = 10;
        coinChanceUgradeAmountIndex=0;
        magnetRadius=0;
        magnetUpgradeCost=5;
        vaultText = "Upgrade Vault $" + vaultUpgradeCost.ToString("F3");
        InvokeRepeating("oncePerSecond", 0 , 1.0f);
    }
    void Update()
    {   displayCash=cash;
        dispUnit=numFormat(cash, displayCash);
        displayCash=numFormatNum(cash,displayCash);
        MoneyText.GetComponent<Text>().text = displayCash.ToString("F3") +dispUnit;
        MoneyTextShop.GetComponent<Text>().text = "" + displayCash.ToString("F3") + dispUnit;
        
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
        if(coinChanceUgradeAmountIndex!=7) CoinChanceUpgrade.GetComponentInChildren<Text>().text = "Coin Chance +" + coinChanceUgradeAmount[coinChanceUgradeAmountIndex] + "% $"+ displayCash.ToString("F3") + dispUnit;
        

        temp=magnetUpgradeCost;
        dispUnit=numFormat(magnetUpgradeCost, temp);
        displayCash=numFormatNum(magnetUpgradeCost, temp);
        if(magnetRadius==0){
            MagnetUpgrade.GetComponentInChildren<Text>().text = "Enable Magnet $" + displayCash.ToString("F3") + dispUnit;
        }
        else if(magnetRadius!=10){
            MagnetUpgrade.GetComponentInChildren<Text>().text = "Magnet Radius +0.5 $" + displayCash.ToString("F3") + dispUnit;
        }

        temp=CPJUpgradeCost;
        dispUnit=numFormat(CPJUpgradeCost, temp);
        displayCash=numFormatNum(CPJUpgradeCost, temp);
        temp2=CPJUpgradeAmount;
        dispUnit2=numFormat(CPJUpgradeAmount, temp2);
        dispCash2 = numFormatNum(CPJUpgradeAmount, temp2);     
        CPJUpgrade.GetComponentInChildren<Text>().text= "+$" + dispCash2.ToString("F3") + dispUnit2  + " per Jump $" + displayCash.ToString("F3") + dispUnit;
        
        temp=autoUpgradeCost;
        dispUnit=numFormat(autoUpgradeCost, temp);
        displayCash=numFormatNum(autoUpgradeCost, temp);
        temp2=autoUpgradeAmount;
        dispUnit2=numFormat(autoUpgradeAmount, temp2);
        dispCash2 = numFormatNum(autoUpgradeAmount, temp2);     
        AutoUpgrade.GetComponentInChildren<Text>().text= "+$" + dispCash2.ToString("F3") + dispUnit2  + " per Second $" + displayCash.ToString("F3") + dispUnit;

    }
    void oncePerSecond(){
        Money.cash += APS;
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
            swordUpgradeCost *= Mathf.Pow(1.2f, swordLevel);
            swordLevel++;
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
        if(cash >= CoinChanceUpgradeCost && coinChance!= 94){
            cash-= CoinChanceUpgradeCost;
            CoinChanceUpgradeCost *= 2;
            coinChance+= coinChanceUgradeAmount[coinChanceUgradeAmountIndex];
            print(coinChance);
            if(coinChanceUgradeAmountIndex==7){
                CoinChanceUpgrade.GetComponentInChildren<Text>().text = "Completed (Coin Chance)";
            }
            else  coinChanceUgradeAmountIndex++;
        }
    }

    void MagnetUpgradeOnClick(){
        if(cash >= magnetUpgradeCost && magnetRadius<10){
            if(magnetRadius==0){
                magnetCollider.enabled=true;
                magnetRadius=2;
            }
            else  magnetRadius += 0.5f;
            cash-=magnetUpgradeCost;
            magnetUpgradeCost*=2;
            magnetCollider.radius=magnetRadius;
        }
        if(magnetRadius==10){
            MagnetUpgrade.GetComponentInChildren<Text>().text = "Completed (Magnet Radius)";
        }
    }

    void CPJUpgradeOnClick(){
        if(cash >= CPJUpgradeCost){
            //this needs fixing
            cash-=CPJUpgradeCost;
            CPJ = 10 * jumpLevel * (jumpLevel/5 + 1);
            CPJUpgradeCost*=Mathf.Pow(1.15f, jumpLevel);
            jumpLevel++;  
            CPJUpgradeAmount = 20 * (jumpLevel/5+1);
        }
    }
    void AutoUpgradeOnClick(){
        if(cash >= autoUpgradeCost){
            cash-= autoUpgradeCost;
            APS += autoUpgradeAmount;
            autoUpgradeCost *= 2;
            autoUpgradeAmount *= 5;
        }
    }
    
}
