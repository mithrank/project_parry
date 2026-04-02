using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float gameSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private Animator anim;
    private bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        FlipCharacterX();
    }

    private void HandleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        movement.x = input * gameSpeed * Time.deltaTime;
        transform.Translate(movement);

        if(input > 0) {
            anim.SetBool("isRunning", true);
            isFacingRight = true;
        } else if(input < 0) {
            anim.SetBool("isRunning", true);
            isFacingRight = false;
        } else
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void FlipCharacterX()
    {
        if(isFacingRight)
        {
            spriteRenderer.flipX = false;
        } else
        {
            spriteRenderer.flipX = true;
        }
    }
}
