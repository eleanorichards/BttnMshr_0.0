using UnityEngine;
using System.Collections;
using System;

public class playerMovement : MonoBehaviour {

	//Public Variables
	public float speed = 0.0F;
	public float jump_axis = 0F;
    public float jump_speed = 1.5f;
    public float dist_to_ground = 1.0f;
    public float gravity = 1500f;

    public float max_force = 15f;
    private float rot_angle = 360.0f;
    private Rigidbody rbody;
    private  Animator animator;
    private GameObject body;
    private GameObject head;

    private Vector3 impulse_force = Vector3.zero;
    public Vector3 moveDirection = Vector3.zero;
    //................................................................
	//IMPLEMENT GAMEOBJECT FIXED UPDATE SO ALL TICKING ON GAMEPLAY LOOP
    //................................................................

	void Start() {
        body = GameObject.Find("Body1");
        head = GameObject.Find("Head1");

        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);

        rbody = GetComponent<Rigidbody> ();
        rbody.drag = 7.5f;
        speed = 10.0f;

        //if (gameObject.tag == "Player1")
        //{
        //    axis_string = "Horizontal1";
        //    jump_string = "P1 Jump";
        //    player_name = "Player1";
        //}
        //if (gameObject.tag == "Player2")
        //{
        //    axis_string = "Horizontal2";
        //    jump_string = "P2 Jump";
        //    player_name = "Player2";
        //}
        //if (gameObject.tag == "Player3")
        //{
        //    axis_string = "Horizontal3";
        //    jump_string = "P3 Jump";
        //    player_name = "Player3";
        //}
        //if (gameObject.tag == "Player4")
        //{
        //    axis_string = "Horizontal4";
        //    jump_string = "P4 Jump";
        //    player_name = "Player4";
        //}

    //}

}

    void FixedUpdate() 
	{
		//Jumping
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMPED");

            StartCoroutine(RotateBodyZ(0.5f));
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
        rbody.AddForce(impulse_force );
              
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

    IEnumerator RotateBody(float duration)
    {
        
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float rotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            body.transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
            yield return null;
        }
    }

    IEnumerator RotateBodyZ(float duration)
    {

        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float rotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            body.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotation);
            yield return null;
        }
    }

    IEnumerator RotateHeadY(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float rotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            head.transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
            yield return null;
        }
    }

}

