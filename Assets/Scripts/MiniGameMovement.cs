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
    bool cableInProximity = false;

    [SerializeField]
    public Transform cableUpObj;
    [SerializeField]
    public Transform cableDownObj;
    [SerializeField]
    public Transform cableLeftObj;
    [SerializeField]
    public Transform cableRightObj;

    Cable rightCable;
    Cable leftCable;
    Cable upCable;
    Cable downCable;

    MiniGameManager manager;
    public bool disablePlayer = false;

    public float playerFacing;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<MiniGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disablePlayer)
        {
            Move();

            if (cableUp)
            {
                upCable = cableUpObj.GetComponentInParent<Cable>();
                cableInProximity = true;
            }
            if (cableDown)
            {
                downCable = cableDownObj.GetComponentInParent<Cable>();
                cableInProximity = true;
            }
            if (cableLeft)
            {
                leftCable = cableLeftObj.GetComponentInParent<Cable>();
                cableInProximity = true;
            }
            if (cableRight)
            {
                rightCable = cableRightObj.GetComponentInParent<Cable>();
                cableInProximity = true;
            }

            if (cableInProximity)
            {
                RotateCable();
            }
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
                if (cableRight)
                {
                    
                    rightCable.MoveCable('R');
                }
            }
            // move right by one square
            else
            {
                transform.Translate(Vector3.right, Space.World);
            }
        }
        // player move Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            // check if obstacle is to the Left of player
            if (!canMoveLeft)
            {
                // don't move to the Left - perhaps try to move left but then go back
                if (cableLeft)
                {
                    
                    leftCable.MoveCable('L');
                }
            }
            // move Left by one square
            else
            {
                transform.Translate(Vector3.left, Space.World);
            }
        }
        // player move up
        if (Input.GetKeyDown(KeyCode.W))
        {
            // check if obstacle is above the player
            if (!canMoveUp)
            {
                // don't move UP - perhaps try to move UP but then go back
                if (cableUp)
                {
                    
                    upCable.MoveCable('U');
                }
            }
            // move UP by one square
            else
            {
                transform.Translate(Vector3.up, Space.World);
                
            }
        }
        // player move down
        if (Input.GetKeyDown(KeyCode.S))
        {
            // check if obstacle is below the player
            if (!canMoveDown)
            {
                // don't move  down - perhaps try to move down but then go back
                if (cableDown)
                {
                    
                    downCable.MoveCable('D');
                }
            }
            // move down by one square
            else
            {
                transform.Translate(Vector3.down, Space.World);
            }
        }
    }

    // rotates cables
    void RotateCable()
    {
        // rotate selected cables in one direction from a key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            //print(playerFacing);
            // what direction is the player facing?
            switch (playerFacing)
            {
                //right
                case 0: if (cableRightObj != null)
                    {
                        if(!rightCable.startEndConnection)
                            cableRightObj.eulerAngles = new Vector3(0, 0, cableRightObj.eulerAngles.z + 90f);
                        //print(cableRightObj.eulerAngles.z);
                    }
                    break;
                //left
                case 180: if (cableLeftObj != null)
                    {
                        if(!leftCable.startEndConnection)
                            cableLeftObj.eulerAngles = new Vector3(0, 0, cableLeftObj.eulerAngles.z + 90f);
                        //print(cableLeftObj.eulerAngles.z);
                    }
                    break;
                //up
                case 90: if (cableUpObj != null)
                    {
                        if(!upCable.startEndConnection)
                            cableUpObj.eulerAngles = new Vector3(0, 0, cableUpObj.eulerAngles.z + 90f);
                        //print(cableUpObj.eulerAngles.z);
                    }
                    break;
                //down
                case 270:
                    //print("Rotate!!!");
                    if (cableDownObj != null)
                    {
                        if(!downCable.startEndConnection)
                            cableDownObj.eulerAngles = new Vector3(0, 0, cableDownObj.eulerAngles.z + 90f);
                        //print(cableDownObj.eulerAngles.z);
                    }
                    //print("Rotate you downward cable");
                    break;
            }

            // re-check the connections
            manager.CheckConnections();
        }
    }
}
