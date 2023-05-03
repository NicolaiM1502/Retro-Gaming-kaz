using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float health 
    {
        set { 
            health = value; 

            if(health <= 0) {
             //   defeated();
            } 
        }
        get {
            return health; 
        }
    }


    //public float health = 1;  


    public void Defeated()
    {
       // Destroy(GameObject); 
    } 
}
