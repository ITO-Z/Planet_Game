using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 randPos;
    public GameObject prefab;
    public float spawnRate;


    private void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        StartCoroutine(asteroidWave());
    }

    IEnumerator asteroidWave(){
        while(true){
            yield return new WaitForSeconds(spawnRate);
            RandPos();
            SpawnAst();
        }

    }
    private void SpawnAst(){
        GameObject ast = Instantiate(prefab) as GameObject;
        ast.transform.position = randPos;
        ast.transform.parent = transform;
    }
    private Vector2 RandPos(){
        int rand = Random.Range(1,5);

    if(rand == 1){
        randPos = new Vector2(screenBounds.x + 1, Random.Range(-screenBounds.y, screenBounds.y));
    } else if(rand == 2){
        randPos = new Vector2(-screenBounds.x - 1, Random.Range(-screenBounds.y, screenBounds.y));
    } else if(rand == 3){
        randPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + 1);
    } else if(rand == 4){
        randPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - 1);
    }

        return randPos;
    }

    /*private Vector2 RandPos2(){
        int rand = Random.Range(1,5);

    if(rand == 1){
        randPos = new Vector2(background.transform.localScale.x / 2, Random.Range(-background.transform.localScale.y / 2, background.transform.localScale.y / 2));
    } else if(rand == 2){
        randPos = new Vector2(-background.transform.localScale.x / 2, Random.Range(-background.transform.localScale.y / 2, background.transform.localScale.y / 2));
    } else if(rand == 3){
        randPos = new Vector2(Random.Range(-background.transform.localScale.x / 2, background.transform.localScale.x / 2), background.transform.localScale.y / 2);
    } else if(rand == 4){
        randPos = new Vector2(Random.Range(-background.transform.localScale.x / 2, background.transform.localScale.x / 2), -background.transform.localScale.y / 2);
    }

        return randPos;
    }*/


}
