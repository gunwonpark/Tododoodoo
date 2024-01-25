using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 현재 게임 진행 상황에 대한 상태
    public enum State
    {
        Ready,
        Play,
        Reward,
        Wait,
    }

    [SerializeField] private StageController _stageController;
    [SerializeField] private Reward _reward;

    // stage 클리어까지 필요한 시간
    [SerializeField] private float timeForWeek;

    // 현재 내가 버틴 시간
    private float currentTime = 0;

    public bool isReady;
    public bool isPlaying;

    public State currentState;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGameSceneByState();
    }

    // currentState에 따른 게임 진행상황 변경
    private void ChangeGameSceneByState()
    {
        switch (currentState)
        {
            case State.Ready:
                StartCoroutine(StartStage());
                currentState = State.Play;
                break;

            case State.Play:
                break;

            case State.Reward:
                _reward.StartReward();
                break;
            case State.Wait:
                break;
            default:
                break;
        }
    }

    IEnumerator StartStage()
    {
        currentTime = 0;
        _stageController.StartStage();
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > timeForWeek)
            {
                _stageController.StopStage();
                break;
            }
            yield return null;
        }
        currentState = State.Reward;
        yield return null;
    }
}
