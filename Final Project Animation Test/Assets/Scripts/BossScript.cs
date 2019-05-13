using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public static BossScript Instance;

    public GameObject BossSprite;

    public Animator anim;

    float rotateTo;

    public float spinSpeed = 1;

    public float moveSpeed = .04f;
    public float cooldownTime;

    public float trackTime;

    public static bool isDead = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(Instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        trackTime += Time.deltaTime;
        if (Mathf.Abs(PlayerScript.Instance.transform.position.x - transform.position.x) < 2)
        {
            anim.SetFloat("Player distance", 0);
        }
        else
        {
            anim.SetFloat("Player distance", 3);
        }
        if (PlayerScript.Instance.transform.position.y <= 0)
        {
            rotateTo = Mathf.Atan2(PlayerScript.Instance.transform.position.x - this.transform.position.x, PlayerScript.Instance.transform.position.y - this.transform.position.y) * Mathf.Rad2Deg;
        }
        else
        {
            rotateTo = Mathf.Atan2(PlayerScript.Instance.transform.position.y - this.transform.position.y, PlayerScript.Instance.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Boss 1 Static") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Boss 1 Gun Form") /*||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Boss 1 Stretch Attack")*/)
        {
            BossAim();
        }

        //transform.rotation = Quaternion.LookRotation(PlayerScript.Instance.transform.position - this.transform.position, Vector3.forward);

        transform.Translate(moveSpeed, 0, 0);

        if (isDead)
        {
            Debug.Log("boom, headshot");
        }
    }

    public void BossAim()
    {

        Vector3 targetDir = PlayerScript.Instance.transform.position - transform.position;

        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);


        /*
                float zRotate = transform.eulerAngles.z;

                zRotate += (zRotate - rotateTo) * .1f;

                transform.eulerAngles = new Vector3(0, 0, zRotate);
                */
    }

    public static void Snap()
    {
        this.transform.position = BossSprite.transform.position;
    }
}
