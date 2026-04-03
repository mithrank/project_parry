using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float jumpForce = 6f;
    void Start()
    {
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
