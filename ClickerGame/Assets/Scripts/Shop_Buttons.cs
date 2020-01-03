using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Buttons : MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject GamePanel;
    public GameObject SettingsPanel;
    public Button SoundSetting;
    public bool sound;
    public AudioSource playMusic;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        ShopPanel.SetActive(false);
        GamePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        sound=true;
        if (sound){
            playMusic.Play(0);
        }
        else{
            playMusic.Pause();
        }
        volumeSlider.value= playMusic.volume;
    
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
    public void openSettingsPanel(){
        GamePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void closeSettingsPanel(){
        GamePanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void toggleSound(){
        sound = !sound;
        if(sound){
            SoundSetting.GetComponent<Image>().color = Color.green;
        }
        else{
            SoundSetting.GetComponent<Image>().color = Color.red;
        }
        if (sound){
            playMusic.Play(0);
        }
        else{
            playMusic.Stop();
        }
    }
    public void VolumeControl (){
        playMusic.volume = volumeSlider.value;
    }
}
