using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public LayerMask GroundMask;
    public LayerMask IgnoreMask;

    private Rigidbody2D rig;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    public float jumpVelocity = 5.0f;

    // Use this for initialization
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        TakeInput();

        if (rig.velocity.y < 0)
        {
            rig.AddForce(Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (rig.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rig.AddForce(Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void TakeInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapArea(transform.position, transform.position, GroundMask);
    }
}