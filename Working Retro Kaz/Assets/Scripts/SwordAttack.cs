using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public int damage = 3; 

    Vector2 rightAttackOffset;
    

    private void Start() {
        rightAttackOffset = swordCollider.offset;
        Debug.Log("offset" + rightAttackOffset);
        swordCollider.enabled = false;
    }


    public void AttackRight() {
        swordCollider.enabled = true;
    
        //FlipCollider();
            
        swordCollider.offset = rightAttackOffset;

        //transform.position = rightAttackOffset;
        Debug.Log ("right" + transform.position);
    }



    public void AttackLeft() {
        swordCollider.enabled = true;
        
       swordCollider.offset = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
        
        //transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        //swordCollider.offset = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);

        Debug.Log ("left" + transform.position);

    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("enemy detected");
            Enemy enemy = other.GetComponent<Enemy>(); 

            if(enemy != null)
            {
                Debug.Log("Enemy damage");
                enemy.SetHealth( enemy.GetHealth() - damage ); 
            }
        }
    }
}
