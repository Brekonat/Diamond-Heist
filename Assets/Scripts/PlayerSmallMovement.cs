using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmallMovement : MonoBehaviour
{
    public Rigidbody2D rbsmall;
    private CapsuleCollider2D col;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpSpeed = 6;
    public bool swappedPlayerSmall = false;
    private bool grounded;
    Animator animator;
    private SpriteRenderer sp;
    public enum Sounds { FootStep }
    public AudioClip[] footStepAudio;
    public AudioSource SmallAudioSource;
    public AudioClip jumpclip;
    // Start is called before the first frame update
    void Start()
    {
        rbsmall = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sp = GetComponent<SpriteRenderer>();
        SmallAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            //print(grounded);
            animator.SetBool("Jumping", false);
        }
        if (collision.collider.CompareTag("player_big"))
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
            rbsmall.gravityScale = 1; // enable gravity
        }
        if (swappedPlayerSmall == true)
        { 
            if (Input.GetKey(KeyCode.D))
            {
                rbsmall.velocity = new Vector2(speed, rbsmall.velocity.y);
                animator.SetBool("Iswalking", true);
                sp.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rbsmall.velocity = new Vector2(-speed, rbsmall.velocity.y);
                animator.SetBool("Iswalking", true);
                sp.flipX = true;
            }
            else
            {
                rbsmall.velocity = new Vector2(0, rbsmall.velocity.y);
                animator.SetBool("Iswalking", false);
                sp.flipX = false;
            }
            if (Input.GetKey(KeyCode.W) && grounded)
            {
                rbsmall.velocity = new Vector2(rbsmall.velocity.x, jumpSpeed);
                animator.SetBool("Jumping", true);
                AudioSource.PlayClipAtPoint(jumpclip, new Vector2(rbsmall.position.x, rbsmall.position.y));
            }
        }
        if (swappedPlayerSmall == false)
        {
            var addpos = new Vector3(0, 1.4f, 0);
            this.transform.position = GameObject.Find("Player_big").transform.position + addpos;
            rbsmall.gravityScale = 0; // Disable gravity
            animator.SetBool("Jumping", false);
            animator.SetBool("Iswalking", false);
            animator.SetBool("Issmall", false);
        }
    }
}
