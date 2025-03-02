using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Sprite on, off;
    public Image button;
    //public AudioSource music;

    private void Start() {
       // music = music.GetComponent<AudioSource>();
        button = button.GetComponent<Image>();
        if(FileManagement.LoadVolume() == "true" ||FileManagement.LoadVolume() == null) AudioListener.volume = 1;
        else AudioListener.volume = 0;

        if(AudioListener.volume == 1) button.sprite = on;
        else button.sprite = off;
    }
    
    public void MuteMusic(){
        
        if(AudioListener.volume == 1){
            AudioListener.volume = 0;
            button.sprite = off;
            FileManagement.SaveVolume("false");
        }
        else{
            AudioListener.volume = 1;
            button.sprite = on;
            FileManagement.SaveVolume("true");
        }
    }
}
