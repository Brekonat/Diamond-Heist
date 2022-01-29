using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBigMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    [SerializeField] private BoxCollider2D hitBox;
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpSpeed = 4;
    private bool grounded;
    [SerializeField] private Vector3 hitboxDirectionOffset = new Vector3(2, 0, 0);
    public bool swappedPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitboxDirectionOffset = new Vector3(2, 0, 0);
        hitBox = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            //print(grounded);
        }
            
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies" && Input.GetKeyDown(KeyCode.K))
        {
            Destroy(other.gameObject);
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

        if (Input.GetKey(KeyCode.Tab) && swappedPlayer == false)
        {
            print(swappedPlayer);
            swappedPlayer = true;

        }
        if (swappedPlayer == false)
            {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                hitboxDirectionOffset = new Vector3(2, 0, 0);
                hitBox.offset = new Vector3(1.00228f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                hitboxDirectionOffset = new Vector3(-2, 0, 0);
                hitBox.offset = new Vector3(-1.00228f, 0, 0);
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
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + hitboxDirectionOffset, new Vector2(4,2));
    }
}
