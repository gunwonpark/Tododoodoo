using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] Animator anim_Head;
    [SerializeField] Animator anim_Body;

    [Header("Pivot")]
    [SerializeField] Transform headTransform;    
    [SerializeField] Transform weaponTransform;

    [Header("ETC")]
    [SerializeField] SpriteRenderer bodyRend;
    [SerializeField] ParticleSystem fireParticle;

    private TopDownCharacterController characterController;

    private Vector3 _rotation;

    private readonly int Move = Animator.StringToHash("Move");
    private readonly int Fire = Animator.StringToHash("Fire");

    private void Awake()
    {
        characterController = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        characterController.OnMoveEvent += MoveAnim;
        characterController.OnLookEvent += Look;
        characterController.OnAttackEvent += FireEffect;
    }

    private void Update()
    {
        anim_Head.SetBool(Fire, characterController.IsAttacking);
        anim_Body.SetBool(Fire, characterController.IsAttacking);
    }

    private void MoveAnim(Vector2 dir)
    {
        float moveX = Mathf.Abs(dir.x);

        anim_Head.SetFloat(Move, moveX);
        anim_Body.SetFloat(Move, moveX);
    }

    private void Look(Vector2 dir)
    {
        dir = dir.normalized;

        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float rotZ = Mathf.Abs(z) > 90 ? 180 - z : z;
        float y;

        z = Mathf.Abs(z);        
        bodyRend.flipX = z > 90;

        y = z > 90 ? 180 : 0;
        _rotation = new Vector3(0, y, rotZ);

        headTransform.rotation = Quaternion.Euler(_rotation);
        weaponTransform.rotation = Quaternion.Euler(_rotation);        
    }

    private void FireEffect(PlayerStat stat)
    {
        fireParticle.Play();
    }
}
