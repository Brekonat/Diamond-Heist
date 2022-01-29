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

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player_small"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("enter puzzle");
                manager.EnterPuzzle(puzzle, link);
            }
        }
    }

}
