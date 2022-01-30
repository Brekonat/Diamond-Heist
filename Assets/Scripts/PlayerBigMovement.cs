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
    [SerializeField] private GameObject smallObject;
    private bool grounded;
    [SerializeField] private Vector3 hitboxDirectionOffset = new Vector3(2, 0, 0);
    public bool swappedPlayerBig = true;
    Animator animator;
    private SpriteRenderer sp;
    public enum Sounds { BigFootStep }
    public AudioClip[] footStepAudio;
    public AudioSource BigAudioSource;
    public AudioClip Punchclip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitboxDirectionOffset = new Vector3(2, 0, 0);
        hitBox = GetComponent<BoxCollider2D>();
        swappedPlayerBig = true;
        animator = GetComponentInChildren<Animator>();
        sp = GetComponent<SpriteRenderer>();
        BigAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            //print(grounded);
        }
        if (collision.collider.CompareTag("player_small"))
        {
            swappedPlayerBig = false;
            print(swappedPlayerBig);
        }

    }
    void FootSounds()
    {
        AudioSource.PlayClipAtPoint(footStepAudio[Random.Range(0, footStepAudio.Length)], new Vector2(rb.position.x, rb.position.y));
        // select a random one from the array
    }
    void Stoppunching()
    {
        animator.SetBool("Punching", false);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemies") && Input.GetKeyDown(KeyCode.Space) && !other.CompareTag("Barrier"))
        {
            animator.SetBool("Punching", true);
            AudioSource.PlayClipAtPoint(Punchclip, new Vector2(rb.position.x, rb.position.y));
            Destroy(other.gameObject);
        }
        // destroys other breakable object
        else if (other.CompareTag("Breakable") && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Punching", true);
            AudioSource.PlayClipAtPoint(Punchclip, new Vector2(rb.position.x, rb.position.y));
            other.GetComponent<Breakable>().Wreck();
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
        //print(rb.velocity);
        if (rb.velocity.x > 0)
        {
            animator.SetBool("Iswalking", true);
            sp.flipX = false;
        }
        else if (rb.velocity.x < -1)
        {
            animator.SetBool("Iswalking", true);
            sp.flipX = true;
        }
        else
        {
            animator.SetBool("Iswalking", false);
            sp.flipX = false;
        }

        if (Input.GetKey(KeyCode.Tab) && swappedPlayerBig == true)//if you press tab and you are big
        {
            print(swappedPlayerBig);
            swappedPlayerBig = false; //no longer big
        }
            if (Input.GetKey(KeyCode.D))
            {
                if (swappedPlayerBig == true)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    hitboxDirectionOffset = new Vector3(1, 0, 0);
                    hitBox.offset = new Vector3(0.5238624f, 0, 0);

                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (swappedPlayerBig == true)
                {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                hitboxDirectionOffset = new Vector3(-1, 0, 0);
                hitBox.offset = new Vector3(-0.5238624f, 0, 0);
                }
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            //if (Input.GetKey(KeyCode.W) && grounded)
            //{
            //    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //}

    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position + hitboxDirectionOffset, new Vector2(4,2));
    }
}
