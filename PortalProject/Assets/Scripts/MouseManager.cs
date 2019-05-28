using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;

    // Swap cursors per object

    // public Texture2D pointer; // Normal pointer
    // public Texture2D target; // Cursor for placable objects


    private bool placing = false;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;



        /* 老版本代码
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            Vector3 mousePos = hit.point;
            if (placing)
            {
                PortalController.RotatePlacingPortal(mousePos);
                if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
                {
                    PortalController.EndPlacingPortal();
                    placing = false;
                }
            }
            else if (hit.collider.gameObject.tag == "Placeable")
            {
                //Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                if (Input.GetMouseButtonDown(0) && !placing)
                {
                    PortalController.startPlacePortal(PType.Portal1, mousePos);
                    placing = true;
                }
                else if (Input.GetMouseButtonDown(1) && !placing)
                {
                    PortalController.startPlacePortal(PType.Portal2, mousePos);
                    placing = true;
                }
            }
            else
            {
                //Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
            }
        }*/
    }
    
}

