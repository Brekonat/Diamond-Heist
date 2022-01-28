using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Collisions : MonoBehaviour
{
    MiniGameMovement player;
   
    [SerializeField]
    char directionFromPlayer;    // which direction is this collider in relation to the player. U - up/above    D - down    L - left    R - right
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<MiniGameMovement>();
        //print("I exist");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(directionFromPlayer + " Entered Collision");
        switch (directionFromPlayer)
        {
            case 'U':
                player.canMoveUp = false;
                break;
            case 'D':
                player.canMoveDown = false;
                break;
            case 'L':
                player.canMoveLeft = false;
                break;
            case 'R':
                player.canMoveRight = false;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch (directionFromPlayer)
        {
            case 'U':
                player.canMoveUp = false;
                if (col.CompareTag("Cable"))
                {
                    //player.
                }
                break;
            case 'D':
                player.canMoveDown = false;
                break;
            case 'L':
                player.canMoveLeft = false;
                break;
            case 'R':
                player.canMoveRight = false;
                break;
        }
        //print(directionFromPlayer + " stating in collider");
        if (col.CompareTag("Cable"))
        {
            //player.cableInProximity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //print(directionFromPlayer + " leaving collider");
        switch (directionFromPlayer)
        {
            case 'U':
                player.canMoveUp = true;
                break;
            case 'D':
                player.canMoveDown = true;
                break;
            case 'L':
                player.canMoveLeft = true;
                break;
            case 'R':
                player.canMoveRight = true;
                break;
        }

        if (col.CompareTag("Cable"))
        {
            //player.cableInProximity = false;
            
        }
    }
}


