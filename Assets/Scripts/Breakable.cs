using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    GameObject wreckage;
    SpriteRenderer vision;
    Collider2D col;
    float lifeTime = 0.5f;
    bool wreck = false;

    private void Start()
    {
        vision = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void Wreck()
    {
        col.enabled = false;
        // spawn a bunch of the object in different directions and scale
        for(int i = 0; i < 5; i++)
        {
            wreckage = Instantiate(gameObject, new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Random.rotation, transform);
            wreckage.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        vision.enabled = false;
        wreck = true;
    }

    private void Update()
    {
        if (wreck)
        {
            if(lifeTime > 0f)
            {
                lifeTime -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    wreckage[i].transform.Translate(new Vector2(transform.position.x + 3, transform.position.y + 3), Space.Self);
            //}
        }

    }
}
