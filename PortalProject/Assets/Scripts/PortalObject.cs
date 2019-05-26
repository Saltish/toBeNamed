using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    public PType type;
    

    public PType getType()
    {
        return type;
    }
}

public enum PType
{
    Portal1, Portal2
};
