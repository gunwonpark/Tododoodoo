using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;

    [SerializeField] private Transform _spawnPointsRoot;
    ObstacleSpawner obstacleSpawner;
    private List<Transform> _spawnPoints = new List<Transform>();

    // 스폰 관련 시작 변수
    [Header("Spawn Value")]
    [SerializeField] private int _spawnNum;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnLaserDelay;
    [SerializeField] private int _typeOfMonster;

    // 스폰 관련 변경된 변수
    private int _currentSpawnNum;
    private float _currentSpawnDelay;
    private float _currentSpawnLaserDelay;
    private int _currentTypeOfMonster;

    // 스폰 관련 변수 변경 시 적용할 값
    [Header("Applied Value")]
    [SerializeField] private int _addSpawnNum;
    [SerializeField] private float _addSpawnDelay;

    // 레일에 동시에 생성할 시 중복되지 않은 랜덤한 레일 인덱스 저장
    private List<int> spawnPointIndex = new List<int>();

    // 생성할 몬스터 타입 이름
    private string[] spawnMonsterType = { "Monster_Common", "Monster_Range", "Monster_Rush" };

    private void Awake()
    {
        for(int i = 0; i < _spawnPointsRoot.childCount; i++)
        {
            _spawnPoints.Add(_spawnPointsRoot.GetChild(i));
        }
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentSpawnNum = _spawnNum;
        _currentSpawnDelay = _spawnDelay;
        _currentSpawnLaserDelay = _spawnLaserDelay;
        _currentTypeOfMonster = _typeOfMonster;
    }
    public void StartStage(int stageCount)
    {
        InitStageValue(stageCount);
        StartCoroutine(SpawnMonster());
        StartCoroutine(SpawnRazer());
    }

    public void StopStage()
    {
        StopAllCoroutines();
        for(int i = 0; i < spawnMonsterType.Length; i++)
        {
            ObjectPool.i.DestroyAll(spawnMonsterType[i]);
        }
        ObjectPool.i.DestroyAll("Block");
        ObjectPool.i.DestroyAll("WarringLine");
        ObjectPool.i.DestroyAll("Razer");
        ObjectPool.i.DestroyAll("Bullet");
    }

    // 스테이지에 따른 스폰관련 변수 변경
    void InitStageValue(int stageCount)
    {
        if(stageCount % 2 == 0)
        {
            if(_currentSpawnNum < 5)
            {
                _currentSpawnNum += _addSpawnNum;
                _currentSpawnDelay = _spawnDelay;
            }
            if(_currentTypeOfMonster < spawnMonsterType.Length)
            {
                _currentTypeOfMonster++;
            }
        }
        else
        {
            _currentSpawnDelay -= _addSpawnDelay;
        }
    }

    /// <summary>
    /// 범위 안의 랜덤한 값을 개수만큼 뽑아 리스트로 반환
    /// </summary>
    /// <param name="minValue"> 최소값(포함) </param>
    /// <param name="maxValue"> 최대값(포함 x) </param>
    /// <param name="num"> 뽑는 개수 </param>
    /// <returns></returns>
    private List<int> GetRandomIndexList(int minValue, int maxValue, int num)
    {
        List<int> list = new List<int>();

        int currentNumber = Random.Range(minValue, maxValue);
        for(int i = 0; i < num;)
        {
            if (list.Contains(currentNumber))
            {
                currentNumber = Random.Range(minValue, maxValue);
            }
            else
            {
                list.Add(currentNumber);
                i++;
            }
        }
        return list;
    }
    public void ResetCur()
    {
        _currentSpawnDelay = _spawnDelay;
        _currentSpawnLaserDelay = _spawnLaserDelay;
        _currentSpawnNum = _spawnNum;
        _currentTypeOfMonster = _typeOfMonster;
    }
    // 몬스터 스폰 코루틴
    IEnumerator SpawnMonster()
    {
        while(true)
        {
            spawnPointIndex = GetRandomIndexList(0, _spawnPoints.Count, _currentSpawnNum);

            for(int i = 0; i < _currentSpawnNum; i++)
            {
                int type = Random.Range(0, _currentTypeOfMonster);
                GameObject temp = ObjectPool.i.GetFromPool(spawnMonsterType[type]);
                temp.transform.position = _spawnPoints[spawnPointIndex[i]].position;
                MonsterController mc = temp.GetComponent<MonsterController>();
                mc.Setup(obstacleSpawner, GameManager.Instance.Player);
            }

            yield return new WaitForSeconds(_currentSpawnDelay);
        }
    }
    IEnumerator SpawnRazer() //맵 완성후 프리팹의 스케일 y값도 조절해야함
    {
        while (true)
        {
            yield return new WaitForSeconds(_currentSpawnLaserDelay);//레이저 주기
            GameObject warringLine = ObjectPool.i.GetFromPool("WarringLine");
            warringLine.transform.position = GameManager.Instance.Player.position;//PlayerPosition;
            yield return new WaitForSeconds(1);// 경고 시간
            warringLine.SetActive(false);
            GameObject Razer = ObjectPool.i.GetFromPool("Razer");
            Razer.transform.position = new Vector3(warringLine.transform.position.x, warringLine.transform.position.y + 50, warringLine.transform.position.z);
            yield return new WaitForSeconds(1);//유지시간
            Razer.SetActive(false);
        }
    }
}
