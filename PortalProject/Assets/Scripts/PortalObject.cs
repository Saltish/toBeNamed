using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    public PortalObject partner ;


    public PortalObject getPartner()
    {
        Debug.Log("getparter");
        return partner;
    }

    public void setPartner(PortalObject p)
    {
        partner = p;
    }
}
