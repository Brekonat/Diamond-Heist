using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D laserrb;

    // Start is called before the first frame update
    void Start()
    {
        laserrb.velocity = new Vector2(-4, 0);
        Destroy(gameObject, 1f);
        Physics2D.IgnoreLayerCollision(7, 8);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("player_big"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("player_small"))
        {
            collision.gameObject.GetComponent<PlayerSmallMovement>().swappedPlayerSmall = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
