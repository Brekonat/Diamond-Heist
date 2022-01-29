using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    [SerializeField] public GameObject thePlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(thePlayerObject.transform.position.x, thePlayerObject.transform.position.y, transform.position.z);
    }
}
