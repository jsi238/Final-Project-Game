using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CameraManager Camerainstance;

    public Animator MainCamera;

    private void Start()
    {
        Camerainstance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Camshake();
        }
    }

    public void Camshake()
    {
        MainCamera.SetTrigger("shake");
    }
}
