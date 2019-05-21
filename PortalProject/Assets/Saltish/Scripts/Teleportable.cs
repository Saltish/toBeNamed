using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    private Vector3 pos;
    private bool moveFlag = false;
    private int nowId = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (nowId == -1 && other.gameObject.tag == "Portal")
        {
            Debug.Log(1);
            PortalObject nowPortal = other.gameObject.GetComponent<PortalObject>();
            nowId = nowPortal.getId();
            PortalObject anotherPortal = PortalController.getAnotherPortal(nowId);
            Vector3 newPos = anotherPortal.transform.position;
            pos = new Vector3(newPos.x, transform.position.y, newPos.z);
            moveFlag = true;
            //TODO 带角度
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Portal" && other.gameObject.GetComponent<PortalObject>().getId() != nowId)
        {
            nowId = -1;
        }
    }

    private void LateUpdate()
    {
        if (moveFlag)
        {
            transform.position = pos;
            moveFlag = false;
        }
    }
}
