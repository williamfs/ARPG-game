using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] GameObject player;
    [SerializeField] LayerMask Player_Layer;
    float velocX = 0f;
     float velocY = 0f;

    float distanceX;
    float distanceY;
    bool player_detected = false;
    public enum Monsters { glutonny, timblers };
    public Monsters monsters;
    // Start is called before the first frame update

    Rigidbody2D EnemyRB;
    Vector2 distance;
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        /*if (monsters == Monsters.glutonny) {
            InvokeRepeating("Calculus", 0.001f, 0.5f);
        }*/
      
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.rotation = quaternion.identity;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2f);
        Velocity();
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(velocX, velocY), 10, Player_Layer);
      
        if(hit ||  Vector2.Distance(transform.position,player.transform.position)<=9)
        {
            player_detected = true;
            Debug.Log("hit on player");
           
        }
         if(player_detected == true && Vector2.Distance(transform.position,player.transform.position)>=10)
        {
            player_detected = false;
        }
      
      

    }
   
    private void OnDrawGizmos()
    {
         
         Vector2 direction2 = new Vector2(velocX, velocY) * 10;
        // Vector2 direction2 = new Vector2.Distance(transform.position, player.transform.position);
        Debug.DrawRay(transform.position, direction2,Color.red);

    
        
    }

    private void Velocity()
    {
        EnemyRB.velocity = new Vector2(velocX, velocY);
    }
    private void Calculus()
    {
        if (player_detected == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2f );
            
           distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
           distanceY = Mathf.Abs(player.transform.position.y - transform.position.y);

           if (distanceX < distanceY)
           {



               if (player.transform.position.y > transform.position.y)//if Y is greater than X that means that the enemy is on the bottom for the player, other wise is on the top. 
               {
                    Debug.Log("The player is on the top");
                   velocX = 0f;
                   velocY = 2;


               }
               if (player.transform.position.y < transform.position.y)
               {
                     Debug.Log("The player is on the button");
                   velocX = 0f;
                   velocY = -2f;


               }

           }
           //if(distanceX> distanceY && lock_Movement == false)
           else
           {

               if (player.transform.position.x > transform.position.x)
               {
                      Debug.Log("The player is on my right");
                   velocX = 2f;
                   velocY = 0f;

               }
               else if (player.transform.position.x < transform.position.x)
               {
                  Debug.Log("The player is on my left");
                   velocX = -2f;
                   velocY = 0f;

               }

           }

        }
        else if(player_detected ==false)
        {
            patrol();
        }

    }
    private void patrol()
    {
        StartCoroutine(RandomNumber());
    }
    IEnumerator RandomNumber()
    {
       // Debug.Log("patrol has start");
        yield return new WaitForSeconds(10f);
        Debug.Log("On patrol");
        float selection = UnityEngine.Random.Range(1, 3); //1 is a left or right, 2 is up or down.
       float directionX= UnityEngine.Random.Range(-1, 2) ;
        float directionY = UnityEngine.Random.Range(-1, 2);

     if(selection == 1)
        {
            if(directionX !=0)
            {
                velocX = directionX;
                velocY = 0;
            }
            else
            {
                RandomNumber();
            }
        }
     else
        {
            if (directionY != 0)
            {
                velocY = directionY;
                velocX = 0;
            }
            else
            {
                RandomNumber();
            }
        }

    }
}
