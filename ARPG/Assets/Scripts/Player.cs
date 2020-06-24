using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    Animator Character_animator;
    Rigidbody2D PlayerRB;
    

    private bool OneTimeKey = false;
    void Start()
    {
        Character_animator = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        KeysPressed();
        KeysReleased();
        
    }
    private void KeysPressed()
    {

        if (Input.GetKeyDown(KeyCode.D) && OneTimeKey == false)
        {
            Character_animator.SetFloat("Xspeed", 0.5f);
            PlayerRB.velocity = new Vector2(3f , PlayerRB.velocity.y);
            OneTimeKey = true;
        }
         if (Input.GetKeyDown(KeyCode.A) && OneTimeKey == false)
        {
            Character_animator.SetFloat("Xspeed", -0.5f);
            PlayerRB.velocity = new Vector2(-3f, PlayerRB.velocity.y);
            OneTimeKey = true;

        }
        if (Input.GetKeyDown(KeyCode.W) && OneTimeKey == false)
        {
            Character_animator.SetFloat("Yspeed", 0.5f);
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 3f );
            OneTimeKey = true;

        }
        if (Input.GetKeyDown(KeyCode.S) && OneTimeKey == false)
        {
            Character_animator.SetFloat("Yspeed", -0.5f);
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, -3f );
            OneTimeKey = true;
        }
    }
    private void KeysReleased()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            Character_animator.SetFloat("Xspeed", 0.1f);
            Character_animator.SetFloat("Yspeed", 0f);
            PlayerRB.velocity = new Vector2(0f, 0f);
            OneTimeKey = false ;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Character_animator.SetFloat("Xspeed", -0.1f);
            Character_animator.SetFloat("Yspeed", 0f);
            PlayerRB.velocity = new Vector2(0f, 0f);
            OneTimeKey = false;

        }
      else   if (Input.GetKeyUp(KeyCode.W))
        {
            Character_animator.SetFloat("Yspeed", 0.1f);
            Character_animator.SetFloat("Xspeed", 0f);
            PlayerRB.velocity = new Vector2(0f, 0f);
            OneTimeKey = false;
        }
      else  if (Input.GetKeyUp(KeyCode.S))
        {
            Character_animator.SetFloat("Yspeed", -0.1f);
            Character_animator.SetFloat("Xspeed", 0f);
            PlayerRB.velocity = new Vector2(0f, 0f);
            OneTimeKey = false;
        }
    }
}
