using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text MyscoreText;
    private int Scorenum;


    // Start is called before the first frame update
    void Start()
    {
        Scorenum = 0;
        MyscoreText.text = "score : " + Scorenum;
    }

    private void onTriggerEnter2D(Collider2D coin)
    {



    }
}