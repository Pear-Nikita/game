using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public static GameInput Instance { get; private set; }
    private void Awake()
    {
        Instance = this;    

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 vectorInput = playerInputActions.Player.Move.ReadValue<Vector2>();
        return vectorInput;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }

    public bool IsPlayerSmashed()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) { return true; } else { return false; }
    }
}
