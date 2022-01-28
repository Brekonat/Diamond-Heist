using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    // no gravity, player cannot fall
    // check square that player wants to move to before moving

    Vector2 overlapBoxSize = new Vector2(0.9f, 0.9f);

    public bool canMoveUp = true;
    public bool canMoveDown = true;
    public bool canMoveRight = true;
    public bool canMoveLeft = true;
    public bool cableInProximity = false;

    char charDirection; // what direction the character is facing

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (cableInProximity)
        {
            RotateCable();

        }
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
            }
            // move right by one square
            else
            {
                transform.Translate(Vector3.right);
                RotatePlayer('R');
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
                transform.Translate(Vector3.left);
                RotatePlayer('L');
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
                transform.Translate(Vector3.up);
                RotatePlayer('U');
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
                transform.Translate(Vector3.down);
                RotatePlayer('D');

            }
        }
    }

    void RotatePlayer(char newRotation)
    {
        // if the desired rotation has changed, rotate the player by the specific amount
        if (!charDirection.Equals(newRotation))
        {
            switch (newRotation)
            {
                case 'U': switch (charDirection)
                    {
                        case 'D': transform.Rotate(new Vector3(0, 0, 180));
                            break;
                        case 'L': transform.Rotate(new Vector3(0, 0, 90));
                            break;
                        case 'R': transform.Rotate(new Vector3(0, 0, -90));
                            break;
                    }
                    break;
                case 'D':
                    switch (charDirection)
                    {
                        case 'U':
                            transform.Rotate(new Vector3(0, 0, 180));
                            break;
                        case 'L':
                            transform.Rotate(new Vector3(0, 0, -90));
                            break;
                        case 'R':
                            transform.Rotate(new Vector3(0, 0, 90));
                            break;
                    }
                    break;
                case 'R':
                    switch (charDirection)
                    {
                        case 'D':
                            transform.Rotate(new Vector3(0, 0, -90));
                            break;
                        case 'L':
                            transform.Rotate(new Vector3(0, 0, 180));
                            break;
                        case 'U':
                            transform.Rotate(new Vector3(0, 0, 90));
                            break;
                    }
                    break;
                case 'L':
                    switch (charDirection)
                    {
                        case 'D':
                            transform.Rotate(new Vector3(0, 0, 90));
                            break;
                        case 'U':
                            transform.Rotate(new Vector3(0, 0, -90));
                            break;
                        case 'R':
                            transform.Rotate(new Vector3(0, 0, 180));
                            break;
                    }
                    break;
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
