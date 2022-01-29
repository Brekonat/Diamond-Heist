using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void PlayerFound()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
    }
    void FixedUpdate()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f);
        if (hit.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position, Vector2.left, Color.red, 20f);
            print("Found them!");
        }
    }
}
