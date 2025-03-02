using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int score = 0;
    public float rate = 1;
    public int hardTime = 5;
    private float initSpawnRate;
    private Text scoreText;
    private Asteroid_Spawner spawn;
    private Animation textAnim;
    Highscores highscores;

    private void Start()
    {
        highscores = gameObject.GetComponent<Highscores>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Asteroid_Spawner>();
        textAnim = GameObject.FindGameObjectWithTag("Score").GetComponent<Animation>();
        initSpawnRate = spawn.spawnRate;
        StartCoroutine("ScoreCounter");
    }

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            scoreText.text = score.ToString();
            if (score % 10 == 0 && score != 0)
            {
                textAnim.Play();
                if(score % 50 == 0) StartCoroutine("Harder2");
                else StartCoroutine("Harder1");
            }
            score++;
            yield return new WaitForSeconds(rate);
        }
    }

    IEnumerator Harder1()
    {
        for (int i = 0; i < hardTime; i++)
        {
            spawn.spawnRate = 0.3f;
            yield return new WaitForSeconds(rate);
        }
        spawn.spawnRate = initSpawnRate;
    }

    IEnumerator Harder2()
    {
        for (int i = 0; i < hardTime; i++)
        {
            spawn.spawnRate = 0.2f;
            yield return new WaitForSeconds(rate);
        }
        spawn.spawnRate = initSpawnRate;
    }

    public void Death(){
        if(FileManagement.LoadUsername() != null){
            highscores.AddNewHighscore(FileManagement.LoadUsername(), score);         
        }
        SceneManager.LoadScene("Death");
    }
}
