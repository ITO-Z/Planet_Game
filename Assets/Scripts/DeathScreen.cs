using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim.Play("Death", 0);
    }
}
