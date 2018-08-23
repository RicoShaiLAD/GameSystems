using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpheight = 10f;
    public Rigidbody rigid;
    // code to only jump once after leaving the ground
    private bool isGrounded = true;
    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            isGrounded = true;
        }
    }
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        // Scope A
        // check if w key is pressed
        //forward
        if (Input.GetKey(KeyCode.W))
            rigid.AddForce(Vector3.forward * speed);
        // {} = Scope.
        // move forward code extended:
        // Vector3 forward;
        // forward.x = 0;
        // forward.y = 0;
        // forward.z = 1;
        // new forward code:
        //Vector3 forward = new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.S))
            rigid.AddForce(Vector3.back * speed);
        //right
        if (Input.GetKey(KeyCode.D))
            rigid.AddForce(Vector3.right * speed);
        //left
        if (Input.GetKey(KeyCode.A))
            rigid.AddForce(Vector3.left * speed);
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
            isGrounded = false;
        }

        // Scope B
        // Declaration | Definition
        // Vector3 forward;
        // forward.x = 0;
        // forward.y = 0;
        // forward.z = 1;
    }
}