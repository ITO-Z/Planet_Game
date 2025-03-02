using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public GameObject animator;
    private Animator transition;
    public Animator musicAnim;
    public float transitionTime = 1;


    private void Awake() {
        animator.SetActive(true);
        transition = animator.GetComponent<Animator>();
    }
    public void LoadLevel(int sceneIndex){
        Time.timeScale = 1;
        if(SceneManager.GetActiveScene().buildIndex == 1){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SetActive(false);
        }
        StartCoroutine(Load(sceneIndex));
    }

    IEnumerator Load(int sceneIndex){
        transition.SetTrigger("Start");
        musicAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
