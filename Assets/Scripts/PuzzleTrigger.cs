using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject link;    // object to be activated / deactivated upon completion of the puzzle
    [SerializeField]
    GameManager manager;
    [SerializeField]
    GameObject puzzle;
    [SerializeField]
    bool canEnter = false;
    [SerializeField]
    bool isTurret = false;
    [SerializeField]
    GameObject Turret;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player_small"))
        {
            canEnter = true;
        }
    }

    private void Update()
    {
        if (canEnter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("enter puzzle");
                if (isTurret)
                {
                    Turret.tag = "Enemies";
                }
                manager.EnterPuzzle(puzzle, link);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("player_small"))
        {
            canEnter = false;
        }
    }
}
