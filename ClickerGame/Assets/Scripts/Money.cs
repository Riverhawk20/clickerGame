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
    double[] CoinChanceUpgradeCost ={50, 500, 3000, 10000, 40000, 200000, 1000000, 8000000, 50000000};
    //Starts at 10 peaks at 33
    int[] coinChanceUgradeAmount = {3, 3, 3, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1}; //13 upgrades
    int coinChanceUgradeAmountIndex;
    //start at 4 end at 10 (+0.5%) so 12 upgrades
    double[] luckyChanceUpgradeCost = {60, 400, 2000,12000, 10000*4, 4*40000,200000*4, 4*1666666,4*123456789, 4.0f*3999999999, 4.0f*75000000000, 4.0f * 100000000000};
    int luckyChanceIndex;
    double swordUpgradeCost;
    double swordUpgradeCPH;
    double[] vaultUpgradeCost = {500000, 10000000, 1000000000};
    string vaultText;
    public static double cash;
    //cash per hit
    public static double CPH;
    public static int coinChance;
    public static int vaultLevel;
    public static double luckyValue;
    //remember this is chance once a coin is generated
    public static float luckyChance;
    double[] luckyValueUpgradeCost = {60, 400, 2000,12000, 10000*4, 4*40000,200000*4, 4*1666666,4*123456789, 4.0f*3999999999, 4.0f*75000000000, 4.0f * 100000000000};
    //intialized in start to 500 length 10
    double[] luckyValueUpgradeAmount = {100/10f,500/10f,3000/10f,10000/15f,40000/15f,200000/20f,1666666/20f,123456789/20f, 3999999999/20f, 75000000000/20f};
    int luckyValueIndex;
    public double displayCash;
    public string dispUnit;
    string dispUnit2;
    double dispCash2;
    double[] magnetUpgradeCost = {100, 500, 1500, 3000, 7000, 10000, 30000, 40000, 100000, 200000, 500000, 10000000, 50000000, 123456789, 100000000, 1000000000, 3999999999};
    int magnetIndex;
    float magnetRadius;
    public static double CPJ;
    double CPJUpgradeCost;
    double CPJUpgradeAmount;
    double temp;
    double temp2;
    int swordLevel;
    int jumpLevel;
    double[] baseCostAuto = {15,100,500,3000,10000,40000,200000,1666666,123456789, 3999999999, 75000000000};
    double[] rate= {0.1,0.5,4,10,40,100,400,6666,98765,999999, 10000000};
    int autoIndex=0;
    int autoOwned=0;
    //font makes this all automatically uppercase
    string[] units = {"K","M","B","T","aa","bb","cc","dd","ee","ff","gg","gg","ii","jj","kk","ll","mm","nn","oo","pp","qq","rr","ss","tt","uu","vv","ww","xx","yy","zz"}; 
    CircleCollider2D magnetCollider;
    public GameObject Player;
    public Text PerHitText;
    public Text PerSecondText;
    public Text PerJumpText;
    public Text CoinChanceText;
    public Text LuckyValueText;
    public Text LuckyChanceText;
    public Text MagnetText;
    public Text VaultLevelText;
    void Start(){
        magnetCollider = Player.transform.GetChild(0).GetComponent<CircleCollider2D>();
        magnetCollider.enabled=false;
        CPH=1;
        CPJ=1;
        CPJUpgradeAmount=1/10.0f;
        CPJUpgradeCost=20;
        swordUpgradeCost=50;
        swordUpgradeCPH=1/8.0f;
        jumpLevel=1;
        swordLevel = 1;
        SwordUpgrade.onClick.AddListener(SwordUpgradeOnClick);
        VaultUpgrade.onClick.AddListener(VaultUpgradeOnClick);
        LuckyChanceUpgrade.onClick.AddListener(LuckyChanceOnClick);
        LuckyValueUpgrade.onClick.AddListener(LuckyValueOnClick);
        CoinChanceUpgrade.onClick.AddListener(CoinChanceOnClick);
        MagnetUpgrade.onClick.AddListener(MagnetUpgradeOnClick);
        CPJUpgrade.onClick.AddListener(CPJUpgradeOnClick);
        AutoUpgrade.onClick.AddListener(AutoUpgradeOnClick);
        APS=0;
        autoUpgradeAmount = rate[0];
        autoUpgradeCost=baseCostAuto[0];
        coinChance = 10;
        vaultLevel = 1;
        luckyValue= 500;
        luckyValueIndex=0;
        luckyChance = 4;
        luckyChanceIndex=0;
        coinChanceUgradeAmountIndex=0;
        magnetRadius=0;
        magnetIndex=0;

        temp=vaultUpgradeCost[vaultLevel-1];
        dispUnit=numFormat(vaultUpgradeCost[vaultLevel-1], temp);
        displayCash=numFormatNum(vaultUpgradeCost[vaultLevel-1], temp);
        vaultText = "Upgrade Vault $" + displayCash.ToString("F3") + dispUnit;
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
        temp2=swordUpgradeCPH;
        dispUnit2=numFormat(swordUpgradeCPH, temp2);
        dispCash2 = numFormatNum(swordUpgradeCPH, temp2);
        SwordUpgrade.GetComponentInChildren<Text>().text= "+$" + dispCash2.ToString("F3")+ dispUnit2+ " per hit $" + displayCash.ToString("F3") + dispUnit;
        //stats text
        temp=CPH;
        dispUnit=numFormat(CPH, temp);
        displayCash=numFormatNum(CPH, temp);
        PerHitText.text = "Per Hit: $" + displayCash.ToString("F3") + dispUnit;

        VaultUpgrade.GetComponentInChildren<Text>().text= vaultText;
        VaultLevelText.text = "Vault Level: " + vaultLevel.ToString();

        temp=luckyChanceUpgradeCost[luckyChanceIndex];
        dispUnit=numFormat(luckyChanceUpgradeCost[luckyChanceIndex], temp);
        displayCash=numFormatNum(luckyChanceUpgradeCost[luckyChanceIndex], temp);
        if (luckyChanceIndex!=12) LuckyChanceUpgrade.GetComponentInChildren<Text>().text = "Lucky Coin Chance +0.5% $" + displayCash.ToString("F3") + dispUnit; 
        temp=luckyChance;
        dispUnit=numFormat(luckyChance, temp);
        displayCash=numFormatNum(luckyChance, temp);
        LuckyChanceText.text = "Lucky Coin Chance: " + displayCash + dispUnit+ "%";

        temp=luckyValueUpgradeCost[luckyValueIndex];
        dispUnit=numFormat(luckyValueUpgradeCost[luckyValueIndex], temp);
        displayCash=numFormatNum(luckyValueUpgradeCost[luckyValueIndex], temp);
        temp=luckyValueUpgradeAmount[luckyValueIndex];
        dispUnit2=numFormat(luckyValueUpgradeAmount[luckyValueIndex], temp);
        dispCash2=numFormatNum(luckyValueUpgradeAmount[luckyValueIndex], temp);
        if (luckyValueIndex!=10) LuckyValueUpgrade.GetComponentInChildren<Text>().text = "Lucky Coin Value +$" + dispCash2+ dispUnit2+ " $" + displayCash.ToString("F3") + dispUnit; 
        temp=luckyValue;
        dispUnit=numFormat(luckyValue, temp);
        displayCash=numFormatNum(luckyValue, temp);
        LuckyValueText.text = "Lucky Coin: $" + displayCash + dispUnit;

        temp=CoinChanceUpgradeCost[coinChanceUgradeAmountIndex];
        dispUnit=numFormat(CoinChanceUpgradeCost[coinChanceUgradeAmountIndex], temp);
        displayCash=numFormatNum(CoinChanceUpgradeCost[coinChanceUgradeAmountIndex], temp);
        if(coinChanceUgradeAmountIndex!=CoinChanceUpgradeCost.Length) CoinChanceUpgrade.GetComponentInChildren<Text>().text = "Coin Chance +" + coinChanceUgradeAmount[coinChanceUgradeAmountIndex] + "% $"+ displayCash.ToString("F3") + dispUnit;
        temp=coinChance;
        dispUnit=numFormat(coinChance, temp);
        displayCash=numFormatNum(coinChance, temp);
        CoinChanceText.text = "Coin Chance: " + displayCash + dispUnit + "%";

        
        if(magnetRadius==0){
            temp=magnetUpgradeCost[magnetIndex];
            dispUnit=numFormat(magnetUpgradeCost[magnetIndex], temp);
            displayCash=numFormatNum(magnetUpgradeCost[magnetIndex], temp);
            MagnetUpgrade.GetComponentInChildren<Text>().text = "Enable Magnet $" + displayCash.ToString("F3") + dispUnit;
        }
        else if(magnetRadius!=10){
            temp=magnetUpgradeCost[magnetIndex];
            dispUnit=numFormat(magnetUpgradeCost[magnetIndex], temp);
            displayCash=numFormatNum(magnetUpgradeCost[magnetIndex], temp);
            MagnetUpgrade.GetComponentInChildren<Text>().text = "Magnet Radius +0.5 $" + displayCash.ToString("F3") + dispUnit;
        }
        MagnetText.text= "Magnet Radius: " + magnetRadius + " tiles";

        temp=CPJUpgradeCost;
        dispUnit=numFormat(CPJUpgradeCost, temp);
        displayCash=numFormatNum(CPJUpgradeCost, temp);
        temp2=CPJUpgradeAmount;
        dispUnit2=numFormat(CPJUpgradeAmount, temp2);
        dispCash2 = numFormatNum(CPJUpgradeAmount, temp2);     
        CPJUpgrade.GetComponentInChildren<Text>().text= "+$" + dispCash2.ToString("F3") + dispUnit2  + " per Jump $" + displayCash.ToString("F3") + dispUnit;
        temp=CPJ;
        dispUnit=numFormat(CPJ, temp);
        displayCash=numFormatNum(CPJ, temp);
        PerJumpText.text = "Per Jump: $" + displayCash.ToString("F3") + dispUnit;
        
        temp=autoUpgradeCost;
        dispUnit=numFormat(autoUpgradeCost, temp);
        displayCash=numFormatNum(autoUpgradeCost, temp);
        temp2=autoUpgradeAmount;
        dispUnit2=numFormat(autoUpgradeAmount, temp2);
        dispCash2 = numFormatNum(autoUpgradeAmount, temp2);     
        AutoUpgrade.GetComponentInChildren<Text>().text= "+$" + dispCash2.ToString("F3") + dispUnit2  + " per Second $" + displayCash.ToString("F3") + dispUnit;
        temp=APS;
        dispUnit=numFormat(APS, temp);
        displayCash=numFormatNum(APS, temp);
        PerSecondText.text = "Auto Per Second: $" + displayCash + dispUnit;
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
            CPH =  1/8.0f*(swordLevel) + 1;
            //price = base cost * multipMathf.Pow(1.04f, swordLevel)lier^level
            swordUpgradeCost =  40* Mathf.Pow(1.06f,swordLevel);
            swordLevel++;
            // swordUpgradeCPH = ((swordLevel/5 + 1)*(1*swordLevel) + 1) - (((swordLevel-1)/5 + 1)*(1*(swordLevel)-1) + 1); 
        }
    }
    void VaultUpgradeOnClick(){
        if (cash >= vaultUpgradeCost[vaultLevel - 1] && vaultLevel!=4){
            cash-= vaultUpgradeCost[vaultLevel - 1];
            vaultLevel+=1;
            temp=vaultUpgradeCost[vaultLevel-1];
            dispUnit=numFormat(vaultUpgradeCost[vaultLevel-1], temp);
            displayCash=numFormatNum(vaultUpgradeCost[vaultLevel-1], temp);

            vaultText = "Upgrade Vault $" + displayCash.ToString("F3") + dispUnit;
            Vault.destroy=true;
            if(vaultLevel==4){
                vaultText = "Completed (Vault LEVEL)";
            }        
        }
    }
    void LuckyChanceOnClick(){
        if (cash >= luckyChanceUpgradeCost[luckyChanceIndex] && luckyChanceIndex!=12){
            cash-= luckyChanceUpgradeCost[luckyChanceIndex];
            luckyChanceIndex++;
            luckyChance += 0.5f;
        }
        if(luckyChanceIndex==12){
           LuckyChanceUpgrade.GetComponentInChildren<Text>().text = "Completed (Lucky Chance)"; 
        }
    }
    void LuckyValueOnClick(){
        if (cash >= luckyValueUpgradeCost[luckyChanceIndex] && luckyValueIndex!=10){
            cash-= luckyValueUpgradeCost[luckyChanceIndex];
            luckyValue += luckyValueUpgradeAmount[luckyValueIndex];
            luckyValueIndex++;
        }
        if(luckyValueIndex==10){
           LuckyValueUpgrade.GetComponentInChildren<Text>().text = "Completed (Lucky Value)"; 
        }
    }
    void CoinChanceOnClick(){
        if(cash >= CoinChanceUpgradeCost[coinChanceUgradeAmountIndex] && coinChanceUgradeAmountIndex!=12){
            cash-= CoinChanceUpgradeCost[coinChanceUgradeAmountIndex];
            coinChance+= coinChanceUgradeAmount[coinChanceUgradeAmountIndex];
            if(coinChanceUgradeAmountIndex==12){
                CoinChanceUpgrade.GetComponentInChildren<Text>().text = "Completed (Coin Chance)";
            }
            else  coinChanceUgradeAmountIndex++;
        }
    }

    void MagnetUpgradeOnClick(){
        if(cash >= magnetUpgradeCost[magnetIndex] && magnetRadius<10){
            if(magnetRadius==0){
                magnetCollider.enabled=true;
                magnetRadius=2;
            }
            else  magnetRadius += 0.5f;
            cash-=magnetUpgradeCost[magnetIndex];
            magnetIndex++;
            magnetCollider.radius=magnetRadius;
        }
        if(magnetRadius==10){
            MagnetUpgrade.GetComponentInChildren<Text>().text = "Completed (Magnet Radius)";
        }
    }

    void CPJUpgradeOnClick(){
        if(cash >= CPJUpgradeCost){
            cash-=CPJUpgradeCost;
            CPJ =  1/10.0f*(jumpLevel) + 1;
            CPJUpgradeCost =  20* Mathf.Pow(1.097f,jumpLevel);
            jumpLevel++;  
            CPJUpgradeAmount = 1/10.0f;
        }
    }
    void AutoUpgradeOnClick(){
        if(cash >= autoUpgradeCost){
            cash-= autoUpgradeCost;
            autoOwned++;
            // APS equals money per second
            autoUpgradeCost = baseCostAuto[autoIndex] * Mathf.Pow(1.15f, autoOwned);
            APS += rate[autoIndex];
            if(autoUpgradeCost>= baseCostAuto[autoIndex+1]){
                autoIndex++;
            }
            autoUpgradeAmount = rate[autoIndex];

        }
    }
    
}
