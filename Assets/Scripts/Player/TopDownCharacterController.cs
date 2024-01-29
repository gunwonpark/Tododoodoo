using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // 다른 곳에서 evnt를 직접 Invoke 하는것을 막아준다다
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<PlayerStat> OnAttackEvent;
    public event Action OnDeadEvent;
    public event Action OnJumpEvent;

    protected Rigidbody2D _rigid;
    [SerializeField] PlayerStatHandler _playerStatHandler;
    public bool IsAttacking { get; set; }
    protected bool IsJumping { get; set; }
    public bool IsDead { get; set; }

    private float _timeSinceLastAttack = float.MaxValue;


    //test용 true일 경우 플레이어가 죽지 않는다
    public bool _super;
    protected virtual void Awake()
    {
        _playerStatHandler = gameObject.GetComponent<PlayerStatHandler>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
        if (IsDead)
        {
            CallDeadEvent();
        }
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
    public void CallDeadEvent()
    {
        if (_super != true)
            OnDeadEvent?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") || (collision.CompareTag("Razer")))
        {
            IsDead = true;
            return;
        }
        
        if (collision.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null && bullet.shooter == Shooter.Monster)
            {
                IsDead = true;
            }
        }
    }
}
