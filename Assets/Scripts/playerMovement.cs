using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	//Public Variables
	public float speed = 0.0F;
	public float jump_axis = 0F;
    public float jump_speed = 1.5f;
    public float dist_to_ground = 1.0f;
    public float gravity = 1500f;

    public float max_force = 15f;

    private Rigidbody rbody;
    private  Animator animator;
    private Vector3 impulse_force = Vector3.zero;
    public Vector3 moveDirection = Vector3.zero;
    //................................................................
	//IMPLEMENT GAMEOBJECT FIXED UPDATE SO ALL TICKING ON GAMEPLAY LOOP
    //................................................................

	void Start() {
		rbody = GetComponent<Rigidbody> ();
        animator = GetComponent<Animator>();
        rbody.drag = 7.5f;
        speed = 100.0f;
        animator.SetBool("Idle", true);
    }

	void FixedUpdate() 
	{
		//Jumping
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMPED");
            //rbody.transform.Rotate(0, 100 * Time.deltaTime, 0);
            jump_axis = jump_speed;            
        }
        else if (!isGrounded() && jump_axis >= 0 /*&& jump_axis >= 0*/)
        {
            jump_axis -= gravity;
        }

        else
        {
            jump_axis = 0;
        }

        //movedirection scalar based on 3 axis
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        impulse_force = Vector3.ClampMagnitude((speed * moveDirection * rbody.mass), max_force) * Time.deltaTime;
        
        //animationUpdate();
 
        //ROTATION
        float heading = Mathf.Atan2(moveDirection.x, moveDirection.z);
        rbody.transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);

        impulse_force.y = jump_axis;

        //PUSH PLAYER
        rbody.AddForce(speed * impulse_force * rbody.mass);
              
	}

    void animationUpdate()
    {
        if(moveDirection != Vector3.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetBool("Standing", true);
        }
    }


    public bool isGrounded()
    {
        return Physics.Raycast(rbody.transform.position, -Vector3.up, dist_to_ground);
    }
}

