using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    private int id;

    private static int idCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        id = idCount;
        idCount++;
    }
    

    public int getId()
    {
        return id;
    }
}
