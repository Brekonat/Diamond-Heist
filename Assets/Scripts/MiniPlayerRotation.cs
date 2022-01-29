using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayerRotation : MonoBehaviour
{
    MiniGameMovement mover;

    private void Start()
    {
        mover = transform.parent.GetComponent<MiniGameMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        mover.playerFacing = transform.eulerAngles.z;
    }
}
