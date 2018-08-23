using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float rayDistance = 1f;
    public Rigidbody rigid;
    private bool isGrounded = true;

    void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 moveDir = new Vector3(inputH, 0f, inputV);
        Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);

        if (Input.GetButton("Jump") && IsGrounded())
        {
            force.y = jumpHeight;
        }

        rigid.velocity = force;


        if (moveDir.magnitude > 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.1f);
        }
    }
}