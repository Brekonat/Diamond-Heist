using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpSpeed = 6;
    public bool swappedPlayerSmall = false;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            //print(grounded);
        }
        if (collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<PlayerBigMovement>().swappedPlayerBig = true;
            swappedPlayerSmall = false;
            print(swappedPlayerSmall);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
            //print(grounded);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && swappedPlayerSmall == false) //if you press tab and you aren't small
        {
            print(swappedPlayerSmall);
            swappedPlayerSmall = true; //you are now small
            rb.gravityScale = 1; // enable gravity
        }
        if (swappedPlayerSmall == true)
        { 
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
        if (swappedPlayerSmall == false)
        {
            var addpos = new Vector3(0, 1.4f, 0);
            this.transform.position = GameObject.Find("Player_big").transform.position + addpos;
            rb.gravityScale = 0; // Disable gravity
        }
    }
}
