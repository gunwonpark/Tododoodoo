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
}
