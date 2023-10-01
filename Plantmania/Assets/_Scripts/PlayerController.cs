using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //for player movement
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private int speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue inputValue) //this gets the value from the PlayerInputs
    {
        movement = inputValue.Get<Vector2>(); //WASD
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //makes the player move when pressing WASD
    }
}
