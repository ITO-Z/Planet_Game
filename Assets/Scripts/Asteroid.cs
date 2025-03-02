using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Transform target;
    private Vector2 direction;
    private float offset;
    public float speed;
    Score score;
    private SpriteRenderer rend;
    private Color col;
    private TrailRenderer trail;
    public GameObject dust;

    private void Start() {

        trail = GetComponent<TrailRenderer>();
        rend = GetComponent<SpriteRenderer>();
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
        target = GameObject.FindGameObjectWithTag("Planet").transform;

        offset = Random.Range(-0.03f, 0.03f);


        col = rend.color;
        col.a = 0;
        rend.color = col;
        trail.enabled = false;

        direction = (target.position - transform.position).normalized;

        direction.x = direction.x + offset;
        direction.y = direction.y + offset;
    }

    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Planet")){
            GameObject inst = Instantiate(dust) as GameObject;
            inst.transform.position = transform.position;
            Destroy(gameObject);
        } else if(other.CompareTag("Player")){
            score.Death();
        } else if(other.CompareTag("Background")){
            col.a = 1;
            rend.color = col;
            trail.enabled = true;
        }
    }

}
