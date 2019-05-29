using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject player;
    public GameObject facedObj;

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal") || other.CompareTag("Treasure"))
        {
            facedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal" || other.CompareTag("Treasure"))
        {
            facedObj = null;
        }
    }

    public GameObject getFacedObj()
    {
        return facedObj;
    }
}
