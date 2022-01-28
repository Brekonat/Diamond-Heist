using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    // no gravity, player cannot fall
    // check square that player wants to move to before moving

    public bool canMoveUp = true;
    public bool canMoveDown = true;
    public bool canMoveRight = true;
    public bool canMoveLeft = true;

    public bool cableUp = false;
    public bool cableDown = false;
    public bool cableLeft = false;
    public bool cableRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // player move right
        if(Input.GetKeyDown(KeyCode.D))
        {
            // check if obstacle is to the right of player
            if(!canMoveRight)
            {
                // don't move to the right - perhaps try to move right but then go back
                if (cableRight)
                {
                    
                }
            }
            // move right by one square
            else
            {
                transform.Translate(Vector3.right, Space.World);
                //RotatePlayer('R');
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        // player move Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            // check if obstacle is to the Left of player
            if (!canMoveLeft)
            {
                // don't move to the Left - perhaps try to move left but then go back
            }
            // move Left by one square
            else
            {
                transform.Translate(Vector3.left, Space.World);
                //RotatePlayer('L');
                transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }
        // player move up
        if (Input.GetKeyDown(KeyCode.W))
        {
            // check if obstacle is above the player
            if (!canMoveUp)
            {
                // don't move UP - perhaps try to move UP but then go back
            }
            // move UP by one square
            else
            {
                transform.Translate(Vector3.up, Space.World);
                transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
        // player move down
        if (Input.GetKeyDown(KeyCode.S))
        {
            // check if obstacle is below the player
            if (!canMoveDown)
            {
                // don't move  down - perhaps try to move down but then go back
            }
            // move down by one square
            else
            {
                transform.Translate(Vector3.down, Space.World);
                //RotatePlayer('D');
                transform.localEulerAngles = new Vector3(0, 0, -90);
            }
        }
    }

    // rotates cables
    void RotateCable()
    {
        // rotate selected cables in one direction
        
    }

    // player can push and pull cable.
    void GrabCable()
    {

    }
}
