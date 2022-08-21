using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed = 360;
    private Rigidbody2D rb;
    /*SoundHandler soundHandler;*/
    // Start is called before the first frame update
    void Start()
    {
        /*soundHandler = GetComponent<SoundHandler>();*/
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            /*SoundHandler.PlayWalkingSound();*/
        }
    }
    private void FixedUpdate()
    {
        Move();        
    }

    void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        float moveX = inputX * Time.fixedDeltaTime;
        float moveY = inputY * Time.fixedDeltaTime;
        rb.velocity = new Vector2(moveX * speed, moveY * speed);        
    }
}
