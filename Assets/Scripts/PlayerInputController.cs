using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        CallMoveEvent(direction);
    }
}
