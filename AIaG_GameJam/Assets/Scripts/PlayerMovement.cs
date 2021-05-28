using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
        
    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 movement = ctx.ReadValue<Vector2>();
        rb.velocity = movement*speed;
    }
}
