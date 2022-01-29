using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnectionCollider : MonoBehaviour
{
    Cable cable;
    bool startCable;

    private void Start()
    {
        cable = transform.parent.parent.GetComponent<Cable>();
        if (cable.name.Equals("Start Cable"))
        {
            startCable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //print(col.name + " " + transform.parent.parent.name);
        if (col.CompareTag("Cable"))
        {
            //print("adding cable: " + col.transform.parent.name + " to " + transform.parent.parent.name);
            cable.connections.Add(col.GetComponentInParent<Cable>());
            if (startCable)
                cable.manager.CheckConnections();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Cable"))
        {
            cable.connections.Remove(col.GetComponentInParent<Cable>());
            if (startCable)
                cable.manager.CheckConnections();
        }
    }
}
