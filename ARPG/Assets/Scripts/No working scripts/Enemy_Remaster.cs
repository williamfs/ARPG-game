using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Remaster : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] float SpeedX = 0f;
    [SerializeField] LayerMask player_Layer;
    float speedY = 0;

    bool chaseMode = false;
    Rigidbody2D EnemeyRB;
    void Start()
    {
        EnemeyRB = GetComponent<Rigidbody2D>();
      //  InvokeRepeating("patrol", 0.001f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        chaseMode = Vector2.Distance(transform.position, player.transform.position) >= 10 ? true : false;

        DistanceDetect();
        Velocity();
        Debug.Log(chaseMode);
    }
    private void DistanceDetect()
    {
        
        RaycastHit2D cast = Physics2D.Raycast(transform.position, new Vector2(SpeedX, speedY), 10f, player_Layer);
        if(cast )
        {
            chaseMode = true;
        }
        else if(cast == false)
        {
            chaseMode = false;
        }
        
    }
    private void Velocity()
    {/*
        if (chaseMode)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, SpeedX * Time.deltaTime);
        }
         if(chaseMode == false)
        {
            EnemeyRB.velocity = new Vector2(SpeedX, speedY);
        }
        */
        switch (chaseMode)
        {

            case true:
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, SpeedX * Time.deltaTime*2f);
                break;
            case false:
                EnemeyRB.velocity = new Vector2(SpeedX, speedY);
                break;
        }

    }
    private void patrol()
    {
        if (chaseMode==false) {
            StartCoroutine(RandomNumber());
        }
    }
    IEnumerator RandomNumber()
    {
        // Debug.Log("patrol has start");
        yield return new WaitForSeconds(2f);
        Debug.Log("On patrol");
        float selection = UnityEngine.Random.Range(1, 3); //1 is a left or right, 2 is up or down.
        float directionX = UnityEngine.Random.Range(-1, 2);
        float directionY = UnityEngine.Random.Range(-1, 2);

        if (selection == 1)
        {
            if (directionX != 0)
            {
                SpeedX = directionX;
                speedY = 0;
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
                speedY = directionY;
                SpeedX = 0;
            }
            else
            {
                RandomNumber();
            }
        }

    }
    private void OnDrawGizmos()
    {

        Vector2 direction2 = new Vector2(SpeedX, speedY) * 10;
        // Vector2 direction2 = new Vector2.Distance(transform.position, player.transform.position);
        Debug.DrawRay(transform.position, direction2, Color.red);

    }
}
