using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    //private Rigidbody2D rb;
    private CircleCollider2D cr;
    private BoxCollider2D boxc;
    [SerializeField] private Rigidbody2D laserrb;
    private float cooldowntimer = 4f;
    private float firerate = 65f;
    private bool canfire;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        cr = GetComponent<CircleCollider2D>();
        boxc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("player_big") && Time.time > cooldowntimer)
        {
            Instantiate(laserrb, transform.position + new Vector3(-2f, 1, 0), Quaternion.identity);
            cooldowntimer = Time.time + firerate;
        }
    }

    void Spawnlaser()
    {

    }
    //hit.collider.tag == "player_big" || hit.collider.tag == "player_small")
    // Update is called once per frame
    void Update()
    {
        cooldowntimer = cooldowntimer - 1;
        if(cooldowntimer == -1)
        {
            cooldowntimer = 2f;
            canfire = true;
        }
    }
}
