using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private static PortalObject nowPortal;
    private static PortalObject lastPortal;

    private static float angle;
    private static bool teleportable = false;

    // Start is called before the first frame update
    void Start()
    {
        nowPortal = GameObject.Find("Portal1").GetComponent<PortalObject>();
        lastPortal = GameObject.Find("Portal2").GetComponent<PortalObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static PortalObject getAnotherPortal(int id)
    {
        if (nowPortal.getId() == id) return lastPortal;
        else return nowPortal;
    }

    public static void placeNextPortal(Vector3 pos, Quaternion rot)
    {
        PortalObject tmpObj;
        if (!lastPortal.gameObject.activeSelf)
        {
            lastPortal.gameObject.SetActive(true);
            tmpObj = lastPortal;
        } else if (!nowPortal.gameObject.activeSelf)
        {
            nowPortal.gameObject.SetActive(true);
            tmpObj = nowPortal;
            teleportable = true;
        } else
        {
            tmpObj = lastPortal;
            lastPortal = nowPortal;
            nowPortal = tmpObj;
        }

        tmpObj.gameObject.transform.position = pos;
        tmpObj.gameObject.transform.rotation = rot;
    }
}
