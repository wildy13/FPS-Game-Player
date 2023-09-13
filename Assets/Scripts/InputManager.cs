using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayersInput playerInput;
    private PlayersInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private Vector2 movementInput;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayersInput();
        onFoot = playerInput.onFoot;
        motor =  GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx =>
        {
            motor.Jump();
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tell  the playermotor to move using the value from our movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector3>());

    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable(); 
    }
}
