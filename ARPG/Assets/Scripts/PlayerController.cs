using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMove;
    private float yMove;
    public float MoveSpeed;
    public bool canMove;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            xMove = Input.GetAxisRaw("Horizontal");
            yMove = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(xMove * MoveSpeed, yMove * MoveSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

