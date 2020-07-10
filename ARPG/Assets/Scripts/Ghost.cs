using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    float speedX = 0f;
    float speedY = 0f;

    bool chaseMode = false;
    bool patrol_lock = false;

    Rigidbody2D EnemyRB;

    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        chaseMode = Vector2.Distance(transform.position, player.transform.position) <= 10 ? true:false ;
   
        switch (chaseMode) 
        {
            case true:
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
                break;
            case false:
                patrolMode();
                EnemyRB.velocity = new Vector2(speedX, speedY);
                break;
        }
    }
    private void patrolMode()
    {
        if (patrol_lock==false) {
            patrol_lock = true;
            StartCoroutine(patrol());
        }
    }
    IEnumerator patrol()
    {
        yield return new WaitForSeconds(2f);
        
        float selection = UnityEngine.Random.Range(1, 3); //1 is a left or right, 2 is up or down.
        float directionX = UnityEngine.Random.Range(-1, 2);
        float directionY = UnityEngine.Random.Range(-1, 2);

        if (selection == 1)
        {
            if (directionX != 0)
            {
                speedX = directionX;
                speedY = 0;
            }
            else
            {
                patrol();
            }
        }
        else
        {
            if (directionY != 0)
            {
                speedY = directionY;
                speedX = 0;
            }
            else
            {
                patrol();
            }
        }
        patrol_lock = false;
    }
}
