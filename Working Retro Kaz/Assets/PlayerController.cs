using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//håndtere movement fra player
public class playermove : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementfilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> CastCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() { 
    //movenet = not 0, try to move
        if(movementInput != Vector2.zero) { 
            bool success = TryMove(movementInput);

            if(!success) {
                success = TryMove(new Vector2(movementInput.x, 0));
            
                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

            }
            
            
        } 
            
        
    }

private bool TryMove(Vector2 direction){ 
        int count = rb.Cast(
            direction,
            movementfilter,
            CastCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        

            if (count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        }


    void OnMove(InputValue movementValue) => movementInput = movementValue.Get<Vector2>();

}