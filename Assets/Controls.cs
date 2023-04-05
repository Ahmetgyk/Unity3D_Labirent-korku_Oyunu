using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Light light;

    bool lightbool = false;
    public float camV;

    private void Start() {
        light.enabled = false;
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            lightbool = !lightbool;
            light.enabled = lightbool;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            cam.fieldOfView = camV;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            cam.fieldOfView = 60;
        }
    }
}
