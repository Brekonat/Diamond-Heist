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

    private void OnTriggerEnter2D(Collider2D col)
    {
        //print(directionFromPlayer + " Entered Collision");
        // ignore bumping into invisible connections
        if (!col.CompareTag("Connection"))
        {
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
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (!col.CompareTag("Connection"))
        {
            switch (directionFromPlayer)
            {
                case 'U':
                    player.canMoveUp = false;
                    if (col.CompareTag("Cable"))
                    {
                        player.cableUp = true;
                        player.cableUpObj = col.transform;
                    }
                    break;
                case 'D':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableDown = true;
                        player.cableDownObj = col.transform;
                    }
                    player.canMoveDown = false;
                    break;
                case 'L':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableLeft = true;
                        player.cableLeftObj = col.transform;
                    }
                    player.canMoveLeft = false;
                    break;
                case 'R':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableRight = true;
                        player.cableRightObj = col.transform;
                    }
                    player.canMoveRight = false;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //print(directionFromPlayer + " leaving collider");
        if (!col.CompareTag("Connection"))
        {
            switch (directionFromPlayer)
            {
                case 'U':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableUp = false;
                        player.cableUpObj = null;
                    }
                    player.canMoveUp = true;
                    break;
                case 'D':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableDown = false;
                        player.cableDownObj = null;
                    }
                    player.canMoveDown = true;
                    break;
                case 'L':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableLeft = false;
                        player.cableLeftObj = null;
                    }
                    player.canMoveLeft = true;
                    break;
                case 'R':
                    if (col.CompareTag("Cable"))
                    {
                        player.cableRight = false;
                        player.cableRightObj = null;
                    }
                    player.canMoveRight = true;
                    break;
            }
        }
    }
}


