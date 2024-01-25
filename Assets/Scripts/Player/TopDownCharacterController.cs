using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // 다른 곳에서 evnt를 직접 Invoke 하는것을 막아준다다
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<PlayerStat> OnAttackEvent;
    public event Action OnJumpEvent;

    protected Rigidbody2D _rigid;
    [SerializeField] PlayerStatHandler _playerStatHandler;
    protected bool IsAttacking { get; set; }
    protected bool IsJumping { get; set; }

private float _timeSinceLastAttack = float.MaxValue;
    protected virtual void Awake()
    {
        _playerStatHandler = gameObject.GetComponent<PlayerStatHandler>();
        _rigid = GetComponent<Rigidbody2D>();
}
    protected virtual void Update()
    {
        HandleAttackDelay();
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= _playerStatHandler._playerStat.attackDelay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        
        if (IsAttacking && _timeSinceLastAttack > _playerStatHandler._playerStat.attackDelay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(_playerStatHandler._playerStat);
        }
    }
    public void CallAttackEvent(PlayerStat stat)
    {
        OnAttackEvent?.Invoke(stat);
    }
    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }
}
