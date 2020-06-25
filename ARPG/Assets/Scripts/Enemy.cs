using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] GameObject player;
    float velocX = 0f;
     float velocY = 0f;

    float distanceX;
    float distanceY;
    bool lock_Movement = false;
    // Start is called before the first frame update

    Rigidbody2D EnemyRB;
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        InvokeRepeating("Calculus",0.001f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        Velocity();

      
        

    }
  
    private void Velocity()
    {
        EnemyRB.velocity = new Vector2(velocX, velocY);
    }
    private void Calculus()
    {
        distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
        distanceY = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (Mathf.Approximately(distanceY, distanceX))
        {
            if (distanceX < distanceY)
            {
                Debug.Log("Y is bigger");
            }
            else
            {
                Debug.Log("X is bigger");

            }
        }

        if (distanceX < distanceY )
        {

            if (player.transform.position.y > transform.position.y)//if Y is greater than X that means that the enemy is on the bottom for the player, other wise is on the top. 
            {
                // Debug.Log("The player is on the top");
                velocX = 0f;
                velocY = 1;


            }
            if (player.transform.position.y < transform.position.y)
            {
                //  Debug.Log("The player is on the button");
                velocX = 0f;
                velocY = -1f;


            }

        }
        // if(distanceX> distanceY && lock_Movement == false)
        else 
        {

            if (player.transform.position.x > transform.position.x)
            {
                //   Debug.Log("The player is on my right");
                velocX = 1f;
                velocY = 0f;

            }
            else if (player.transform.position.x < transform.position.x)
            {
                //Debug.Log("The player is on my left");
                velocX = -1f;
                velocY = 0f;

            }

        }
    }
}
