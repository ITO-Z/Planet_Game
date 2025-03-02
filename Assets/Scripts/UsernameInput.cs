using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour
{
   public string username;
   private string lastUsername;
   public GameObject inputField;
   public GameObject errorField;
   public GameObject loginPopup;
   Highscores highscores;
   private int score;

    private void Start() {
        highscores = gameObject.GetComponentInChildren<Highscores>();
        errorField.SetActive(false);

        if(FileManagement.LoadUsername() == null){
            loginPopup.SetActive(true);;
        }
    }

   public void GetUsername(){
        username = inputField.GetComponent<Text>().text;

        for(int i = 0; i < highscores.highscoresList.Length; i++){
            if(username == highscores.highscoresList[i].username){
                errorField.SetActive(true);
                break;
            } else errorField.SetActive(false);
        }
        if(!errorField.activeSelf){
            FileManagement.SaveUsername(username);
            highscores.AddNewHighscore(username, 0);
            loginPopup.SetActive(false);
            highscores.DownloadHighscores();
            lastUsername = username;
        }
    }
}
