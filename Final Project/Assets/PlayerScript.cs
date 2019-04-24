using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Vector2 playerPosition;

    Quaternion playerRotation;

    public float playerSpeed;

    public float boostCharge;
    public float finalBoost;
    public float maxCharge = .5f;
    public float boostTime;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position;
        playerRotation = transform.parent.rotation;

        transform.position = playerPosition;
        transform.rotation = playerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && finalBoost < maxCharge)
        {
            boostTime += Time.deltaTime;
            playerSpeed = .05f;

            boostCharge = .1f + maxCharge * boostTime;
            finalBoost = boostCharge;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            playerSpeed = .05f;
        }
        else if (boostTime > .5f)
        {
            boostTime -= Time.deltaTime;
            playerSpeed = .1f + finalBoost;
            finalBoost = boostCharge * boostTime;
            Debug.Log(boostCharge);
        }
        else
        {
            playerSpeed = .1f;

            boostTime = 0;
            boostCharge = .2f;
        }

        transform.Translate(0, playerSpeed, 0);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 5);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -5);
        }
    }
}
