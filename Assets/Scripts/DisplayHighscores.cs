using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
    public Text[] highscoreTextName;
    public Text[] highscoreTextScore;
    public Text myHighscoreTextName;
    public Text myHighscoreTextScore;
    Highscores highscoreManager;
    public float refreshRate = 30;

    private void Start() {
        for(int i = 0; i < highscoreTextName.Length; i++){
            highscoreTextName[i].text = i+1 + ". Loading...";
            highscoreTextScore[i].text = null;
        }
        myHighscoreTextName.text = "Loading...";
        myHighscoreTextScore.text = null;

        highscoreManager = GetComponent<Highscores>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscores.Highscore[] highscoreList){
        for(int i = 0; i < highscoreTextName.Length; i++){
            highscoreTextName[i].text = i+1 + ". ";
            if(highscoreList.Length > i){
                highscoreTextName[i].text += highscoreList[i].username;
                highscoreTextScore[i].text = highscoreList[i].score.ToString();
            }
        }
    }

    public void OnMyHighscoreDownloaded(Highscores.Highscore[] highscoreList){
        string username = FileManagement.LoadUsername();
        for(int i = 0; i < highscoreList.Length; i++){
            if(highscoreList[i].username == username){
                myHighscoreTextName.text = i+1 + ". " + highscoreList[i].username;
                myHighscoreTextScore.text = highscoreList[i].score.ToString();
            }
        }
    }

    IEnumerator RefreshHighscores(){
        while(true){
            highscoreManager.DownloadHighscores();

            yield return new WaitForSeconds(refreshRate);
        }
    }
}
