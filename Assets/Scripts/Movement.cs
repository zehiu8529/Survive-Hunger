using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    SoundHandler soundHandler;
    [SerializeField]
    private Animator spriteRenderer;
    [SerializeField]
    private float speed = 360;
    private Rigidbody2D rb;
    [SerializeField] float walkRate = 1f;    
    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
       
        soundHandler = GameObject.Find("SoundHandler").GetComponent<SoundHandler>();        
    }


    /// <summary>
    /// Make character move when there is input from player
    /// </summary>
    public void Move()
    {
        float inputX = GetInput().x;
        float inputY = GetInput().y;
        float moveX = inputX * Time.fixedDeltaTime;
        float moveY = inputY * Time.fixedDeltaTime;
        rb.velocity = new Vector2(moveX * speed, moveY * speed);
        // Play walking or fast walking sound
        soundHandler.PlayWalkingSound(walkRate);
        // Play animation when input is higher than 0.01
        if(Mathf.Abs(GetInput().x) > 0.01f || Mathf.Abs(GetInput().y) > 0.01f)
        {
            spriteRenderer.SetFloat("Velocity",0.1f);
        }
        else
        {
            spriteRenderer.SetFloat("Velocity",-0.1f);
        }
        

    }

    /// <summary>
    /// Get input from player
    /// </summary>
    /// <returns>Return Vector2 contains two values horizontal and vertical input</returns>
    private Vector2 GetInput()
    {
        Vector2 input;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        return input;
    }
}
