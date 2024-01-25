using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private StageController _stageController;

    // stage 클리어까지 필요한 시간
    [SerializeField] private float timeForWeek;

    // 현재 내가 버틴 시간
    private float currentTime = 0;

    public bool isReady;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("dfdf");
        isReady = true;
        StartCoroutine(ChangeStageState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeStageState()
    {
        currentTime = 0;
        _stageController.StartStage();
        while (true)
        {
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
            if (currentTime > timeForWeek)
            {
                _stageController.StopStage();
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
