using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    float TimeInterval;
    public CharacterController2D controller;
    public bool trigger;
    public float speed = 1000f;
    public float ac = 10f;
    private float horizontalMove = 0f;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        intervale();

    }
    void FixedUpdate()
    {
        anim.SetFloat("speed",horizontalMove);
        controller.Move(horizontalMove*Time.fixedDeltaTime, false, false);
    }
    void intervale()
    {
        TimeInterval += 1;
        if (TimeInterval >= 0 & TimeInterval <= 1000)
        {
            horizontalMove = speed;
        }
        if (TimeInterval >= 1000 & TimeInterval <= 2000)
        {
            horizontalMove = 0;

        }
        if (TimeInterval >= 2000)
        {
            TimeInterval = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "edge")
        {
            speed *= -1;
        }
        if (collision.gameObject.tag == "pet")
        {
            //collision.gameObject.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider trig)
    {
        
    }

}
