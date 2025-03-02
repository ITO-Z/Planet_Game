using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backgrounds : MonoBehaviour
{
    public GameObject[] backgrounds;
    private Image background;

    private void Start() {
        background = GetComponent<Image>();
        int rand = Random.Range(0, backgrounds.Length);
        GameObject inst = Instantiate(backgrounds[rand]) as GameObject;
        inst.transform.parent = transform;
    }
}
