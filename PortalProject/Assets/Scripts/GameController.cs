using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject treasure;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            treasure.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5.0f);
        }
    }
}
