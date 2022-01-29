using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private float dir = -1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Flipper"))
        {
            dir = dir * -1;
        }
    }
    void PlayerFound()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(-2*dir,0);
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.DrawRay(transform.position, Vector2.left * dir, Color.red, 4f);
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left*dir, 20f);
        if (hit.collider.tag == "player_big" || hit.collider.tag == "player_small")
        {
            print("Found them!");
        }
    }
}
