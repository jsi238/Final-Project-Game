using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform ThisTransform;
    Vector3 GameobjectCurrentPosition;
    public float ShotAngle;
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
        if (Input.anyKeyDown)
        {
            Tripleshots();
        }

        /*
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Fiveshots();
            timer = 0;
        }
        */
    }

    void Tripleshots()
    {
        ThisTransform = this.transform;
        ShotAngle = ThisTransform.rotation.z;
        Instantiate(bullet, ThisTransform.position, new Quaternion(0, 0, ShotAngle, 1));
        Instantiate(bullet, ThisTransform.position, new Quaternion(0, 0, ShotAngle - 0.05f, 1));
        Instantiate(bullet, ThisTransform.position, new Quaternion(0, 0, ShotAngle + 0.05f, 1));
    }

    void Finalshots()
    {
        //Where bugs are: Bu
        ThisTransform = this.transform;
        for (int asd = 0; asd < 7; asd++)
        {
            ShotAngle = ThisTransform.rotation.z;
            Instantiate(bullet, ThisTransform.position, new Quaternion(0, 0, Random.Range(ShotAngle - 0.07f, ShotAngle + 0.07f), 1),this.transform);

            ShotAngle = ThisTransform.rotation.z + 0.1f;
            Instantiate(bullet, LeftWing.transform.position, new Quaternion(0, 0, Random.Range(ShotAngle - 0.07f, ShotAngle + 0.07f), 1),this.transform);

            ShotAngle = ThisTransform.rotation.z - 0.1f;
            Instantiate(bullet, RightWing.transform.position, new Quaternion(0, 0, Random.Range(ShotAngle - 0.07f, ShotAngle + 0.07f), 1),this.transform);
        }
    }

    void ShootABullet(Vector3 spawnpose,float direction)
    {
        
    }
}
