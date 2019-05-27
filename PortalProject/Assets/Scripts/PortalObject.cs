using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    private PortalObject partner = null;


    public PortalObject getPartner()
    {
        return partner;
    }

    public void setPartner(PortalObject p)
    {
        partner = p;
    }
}
