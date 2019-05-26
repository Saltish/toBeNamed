using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("---控制移动的速度---")]
    public float speedMove = 5.0f;

    [Header("---移动按键---")]
    public string forward = "w";
    public string back = "s";
    public string left = "a";
    public string right = "d";


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
        checkMove();
        
        //TODO:Look at?
    }

    void LateUpdate()
    {
        //mainCamera.transform.position = this.transform.position + offset;
    }

    private void checkMove()
    {
        rb.velocity = Vector3.zero;
        float deltaX = 0;
        float deltaZ = 0;
        // 移动
        if (Input.GetKey(forward))
        {
            deltaZ = speedMove;
        } 
        if (Input.GetKey(back))
        {
            deltaZ = -speedMove;
        }
        if (Input.GetKey(left))
        {
            deltaX = -speedMove;
        }
        if (Input.GetKey(right))
        {
            deltaX = speedMove;
        }

        Vector3 toMove = new Vector3(deltaX, 0, deltaZ);
        rb.velocity = Vector3.ClampMagnitude(toMove, speedMove);

        
    }
}
