using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScr : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rig2D;
    [SerializeField]
    Animator animatorcontroller;
    [SerializeField]
    SpriteRenderer marioSprite;
    [SerializeField]
    float setUpSpeed = 2;
    bool isGrounded = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveMario();
        JumpMario();

	}

    void MoveMario()
    {
       
        float speed = setUpSpeed * Time.deltaTime;
        if(Input.GetAxis("Horizontal") >=0.01)
        {
            transform.Translate(Vector2.right * speed);
            marioSprite.flipX = true;
            if (isGrounded)
            {
                animatorcontroller.SetFloat("speed", 1f);
            }
        }
        if (Input.GetAxis("Horizontal") <= -0.01)
        {
            transform.Translate(Vector2.left * speed);
            marioSprite.flipX = false;
            if (isGrounded)
            {
                animatorcontroller.SetFloat("speed", 1f);
            }
        }
        if(Input.GetAxis("Horizontal")==0)
        {
            if (isGrounded)
            {
                animatorcontroller.SetFloat("speed", 0);
            }
        }

    }

    void JumpMario()
    {
        if(Input.GetAxis("Jump") !=0 && isGrounded)
        {
            isGrounded = false;
            rig2D.AddForce(Vector2.up * 4,ForceMode2D.Impulse);
        }
        if(!isGrounded)
        {
            animatorcontroller.SetBool("ground", false);
        }
        else
        {
            animatorcontroller.SetBool("ground", true);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.layer==9)
        {
            isGrounded = true;
        }
        if(other.gameObject.layer==10)
        {
            Application.LoadLevel(0);
        }
    }
}
