using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatHandler : MonoBehaviour
{
    [Header("플레이어 스텟")]
    public PlayerStat _playerStat;
    
    [Header("강화 정도")]
    [SerializeField] float _increaseMoveSpeedRate = 0.2f;
    [SerializeField] float _increaseJumpDegreeRate = 0.2f;
    [SerializeField] float _decreaseAttackDelayRate = 0.02f;

    public void IncreaseMoveSpeed()
    {
        _playerStat.moveSpeed += _increaseMoveSpeedRate;
    }
    public void IncreaseJumpDegree()
    {
        _playerStat.jumpDegree += _increaseJumpDegreeRate;
    }
    public void  DecreaseAttackDelay()
    {
        _playerStat.attackDelay += _decreaseAttackDelayRate;
    }
}
