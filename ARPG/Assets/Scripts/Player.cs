using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    Animator Character_animator;
    Rigidbody2D PlayerRB;
    void Start()
    {
        Character_animator = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeysPressed();
        KeysReleased();
    }
    private void KeysPressed()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Character_animator.SetFloat("Xspeed", 0.5f);
            PlayerRB.velocity = new Vector2(3f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Character_animator.SetFloat("Xspeed", -0.5f);
            PlayerRB.velocity = new Vector2(-3f, 0f);
        }
       else if (Input.GetKeyDown(KeyCode.W))
        {
            Character_animator.SetFloat("Yspeed", 0.5f);
            PlayerRB.velocity = new Vector2(0f, 3f);
        }
     else   if (Input.GetKeyDown(KeyCode.S))
        {
            Character_animator.SetFloat("Yspeed", -0.5f);
            PlayerRB.velocity = new Vector2(0f, -3f);
        }
    }
    private void KeysReleased()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            Character_animator.SetFloat("Xspeed", 0.1f);
            PlayerRB.velocity = new Vector2(0f, 0f);
        }
       else if (Input.GetKeyUp(KeyCode.A))
        {
            Character_animator.SetFloat("Xspeed", -0.1f);
            PlayerRB.velocity = new Vector2(0f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Character_animator.SetFloat("Yspeed", 0.1f);
            PlayerRB.velocity = new Vector2(0f, 0f);
        }
       else if (Input.GetKeyUp(KeyCode.S))
        {
            Character_animator.SetFloat("Yspeed", 0.1f);
            PlayerRB.velocity = new Vector2(0f, 0f);
        }
    }
}
