using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cr;
    private BoxCollider2D boxc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cr = GetComponent<CircleCollider2D>();
        boxc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player_big"))
        {
            print("shoot");
        }
    }
    //hit.collider.tag == "player_big" || hit.collider.tag == "player_small")
    // Update is called once per frame
    void Update()
    {
        
    }
}
