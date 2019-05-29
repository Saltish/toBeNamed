using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("---控制移动的速度---")]
    public float speedMove;

    [Header("---移动按键---")]
    public string forward = "w";
    public string back = "s";
    public string left = "a";
    public string right = "d";

    [Header("---功能按键---")]
    public string shiftLeft = "q";
    public string shiftRight = "e";
    public string push = "space";

    public Touch touch;

    private Camera mainCamera;  // 主摄像机
    private Vector3 offset;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        offset = mainCamera.transform.position - this.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //checkMove();
        Move();
        checkInteraction();
    }

    void LateUpdate()
    {
        //mainCamera.transform.position = this.transform.position + offset;
    }

    private void Move()
    {
        Vector3 toMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 5.0f;
        rb.velocity = toMove;
        if(toMove!=Vector3.zero)
            transform.LookAt(toMove + transform.position);
    }

//    private void checkMove()
//    {
//        rb.velocity = Vector3.zero;
//        float deltaX = 0;
//        float deltaZ = 0;
//        // 移动
//        if (Input.GetKey(forward))
//        {
//            deltaZ += speedMove;
//        } 
//        if (Input.GetKey(back))
//        {
//            deltaZ -= speedMove;
//        }
//        if (Input.GetKey(left))
//        {
//            deltaX -= speedMove;
//        }
//        if (Input.GetKey(right))
//        {
//            deltaX += speedMove;
//        }
//        Vector3 toMove = new Vector3(deltaX, 0, deltaZ);
//        transform.LookAt(toMove + transform.position);
//        rb.velocity = toMove;
//    }

    private void checkInteraction()
    {

        if (Input.GetKeyDown(shiftLeft))
        {
            GameObject portal = touch.getFacedObj();
            if (portal && portal.CompareTag("Portal"))
            {
                
                portal.transform.Rotate(Vector3.up * 45);
            }
        }
        else if(Input.GetKeyDown(shiftRight))
        {
            GameObject portal = touch.getFacedObj();
            if (portal && portal.CompareTag("Portal"))
            {
                portal.transform.Rotate(-Vector3.up * 45);
            }
        }
        else if (Input.GetKeyDown(push))
        {
            GameObject treasure = touch.getFacedObj();
            if (treasure && treasure.CompareTag("Treasure"))
            {
                treasure.GetComponent<Rigidbody>().velocity = treasure.transform.forward * speedMove;
            } 
        }

    }
}
