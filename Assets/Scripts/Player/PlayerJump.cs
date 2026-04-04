using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float jumpForce = 6f;
    private float playerHalfHeight;
    private float halfWidth;
    // private bool isGrounded;
    void Start()
    {
        playerHalfHeight = sr.bounds.extents.y + 0.1f;
        halfWidth = sr.bounds.extents.x * 0.8f;
        // Debug.Log(playerHalfHeight);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Jump") && GetIsGrounded())
        {
            Jump();
        }
    }

    private bool GetIsGrounded()
    {

        Vector2 center = transform.position;
        Vector2 left = center + Vector2.left * halfWidth;
        Vector2 right = center + Vector2.right * halfWidth;

        bool hitCenter = Physics2D.Raycast(center, Vector2.down, playerHalfHeight, LayerMask.GetMask("Ground"));
        bool hitLeft = Physics2D.Raycast(left, Vector2.down, playerHalfHeight, LayerMask.GetMask("Ground"));
        bool hitRight = Physics2D.Raycast(right, Vector2.down, playerHalfHeight, LayerMask.GetMask("Ground"));

        Debug.DrawRay(center, Vector2.down * playerHalfHeight, Color.red);
        Debug.DrawRay(left, Vector2.down * playerHalfHeight, Color.red);
        Debug.DrawRay(right, Vector2.down * playerHalfHeight, Color.red);

        return hitCenter || hitLeft || hitRight;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
