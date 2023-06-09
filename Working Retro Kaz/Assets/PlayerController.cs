using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//håndtere movement fra player
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementfilter;

    public SwordAttack swordAttack;

    public PlayerActions _playerActions; 
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> CastCollisions = new List<RaycastHit2D>();
    [SerializeField] private InputActionReference movement;

    bool canMove = true;
    void Awake(){
        _playerActions = new PlayerActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() { 

         movementInput = _playerActions.PlayerMovement.movement.ReadValue<Vector2>();



        if(canMove) {

    //movenet = not 0, try to move
        if(movementInput != Vector2.zero) { 
            bool success = TryMove(movementInput);

            if(!success) {
                success = TryMove(new Vector2(movementInput.x, 0));
            }

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

        
            
            animator.SetBool("isMoving", success);
        } else {
            animator.SetBool("isMoving", false);
            }

            print("isMoving: " + animator.GetBool("isMoving"));

        if(movementInput.x < 0) {
            spriteRenderer.flipX = true;
        } else if (movementInput.x > 0) {
            spriteRenderer.flipX = false;
        }
    
        }

    }

private bool TryMove(Vector2 direction) { 
    if(direction != Vector2.zero) {
       
        int count = rb.Cast(
            direction,
            movementfilter,
            CastCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
        } else {
                return false;
        } 
    } else {
      
      return false;
    }
}
    

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
        } 

    void OnAttack() {
        Debug.Log("Attack detected..");
        animator.SetTrigger("Attack");
    }

    public void SwordAttack() {
        LockMovement();
        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
            Debug.Log("SwordAttack colliderPos: " + swordAttack.transform.position );
        }else {
            swordAttack.AttackRight();
            Debug.Log("SwordAttack colliderPos: " + swordAttack.transform.position );
        }

    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }

    public void OnEnable(){
        _playerActions.PlayerMovement.Enable();

    }

   public void Disable(){
        _playerActions.PlayerMovement.Disable();

    }

}