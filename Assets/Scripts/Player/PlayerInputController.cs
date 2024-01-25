using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    // 눌렀을때 한번 뗐을때 한번 호출
    public void OnMove(InputValue value)
    {        
        Vector2 direction = value.Get<Vector2>();
        CallMoveEvent(direction);
    }
    // 마우스가 이동 할 때 마다 호출
    public void OnLook(InputValue value)
    {
        Vector2 mousePosition = value.Get<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        CallLookEvent(direction);
    }
    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
    public void OnJump()
    {
        if (!IsJumping)
        {
            IsJumping = true;
            CallJumpEvent();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = false;
        }       
    }
}
