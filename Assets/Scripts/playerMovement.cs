using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//Public Variables
	public float speed = 30.0F;
	public float jump_axis = 0F;
    public float jump_speed = 1.5f;
    public float dist_to_ground = 1.0f;
    public float gravity = 1.5f;

    public float max_force = 15f;

    private Rigidbody rbody;
    private Vector3 impulse_force = Vector3.zero;
    public Vector3 moveDirection = Vector3.zero;
	
	void Start() {
		rbody = GetComponent<Rigidbody> ();
        rbody.drag = 1.0f;
    }

	void FixedUpdate() 
	{
		//Jumping
        if (isGrounded() && Input.GetButton("Jump"))
        {
            Debug.Log("JUMPED");
            jump_axis = jump_speed;            
        }
        else if(!isGrounded() && gravity >0)
        {
            jump_axis -= gravity;
        }     
		
        else
        {
            jump_axis = 0;
        }
        //movedirection scalar based on 3 axis
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), jump_axis, Input.GetAxis("Vertical"));

        impulse_force = Vector3.ClampMagnitude((speed * moveDirection * rbody.mass), max_force);
        rbody.AddForce(speed * moveDirection * rbody.mass);
              
	}

    public bool isGrounded()
    {
        return Physics.Raycast(rbody.transform.position, -Vector3.up, dist_to_ground);
    }
}

