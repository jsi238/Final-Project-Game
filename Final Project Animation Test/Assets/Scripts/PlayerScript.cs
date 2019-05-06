using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public float playerSpeed;
    public float minPlayerSpeed = .1f;

    public float boostCharge;
    public float finalBoost;
    public float maxCharge = .5f;

    public float boostTime;
    public float finalTime;

    bool isBoost;
    bool isSpinLeft;
    bool isSpinRight;

    Vector2 velocity;
    Vector2 boost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

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
            rb.velocity = new Vector2(playerSpeed, 0);
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
        else if (boostTime >= finalTime * .8f && finalBoost >= minPlayerSpeed)
        {
            anim.SetBool("boost", true);
            anim.SetBool("boost", false);
            boostTime -= Time.deltaTime;
            playerSpeed = finalBoost;
            finalBoost = boostCharge * boostTime;
            //Debug.Log(finalTime * .9f + " " + boostTime);
            isBoost = true;
        }
        else
        {
            playerSpeed = minPlayerSpeed;
            isBoost = false;
            boostTime = 0;
        }

        transform.Translate(playerSpeed, 0, 0);
        

        if (Input.GetKey(KeyCode.A) && !isBoost && !isSpinLeft)
        {
            transform.Rotate(0, 0, 10);
            isSpinRight = true;
        }
        else
        {
            isSpinRight = false;
        }
        if (Input.GetKey(KeyCode.D) && !isBoost && !isSpinRight)
        {
            transform.Rotate(0, 0, -10);
            isSpinLeft = true;
        }
        else
        {
            isSpinLeft = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            transform.Rotate(0, 0, 360 - 2 * transform.eulerAngles.z);
        }
        else
        {
            transform.Rotate(0, 0, 180 - 2 * transform.eulerAngles.z);
        }
    }
}
