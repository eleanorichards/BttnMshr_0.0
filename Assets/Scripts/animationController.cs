using UnityEngine;
using System.Collections;

public class animationController : MonoBehaviour {

    Animator anim;
    bool idle = true;
    bool running = false;

    public Rigidbody rbody;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        anim.Play("Idle");

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            running = true;
            idle = false;
        }
       else
        {
            idle = true;
            running = false;
        }

        anim.SetBool("Running", running);
        anim.SetBool("Idle", idle);
    }
}
