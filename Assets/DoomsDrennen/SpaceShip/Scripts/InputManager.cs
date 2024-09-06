using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; } //? Singleton
    
    private Controls controls;
    
    public float moveValue = 0f;
    public float turnValue = 0f;

    private void OnEnable()
    {
        if(controls == null) controls = new();
        controls.Enable();
    }
    private void OnDisable()
    {
        if (controls == null) controls = new();
        controls.Disable();

    }
    private void Awake()
    {
        Instance = this;
        
        if (controls == null) controls = new();
        
        controls.Keyboard.Move.performed += OnMove;
        controls.Keyboard.Move.canceled += OnMove;

        controls.Keyboard.Turn.performed += OnTurn;
        controls.Keyboard.Turn.canceled += OnTurn;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<float>();
    }
    private void OnTurn(InputAction.CallbackContext context)
    {
        turnValue = context.ReadValue<float>();
    }
}
