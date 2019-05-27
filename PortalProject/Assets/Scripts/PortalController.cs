using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject[] portalPool;
    private bool newPairFlag = true;

    private void Start()
    {
        for (int i = 0; i < portalPool.Length; i+=2)
        {
            PortalObject p1 = portalPool[i].GetComponent<PortalObject>();
            PortalObject p2 = portalPool[i + 1].GetComponent<PortalObject>();
            p1.setPartner(p2);
            p2.setPartner(p1);
        }
    }

    /* 老版本代码
    private static GameObject placing = null;
    public GameObject _portal1;
    public GameObject _portal2;
    private static GameObject portal1;
    private static GameObject portal2;

    private static float angle;
    public static bool teleportable = false;

    private void Start()
    {
        portal1 = _portal1;
        portal2 = _portal2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject getAnotherPortal(PType p)
    {
        if (p == PType.Portal1) return portal2;
        else return portal1;
    }

    public static void placeNextPortal(Vector3 pos, Quaternion rot)
    {
        GameObject tmpObj;
        if (!portal1.activeSelf)
        {
            portal1.SetActive(true);
            tmpObj = portal1;
        } else if (!portal2.activeSelf)
        {
            portal2.SetActive(true);
            tmpObj = portal2;
            teleportable = true;
        } else
        {
            tmpObj = portal2;
            portal2 = portal1;
            portal1 = tmpObj;
        }

        tmpObj.transform.position = pos;
        tmpObj.transform.rotation = rot;
    }

    public static void startPlacePortal(PType p, Vector3 pos)
    {
        if (p == PType.Portal1)
        {
            placing = portal1;
        } else
        {
            placing = portal2;
        }
        if (!placing.gameObject.activeSelf)
        {
            placing.gameObject.SetActive(true);
            if (portal1.activeSelf && portal2.activeSelf)
            {
                teleportable = true;
            }
        }
        Transform transform = placing.gameObject.transform;
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }

    public static void rotatePlacingPortal(Vector3 mousePos)
    {
        if (placing == null) return;
        Transform transform = placing.gameObject.transform;
        transform.LookAt(new Vector3(mousePos.x, transform.position.y, mousePos.z));
    }

    public static void endPlacingPortal()
    {
        placing = null;
    }
    */
    
}
