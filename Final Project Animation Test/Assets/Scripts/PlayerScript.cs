using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;

    public Animator Myanimator;
    public ParticleSystem particles;

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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

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
            Myanimator.SetBool("Charging",true);
            particles.transform.position = this.transform.position;
            particles.startColor = new Color(1, .64f, 0);
            particles.Emit(1);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            playerSpeed = .05f;
            isBoost = false;
            Myanimator.SetBool("Charging", true);
            particles.transform.position = this.transform.position;
            particles.startColor = Color.yellow;
            particles.Emit(10);
        }
        else if (boostTime >= finalTime * .8f && finalBoost >= minPlayerSpeed)
        {
            boostTime -= Time.deltaTime;
            playerSpeed = finalBoost;
            finalBoost = boostCharge * boostTime;
            //Debug.Log(finalTime * .9f + " " + boostTime);
            isBoost = true;
            Myanimator.SetBool("Charging", false);
            Myanimator.SetBool("Charged", true);
        }
        else
        {
            playerSpeed = minPlayerSpeed;
            isBoost = false;
            boostTime = 0;
            Myanimator.SetBool("Charging", false);
            Myanimator.SetBool("Charged", false);
        }

        transform.Translate(playerSpeed, 0, 0);
        
        if (Input.GetKey(KeyCode.A) && !isBoost && !isSpinLeft)
        {
            transform.Rotate(0, 0, 7);
            isSpinRight = true;
        }
        else
        {
            isSpinRight = false;
        }
        if (Input.GetKey(KeyCode.D) && !isBoost && !isSpinRight)
        {
            transform.Rotate(0, 0, -7);
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

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!isBoost)
        {
            if (collision.gameObject.tag == "enemy")
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (collision.gameObject.tag == "heart")
            {
                collision.gameObject.SetActive(false);
                BossScript.isDead = true;
            }
        }
    }
}
