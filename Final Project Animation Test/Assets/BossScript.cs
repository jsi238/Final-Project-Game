using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    float rotateTo;
    float currentRotation;
    public float spinSpeed = 1;

    float moveSpeed = .01f;
    float cooldownTime;

    float trackTime;

    public static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.Instance.transform.position.y <= 0)
        {
            rotateTo = Mathf.Atan2(PlayerScript.Instance.transform.position.x - this.transform.position.x, PlayerScript.Instance.transform.position.y - this.transform.position.y) * Mathf.Rad2Deg;
        }
        else
        {
            rotateTo = Mathf.Atan2(PlayerScript.Instance.transform.position.y - this.transform.position.y, PlayerScript.Instance.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        }

        BossAim();

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
        Debug.Log(rotateTo);
    }

    public void StretchEntry()
    {

    }

    public void StretchExit()
    {

    }

    public void StaticReset()
    {

    }
}
