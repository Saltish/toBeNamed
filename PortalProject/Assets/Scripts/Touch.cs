using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject player;
    private GameObject facedPortal;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + player.transform.forward * 0.8f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            facedPortal = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            facedPortal = null;
        }
    }

    public GameObject getFacedPortal()
    {
        return facedPortal;
    }
}
