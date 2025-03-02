using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveInput;
    public GameObject player;
    public float speed;
    private bool facingRight = true;
    public bool isComputer = true;
    private Animator anim;
    
    private void Start() {
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        MoveInput();
        Move();
        if(facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }
        if(moveInput == 0) anim.SetBool("isRunning", false);
        else anim.SetBool("isRunning", true);
    }
    private float MoveInput(){
        
        if(isComputer == true){
            moveInput = Input.GetAxisRaw("Horizontal");
        } else{
            if(Input.GetMouseButton(0)){
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(mousePos.x > .5){
                    moveInput = 1;
                }
                else if(mousePos.x < -.5){
                    moveInput = -1;
                }
            } else moveInput = 0;
        }

        return moveInput;
    }

    private void Move(){
        transform.Rotate(Vector3.back, moveInput * speed * Time.deltaTime);
    }
 
    private void Flip(){
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
