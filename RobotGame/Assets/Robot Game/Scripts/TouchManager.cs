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

    private DialogueManager dialogueManager;

    private void Awake()
    {
        InputUI.SetActive(Application.isMobilePlatform);
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
        dialogueManager = FindObjectOfType<DialogueManager>();  
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
    private void Update()
    {
        
        if(Application.isMobilePlatform)
            InputUI.SetActive(!dialogueManager.dialogueOn);
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
        if (moveValue.x < 0.1 && moveValue.x > -0.1)
        {
            return 0;
        }
        else if (moveValue.x > 0.2)
        {
            return 1;
        }
        else
        {
            return -1;
        }

;
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
