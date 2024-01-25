using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;

    [SerializeField] private Transform _spawnPointsRoot; 

    private List<Transform> _spawnPoints = new List<Transform>();
    ObjectPool pool;

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

            Instantiate(blockPrefab, _spawnPoints[spawnPointIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator SpawnRazer() //맵 완성후 프리팹의 스케일 y값도 조절해야함
    {
        GameObject warringLine = pool.GetFromPool("WarringLine");
        warringLine.transform.position = Vector3.zero;//PlayerPosition;
        yield return new WaitForSeconds(1);//WaitTime;
        warringLine.SetActive(false);
        GameObject Razer = pool.GetFromPool("Razer");
        Razer.transform.position = warringLine.transform.position;
        yield return new WaitForSeconds(1);
        Razer.SetActive(false);
        yield return new WaitForSeconds(4);//레이저 주기
    }
}
