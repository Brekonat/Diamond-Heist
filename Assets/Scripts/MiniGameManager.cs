using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    Cable startCable;
    [SerializeField]
    Cable endCable;
    [SerializeField]
    MiniGameMovement player;

    [SerializeField]    // only to see the value in the inspector
    bool puzzleComplete = false;
    bool timer = true;
    [SerializeField]
    float timeLeft = 60f;
    [SerializeField]
    float timeToCompletePuzzle = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RemoveTimer()
    {
        timer = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckConnections();
        if (puzzleComplete)
        {
            //go out of puzzle and trigger something
            player.disablePlayer = true;

        }
        if (timer && !puzzleComplete)
        {
            Countdown();
        }
        if (Input.GetKeyDown(KeyCode.R))
            ResetPuzzle();
    }

    public void CheckConnections()
    {
        //print("Checking connections");
        // is there even anything touching the starting cable?
        if(startCable.connections.Count > 0)
        {
            //print("start checking");
            Cable secondCable = startCable.connections[0];
            bool startCableConnected = false;
            //print(startCable.connections[0].name);
            //print(secondCable.connections.Count);
            // is the cable touching the starting cable connected to it?    /correct rotations
            for(int i =0; i< secondCable.connections.Count; i++)
            {
                //print(secondCable.connections[i]);
                if (secondCable.connections[i] == startCable)
                {
                    startCableConnected = true;
                }
            }
            //print(startCableConnected);

            if (startCableConnected)
            {
                //print("start Cable connected");
                Cable previousCable = startCable;
                Cable currentCable = secondCable;
                Cable nextCable;
                bool moreConnections = true;

                while (moreConnections)
                {
                    if(currentCable.connections.Count == 2)
                    {
                        for(int i = 0; i < currentCable.connections.Count; i++)
                        {
                            if(currentCable.connections[i] != previousCable)
                            {
                                //print(currentCable + " is touching another cable " + currentCable.connections[i]);
                                bool switchedConnection = false;
                                // check if the next cable is connected to this one
                                nextCable = currentCable.connections[i];
                                for(int j = 0; j < nextCable.connections.Count; j++)
                                {
                                    // if it is connected to this one, go to the next cable and repeat the process
                                    if(nextCable.connections[j] == currentCable)
                                    {
                                        //print("Switching");
                                        previousCable = currentCable;
                                        currentCable = nextCable;
                                        switchedConnection = true;
                                    }
                                }
                                //print(switchedConnection);
                                //the connection wasn't switched and ran out of cable
                                if (!switchedConnection)
                                {
                                    moreConnections = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        moreConnections = false;
                    }
                }

                if(currentCable == endCable)
                {
                    // the puzzle is complete, do something
                    puzzleComplete = true;
                }
            }
        }
    }


    void Countdown()
    {
        if(timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            print("Time Left: " + timeLeft);
        }
        else
        {
            // fail or restart
            ResetPuzzle();
        }
    }

    void ResetPuzzle()
    {
        // resetting values
        timeLeft = timeToCompletePuzzle;
        player.transform.localPosition = new Vector3(0f, 0f, 0f);
        GameObject[] cables = GameObject.FindGameObjectsWithTag("Cable");
        for (int i = 0; i < cables.Length; i++)
        {
            cables[i].transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
