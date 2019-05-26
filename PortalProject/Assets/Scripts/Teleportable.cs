using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
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
            transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
            canMove = false;
            
            //TODO 带角度
            //this part by Decapp might be bad coding, feel free to make changes
            Quaternion q = Quaternion.AngleAxis(
                anotherPortal.transform.eulerAngles.y + nowPortal.transform.eulerAngles.y,
                Vector3.up); //Quaternion of Rotation
            
            GetComponent<Rigidbody>().velocity = q * GetComponent<Rigidbody>().velocity;
            //
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
}
