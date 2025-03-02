using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject[] planets;

    private void Start() {
        int rand = Random.Range(0, planets.Length);

        GameObject planetInstance = Instantiate(planets[rand]);
        Vector2 scaler = planetInstance.transform.localScale;
        scaler = new Vector2(.2f, .2f);
        planetInstance.transform.localScale = scaler;
        transform.parent = transform;
    }
}
