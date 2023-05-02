using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    Vector2 rightAttackOffset;
    Collider2D swordCollider;

    private void Start() {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
        Debug.Log("offset" + rightAttackOffset);
        swordCollider.enabled = false;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
    
        FlipCollider();
            
        swordCollider.offset = rightAttackOffset;

        //transform.position = rightAttackOffset;
        Debug.Log ("right" + transform.position);
    }

    void FlipCollider() {
        swordCollider.offset = new Vector3(swordCollider.offset.x * -1, swordCollider.offset.y);
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        {
            FlipCollider();
        }
        //transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        swordCollider.offset = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);

        Debug.Log ("left" + transform.position);

    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }
}
