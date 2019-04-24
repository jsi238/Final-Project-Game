using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float playerSpeed;
    public float minPlayerSpeed = .1f;

    public float boostCharge;
    public float finalBoost;
    public float maxCharge = .5f;

    public float boostTime;
    public float finalTime;

    bool isBoost;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && boostTime < 1)
        {
            boostTime += Time.deltaTime;
            playerSpeed = .05f;

            boostCharge = minPlayerSpeed + maxCharge * boostTime;
            finalBoost = boostCharge;
            finalTime = boostTime;
            isBoost = false;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            playerSpeed = .05f;
            isBoost = false;
        }
        else if (boostTime > finalTime * .8f && finalBoost >= minPlayerSpeed)
        {
            boostTime -= Time.deltaTime;
            playerSpeed = finalBoost;
            finalBoost = boostCharge * boostTime;
            Debug.Log(finalTime * .9f + " " + boostTime);
            isBoost = true;
        }
        else
        {
            playerSpeed = minPlayerSpeed;

            boostTime = 0;
            isBoost = false;
        }

        transform.Translate(playerSpeed, 0, 0);

        if (Input.GetKey(KeyCode.A) && !isBoost)
        {
            transform.Rotate(0, 0, 5);
        }
        else if (Input.GetKey(KeyCode.D) && !isBoost)
        {
            transform.Rotate(0, 0, -5);
        }
    }
}
