using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 현재 게임 진행 상황에 대한 상태
    public enum State
    {
        Ready,
        Reward,
        Wait,
        Dead
    }
    public RankingSystem _rankingSystem = new RankingSystem();
    [SerializeField] public Transform Player;
    [SerializeField] private StageController _stageController;
    [SerializeField] private Reward _reward;
    [SerializeField] private UIEffectManager _effectManager;
    [SerializeField] private GaugeController _gaugeController;
    // stage 클리어까지 필요한 시간
    [SerializeField] private float timeForWeek;

    // 현재 내가 버틴 시간
    private float currentTime = 0;

    public bool isReady;
    public bool isPlaying;

    public State currentState;

    public int stageCount;
    [SerializeField] Text StageCountTxt;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Wait;
        stageCount = 1;
        AudioManager.Instance.PlayBgm("Main");
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
                currentState = State.Wait;
                break;
            case State.Wait:
                break;
            case State.Reward:
                _reward.StartReward();
                break;
            case State.Dead:
                _stageController.StopStage();
                _stageController.ResetCur();
                StopAllCoroutines();
                _reward.ClearStats();
                stageCount = 1;
                Instance.currentState = State.Wait;
                break;
        }
    }

    IEnumerator StartStage()
    {
        currentTime = 0;
        int timeCount = 3;
        _effectManager.SetActiveText(0f, true);

        // 스테이지 시작 카운트 표시
        while(timeCount >= 0)
        {
            if(timeCount == 0)
            {
                _effectManager.SetText("Start");
                _effectManager.SetActiveText(.5f, false);
                break;
            }
            _effectManager.SetTextFadeInOut(timeCount.ToString(), 1f);
            timeCount--;
            yield return new WaitForSeconds(1f);
        }

        // 스테이지 시작
        Player.gameObject.SetActive(true);
        _stageController.StartStage(stageCount);
        _gaugeController.InitPlayerIcon();
        while (true)
        {
            currentTime += Time.deltaTime;
            _gaugeController.UpdatePlayerIcon(timeForWeek, currentTime);
            if (currentTime > timeForWeek)
            {
                _stageController.StopStage();
                Time.timeScale = 0f;
                stageCount++;
                StageCountTxt.text = stageCount.ToString();
                break;
            }
            yield return null;
        }
        currentState = State.Reward;
        yield return null;
    }
}
