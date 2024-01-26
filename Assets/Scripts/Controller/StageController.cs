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

    private int _currentSpawnNum;
    private float _currentSpawnDelay;
    private float _currentSpawnLaserDelay;
    private int _currentTypeOfMonster;

    private List<int> spawnPointIndex = new List<int>();

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

    // Update is called once per frame
    void Update()
    {
        
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
    }

    void InitStageValue(int stageCount)
    {
        if(stageCount % 2 == 0)
        {
            if(_currentSpawnNum < 5)
            {
                _currentSpawnNum++;
                _currentSpawnDelay = _spawnDelay;
            }
            if(_currentTypeOfMonster < spawnMonsterType.Length)
            {
                _currentTypeOfMonster++;
            }
        }
        else
        {
            _currentSpawnDelay -= .2f;
        }
    }

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

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
    IEnumerator SpawnRazer() //맵 완성후 프리팹의 스케일 y값도 조절해야함
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnLaserDelay);//레이저 주기
            GameObject warringLine = ObjectPool.i.GetFromPool("WarringLine");
            warringLine.transform.position = GameManager.Instance.Player.position;//PlayerPosition;
            yield return new WaitForSeconds(1);// 경고 시간
            warringLine.SetActive(false);
            GameObject Razer = ObjectPool.i.GetFromPool("Razer");
            Razer.transform.position = warringLine.transform.position;
            yield return new WaitForSeconds(1);//유지시간
            Razer.SetActive(false);
        }
    }
}
