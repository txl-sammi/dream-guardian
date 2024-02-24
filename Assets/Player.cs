using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move(){
        Vector2 inputVector = GetMovementVectorNormalized();

        if(inputVector.x > 0){
            spriteRenderer.flipX = false;
        }
        else if(inputVector.x < 0){
            spriteRenderer.flipX = true;
        }

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y,0);
        Vector3 newPos = transform.position + (moveDir * moveSpeed * Time.deltaTime);
        transform.position = newPos;

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
