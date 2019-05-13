using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    public Text endText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossScript.isDead)
        {
            endText.text = "You Win";
        }
        else
        {
            endText.text = "Game Over";
        }

    }
}
