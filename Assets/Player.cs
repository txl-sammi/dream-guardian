using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;



    private SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Vector2 inputVector = Vector2.zero;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();




    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void FixedUpdate(){
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        if(inputVector!=Vector2.zero){
            int count = rb.Cast(
                inputVector,
                movementFilter,
                castCollisions,
                moveSpeed*Time.fixedDeltaTime+collisionOffset);
            if(count==0){
                rb.MovePosition(rb.position+inputVector*moveSpeed*Time.fixedDeltaTime);
                System.Console.WriteLine("Moving");
            }
        }



    }


    private void Move(){
        inputVector = GetMovementVectorNormalized();

        if(inputVector.x > 0){
            spriteRenderer.flipX = false;
        }
        else if(inputVector.x < 0){
            spriteRenderer.flipX = true;
        }

        // Vector3 moveDir = new Vector3(inputVector.x, inputVector.y,0);
        // Vector3 newPos = transform.position + (moveDir * moveSpeed * Time.deltaTime);
        // transform.position = newPos;

    }
    private Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            
            inputVector.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
            //Debug.Log("pressing S");
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
