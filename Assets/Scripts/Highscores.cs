using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Highscores : MonoBehaviour
{
   const string privateCode = "IrzMHVQ19E-p6eE8fkBiPwyH0WZjd6GEWVEOMvRZK66Q";
   const string publicCode = "62e001cd8f40bf84ec89a851";
   const string webURL = "http://dreamlo.com/lb/";

   public Highscore[] highscoresList;
   DisplayHighscores highscoresDisplay;


	private void Awake() {
		highscoresDisplay = GetComponent<DisplayHighscores>();
	}

   public void AddNewHighscore(string username, int score){
      StartCoroutine(UploadNewHighscore(username, score));
   }

   public void DownloadHighscores(){
	   StartCoroutine("DownloadHighscoresFromDatabase");
   }


   IEnumerator UploadNewHighscore(string username, int score){
	UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
    yield return www.SendWebRequest();

    if(string.IsNullOrEmpty(www.error)){
        print("Upload Successful!");
    } else{
        print("Error uploading" + www.error);
    }
   }

   IEnumerator DownloadHighscoresFromDatabase(){
	UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
    yield return www.SendWebRequest();

    if(string.IsNullOrEmpty(www.error)){
      FormatHighscores(www.downloadHandler.text);
		highscoresDisplay.OnHighscoresDownloaded(highscoresList);
      highscoresDisplay.OnMyHighscoreDownloaded(highscoresList);
    } else{
      print("Error downloading" + www.error);
    }
   }


   void FormatHighscores(string textStream){
	string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
	highscoresList = new Highscore[entries.Length];

	for(int i = 0; i < entries.Length; i++){
		string[] entryInfo = entries[i].Split(new char[]{'|'});
		string username = entryInfo[0];
		int score = int.Parse(entryInfo[1]);
		highscoresList[i] = new Highscore(username, score);

		//print(highscoresList[i].username + ": " + highscoresList[i].score);
	   }
   }

   public struct Highscore{
	   public string username;
	   public int score;

	   public Highscore(string _username, int _score){
		   username = _username;
		   score = _score;
	   }
   }
}
