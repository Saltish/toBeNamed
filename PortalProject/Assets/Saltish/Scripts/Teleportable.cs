using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    private Vector3 pos;
    private bool moveFlag = false;
    private bool canMove = true;
    private PType nowP;
    private int exitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (canMove && other.gameObject.tag == "Portal" && PortalController.teleportable)
        {
            PortalObject nowPortal = other.gameObject.GetComponent<PortalObject>();
            GameObject anotherPortal = PortalController.getAnotherPortal(nowPortal.getType());
            Vector3 newPos = anotherPortal.transform.position;
            pos = new Vector3(newPos.x, transform.position.y, newPos.z);
            moveFlag = true;
            canMove = false;
            //TODO 带角度
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Portal" && PortalController.teleportable)
        {
            exitCount++;
            Debug.Log(exitCount);
            if (exitCount == 2)
            {
                exitCount = 0;
                canMove = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (moveFlag)
        {
            Debug.Log(pos);
            transform.position = pos;
            moveFlag = false;
        }
    }
}
