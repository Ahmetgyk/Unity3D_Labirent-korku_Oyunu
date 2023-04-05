using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneyMove : MonoBehaviour
{
    [Range(50, 500)]
    public float sens;
    public Transform body;
    public Transform cam;
    float xRot = 0f;
    float YRot = 0f;

    CharacterController controller;
    Vector3 velocity;
    public float speed;
    
    private void Start() {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        #region Look
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        YRot = rotX;

        xRot = Mathf.Clamp(xRot, -80, 80);
        cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        body.Rotate(Vector3.up * YRot);
        #endregion
    
        #region Move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        #endregion
    }
}
