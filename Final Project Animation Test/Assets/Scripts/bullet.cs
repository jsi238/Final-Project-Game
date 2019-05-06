using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D me;
    public float timer;

    void Start()
    {
        timer = 0;
        me = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        this.transform.localScale = new Vector3(Mathf.Sin(Mathf.PI*timer)*0.7f, 1);

        timer += Time.deltaTime;

        if (timer > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
