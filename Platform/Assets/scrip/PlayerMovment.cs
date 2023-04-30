using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableground;
    
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpforce = 7f;

    private enum MovementState { idel, running, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && ground())
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        MovementState State;
        if (dirX > 0f)
        {
            State = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            State = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.idel;
        }

        if(rb.velocity.y > .1f)
        {
            State = MovementState.jumping;
        }
        else if( rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }

        anim.SetInteger("State", (int)State);


    }

    private bool ground()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }
}
