using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;

    [SerializeField] private Transform _spawnPointsRoot; 

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake()
    {
        for(int i = 0; i < _spawnPointsRoot.childCount; i++)
        {
            _spawnPoints.Add(_spawnPointsRoot.GetChild(i));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartStage()
    {
        StartCoroutine(SpawnMonster());
        StartCoroutine(SpawnRazer());
    }

    public void StopStage()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnMonster()
    {
        while(true)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            GameObject temp = ObjectPool.i.GetFromPool("Monster_Common");
            temp.transform.position = _spawnPoints[spawnPointIndex].position;
            yield return new WaitForSeconds(1f);
        }
    }
    [SerializeField] GameObject t;
    IEnumerator SpawnRazer() //맵 완성후 프리팹의 스케일 y값도 조절해야함
    {
        while (true)
        {
            yield return new WaitForSeconds(4);//레이저 주기
            GameObject warringLine = ObjectPool.i.GetFromPool("WarringLine");
            warringLine.transform.position = t.transform.position;//PlayerPosition;
            yield return new WaitForSeconds(1);// 경고 시간
            warringLine.SetActive(false);
            GameObject Razer = ObjectPool.i.GetFromPool("Razer");
            Razer.transform.position = warringLine.transform.position;
            yield return new WaitForSeconds(1);//유지시간
            Razer.SetActive(false);
        }
    }
}
