using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    //[SerializeField] public GameObject thePlayerObject;
    [SerializeField] private GameObject playerBigObject;
    [SerializeField] private GameObject playerSmallObject; // give us the objects
    [SerializeField] private GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        //playerBigObject = GameObject.Find("Player_big");
        //playerSmallObject = GameObject.Find("Player_small");
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.activeInHierarchy)
        {
            if (FindObjectOfType<PlayerBigMovement>().swappedPlayerBig == true) //if you are controling big
            {
                transform.position = new Vector3(playerBigObject.transform.position.x, playerBigObject.transform.position.y, transform.position.z); //focus on them!
            }
            if (FindObjectOfType<PlayerSmallMovement>().swappedPlayerSmall == true) //if you are controling small
            {
                transform.position = new Vector3(playerSmallObject.transform.position.x, playerSmallObject.transform.position.y, transform.position.z); //focus on them!
            }
        }
        
    }
}
