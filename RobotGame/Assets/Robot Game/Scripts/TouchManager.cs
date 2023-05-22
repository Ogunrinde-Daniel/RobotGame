using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TouchManager : MonoBehaviour
{
    public GameObject InputUI;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveValue;
    private bool jump;

    private void Awake()
    {
        InputUI.SetActive(Application.isMobilePlatform);
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
    }
    private void OnEnable()
    {
        moveAction.performed += MovePressed;
        jumpAction.started += JumpPressed;
        jumpAction.canceled += JumpReleased;
    }

    private void OnDisable()
    {
        moveAction.performed -= MovePressed;
        jumpAction.performed -= JumpPressed;
        jumpAction.canceled -= JumpReleased;
    }
    private void MovePressed(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
    }
    private void JumpPressed(InputAction.CallbackContext context)
    {
        jump = true;
    }
    private void JumpReleased(InputAction.CallbackContext context)
    {
        jump = false;
    }

    public float getXAxis()
    {
        return moveValue.x;
    }
    public bool getJump()
    {
        return jump;
    }    
    public void setJump(bool value)
    {
        jump = value;
    }

}
