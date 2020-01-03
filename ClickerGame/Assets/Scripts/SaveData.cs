using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    //From ShopButtons Script
    public float Volume; 
    public bool PlayMusic;
    //From Money Class
    public int VaultLevel;
    public double CoinsPerJumpUpgradeCost;
    public double CoinsPerJumpUpgradeAmount;
    public double CoinsPerJump;
    public int JumpLevel;
    public bool MagnetEnabled;
    public float MagnetRadius;
    public int MagnetIndex;
    public double AutoPerSecond;
    public double AutoCost;
    public double AutoUpgradeAmount;
    public int AutoIndex;
    public int AutoOwned;
    public int CoinChance;

    public int CoinChanceUpgradeAmountIndex;
    public double CoinsPerHit;

    public double SwordUpgradeCost;
    public double SwordUpgradeAmountCPH;
    public int SwordLevel;
    public double LuckyValue;
    public int LuckyValueIndex;

    public float LuckyChance;
    public int LuckyChanceIndex;
    public double Cash;


    public SaveData(Money Money){
        Volume = GameObject.Find("EventSystem").GetComponent<Shop_Buttons>().volumeSlider.value;
        PlayMusic = GameObject.Find("EventSystem").GetComponent<Shop_Buttons>().sound;
        VaultLevel = Money.vaultLevel;
        CoinsPerJumpUpgradeCost = Money.CPJUpgradeCost;
        CoinsPerJumpUpgradeAmount = Money.CPJUpgradeAmount;
        CoinsPerJump = Money.CPJ;
        JumpLevel = Money.jumpLevel;
        MagnetEnabled = Money.magnetCollider.enabled;
        MagnetRadius = Money.magnetRadius;
        MagnetIndex = Money.magnetIndex;
        AutoPerSecond = Money.APS;
        AutoCost = Money.autoUpgradeCost;
        AutoUpgradeAmount = Money.autoUpgradeAmount;
        AutoIndex = Money.autoIndex;
        AutoOwned = Money.autoOwned;
        CoinChance = Money.coinChance;
        CoinChanceUpgradeAmountIndex = Money.coinChanceUgradeAmountIndex;
        CoinsPerHit = Money.CPH;
        SwordUpgradeCost = Money.swordUpgradeCost;
        SwordUpgradeAmountCPH = Money.swordUpgradeCPH;
        SwordLevel = Money.swordLevel;
        LuckyValue = Money.luckyValue;
        LuckyValueIndex = Money.luckyValueIndex;
        LuckyChance = Money.luckyChance;
        LuckyChanceIndex = Money.luckyChanceIndex;
        Cash = Money.cash;  
          
    }


}
