using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform ThisTransform;
    public Transform L1;
    public Transform L2;
    public Transform R1;
    public Transform R2;

    Vector3 GameobjectCurrentPosition;
    public GameObject LeftWing;
    public GameObject RightWing;


    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Singleshots()
    {
        ThisTransform = this.transform;
        Instantiate(bullet, ThisTransform.position, ThisTransform.rotation, this.transform);
    }

    void Finalshots()
    {
        //Where bugs are: Bu
        ThisTransform = this.transform;

        CameraManager.Camerainstance.Camshake();
            
            Instantiate(bullet, ThisTransform.position, ThisTransform.rotation,this.transform);
        
            Instantiate(bullet, L1.position, L1.rotation, L1);

            Instantiate(bullet, L2.position, L2.rotation, L2);

            Instantiate(bullet, R1.position, R1.rotation, R1);

            Instantiate(bullet, R2.position, R2.rotation, R2);

    }

    void ShootABullet(Vector3 spawnpose,float direction)
    {
        
    }
}
