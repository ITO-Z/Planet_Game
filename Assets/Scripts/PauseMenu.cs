using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public int respawnTime = 3;
    public Text Countdown;
    private Animation anim;

    private void Start() {
        anim = Countdown.GetComponent<Animation>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Countdown.gameObject.SetActive(true);
        StartCoroutine("Resumer");
        gameIsPaused = false;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    IEnumerator Resumer(){

        for(int i = 0; i < respawnTime; i++){
            Countdown.text = (respawnTime - i).ToString();
            yield return new WaitForSecondsRealtime(1);
            anim.Play();
        }
        Countdown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
