using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int health = 2;

    public void SetHealth(int x){
        health = x;
        if (health <= 0)
            Defeated();
    }
    
    public int GetHealth(){ return health; }
    
    //public float health = 1;  


    public void Defeated()
    {
        Destroy(gameObject); 
    } 
}
