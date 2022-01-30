using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject mainGame;
    GameObject linkedObject;    // object triggered from puzzle
    [SerializeField]
    GameObject UI;
    [SerializeField]
    GameObject OptionsUI;
    [SerializeField]
    GameObject mainButtonsUI;
    [SerializeField]
    GameObject interactUINotification;

    bool stress = false;

    // Start is called before the first frame update
    void Start()
    {
        //mainGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.SetActive(true);
            mainGame.SetActive(false);
        }
    }

    public void EnterPuzzle(GameObject puzzle, GameObject link)
    {
        puzzle.SetActive(true);
        if (stress)
            puzzle.GetComponentInChildren<MiniGameManager>().timer = true;
        else
            puzzle.GetComponentInChildren<MiniGameManager>().timer = false;
        mainGame.SetActive(false);
        linkedObject = link;
    }

    // upon leaving the puzzle, the object linked to the puzzle will be triggered
    public void LeavePuzzle(GameObject puzzle)
    {
        puzzle.SetActive(false);
        mainGame.SetActive(true);
        RemoveDoor();

    }


    void RemoveDoor()
    {
        Destroy(linkedObject);
    }

    public void Options()
    {
        mainButtonsUI.SetActive(false);
        OptionsUI.SetActive(true);
    }

    public void ExitOptions()
    {
        OptionsUI.SetActive(false);
        mainButtonsUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        UI.SetActive(false);
        mainGame.SetActive(true);
    }

    public void Stress()
    {
        if (stress)
        {
            stress = false;
        }
        else
        {
            stress = true;
        }
    }

    public void UINotification(bool active)
    {
        interactUINotification.SetActive(active);
    }
}
