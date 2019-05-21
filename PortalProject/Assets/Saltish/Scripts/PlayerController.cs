using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("---控制移动的速度---")]
    public float speedMove = 5.0f;

    private CharacterController characterController;

    private Camera mainCamera;  //主摄像机
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        offset = mainCamera.transform.position - this.transform.position;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) { speedMove += 10.0f; }
        float deltaX = Input.GetAxis("Horizontal") * speedMove;
        float deltaZ = Input.GetAxis("Vertical") * speedMove;
        Vector3 toMove = new Vector3(deltaX, 0, deltaZ);
        toMove = Vector3.ClampMagnitude(toMove, speedMove);

        //碰撞检测
        toMove = transform.TransformDirection(toMove);
        characterController.Move(toMove * Time.deltaTime);
    }

    void LateUpdate()
    {
        mainCamera.transform.position = this.transform.position + offset;
    }
}
