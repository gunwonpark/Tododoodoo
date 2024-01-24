using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // 다른 곳에서 evnt를 직접 Invoke 하는것을 막아준다다
    public event Action<Vector2> OnMoveEvent;   

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
}
