using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D me;
    public float speed;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public SpriteRenderer mySR;

    void Start()
    {
        me = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
        speed = 150;
    }
    
    void Update()
    {
        me.velocity = transform.up * speed * Time.deltaTime;
        speed = speed * (4 * Time.deltaTime+1);
        if (speed > 1000)
        {
            mySR.sprite = sprite3;
        }
        else if (speed > 500)
        {
            mySR.sprite = sprite2;
        }

        if (speed > 5000)
        {
            Destroy(this.gameObject);
        }
    }
}
