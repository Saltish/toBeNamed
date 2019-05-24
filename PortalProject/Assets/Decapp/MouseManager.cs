using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    //记得要将Mouse Position Detector的高度调为0
    
    private static Vector3 mousePositionWorld;

    public Camera mainCamera;

    private Ray _ray;
    private RaycastHit _hitInfo;
    
    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
        _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hitInfo, 100f);
        if(_hitInfo.collider.CompareTag("Mouse Detector"))
            mousePositionWorld=_hitInfo.point;
    }
}
