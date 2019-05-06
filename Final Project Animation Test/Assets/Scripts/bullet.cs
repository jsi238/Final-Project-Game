using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D me;
    public float size;

    void Start()
    {
        me = GetComponent<Rigidbody2D>();
        size = 1.5f;
    }
    
    void Update()
    {
        size = size * (4*Time.deltaTime+1);
        this.transform.localScale = new Vector3(1, size);

        if (size > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
