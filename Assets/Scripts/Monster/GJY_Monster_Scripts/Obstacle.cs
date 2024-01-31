using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour, IDamagable
{
    [SerializeField] Text _todoText;
    [SerializeField] string[] _todoList;    

    private SpriteRenderer _rend;
    private ObstacleEffect _effect;

    private enum HPState { High, Medium, Low }

    public float _hp;
    private float _maxHp;

    private bool _isBroken = false;
    private bool _isInit = false;

    public void Setup(float hp, Vector3 position)
    {
        if (!_isInit)
        {
            _rend   = GetComponentInChildren<SpriteRenderer>();
            _effect = GetComponent<ObstacleEffect>();
            _isInit = true;
        }

        _isBroken       = false;
        _hp             = hp;
        _maxHp          = hp;                
        _todoText.text  = _todoList[Random.Range(0, _todoList.Length)];
        _rend.sprite    = _effect.SpriteChange((int)HPState.High);

        transform.position = position;
    }

    public void GetDamage(float damage)
    {
        if (_isBroken)
            return;

        _hp -= damage;
        HPCheckAndChangeSprite();

        if (_hp <= 0)
            Dead();
    }

    public void HPCheckAndChangeSprite()
    {
        // 페이즈 3개로 나눔
        // 1/3 체력이하, 2/3 체력이하, 그 이상 
        float devide = _maxHp / 3f;
        if (_hp > devide * 2)
            _rend.sprite = _effect.SpriteChange((int)HPState.High);
        if (_hp <= devide * 2)
            _rend.sprite = _effect.SpriteChange((int)HPState.Medium);
        if (_hp <= devide * 1)
            _rend.sprite = _effect.SpriteChange((int)HPState.Low);
    }

    public void Dead()
    {        
        _isBroken = true;        
        _effect.SpawnEffect();        

        gameObject.SetActive(false);
    }    
}
