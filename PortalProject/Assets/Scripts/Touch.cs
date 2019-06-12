using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    //带有这个脚本的对象 应具有trigger盒，属于touch层
    public GameObject facedObj;

    public HeadTopMessage headTopMessage;
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            facedObj = other.transform.parent.gameObject;
            headTopMessage.SetImage(true, 0);
        }

        else if (other.CompareTag("Treasure"))
        {
            facedObj = other.gameObject;
            headTopMessage.SetImage(true, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Portal") || other.CompareTag("Treasure"))
        {
            facedObj = null;
            headTopMessage.SetImage(false);
        }
    }

    public GameObject getFacedObj()
    {
        return facedObj;
    }
}
