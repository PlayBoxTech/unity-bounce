using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   private PlayerControls input = null;
   private Vector2 moveVector = Vector2.zero;
   private Rigidbody2D rb = null;
   public float moveSpeed = 10f;

   private void Awake()
   {
        input = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
   }

   private void OnEnable()
   {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;

   }

   private void OnDisable()
   {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;

   }

   private void FixedUpdate()
   {
       // Debug.Log(moveVector);
       rb.velocity = moveVector * moveSpeed;
   } 

   private void OnMovementPerformed(InputAction.CallbackContext value)
   {
        moveVector = value.ReadValue<Vector2>();
   }

   private void OnMovementCanceled(InputAction.CallbackContext value)
   {
        moveVector = Vector2.zero;
   }
}
