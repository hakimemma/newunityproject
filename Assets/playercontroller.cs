using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    float maxSpeed = 6.0f;
    bool isOnGround = false;

    //create reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    // Start is called before the first frame update
    void Start()
    {
      //Find the Rigidbody2D component that is attatched to the same object as this script
      playerObject = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        //create a 'float' that will be equal to the players horizontal input
        float movementValueX = Input.GetAxis("Horizontal");
        
        //change the X velocity of the Rigidbody2D to be equal to the moment value
        playerObject.velocity = new Vector2 (movementValueX * maxSpeed, playerObject.velocity.y);

        //check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, 100.0f));
        }
        

    }
} 