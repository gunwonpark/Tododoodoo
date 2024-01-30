using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RankingUI : MonoBehaviour
{
    private RankingSystem rankingList;
    private List<Vector2> position = new List<Vector2>();
    int intervalNum;
    float interval;
    [SerializeField] int maxStage = 10;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] SpriteRenderer rankingSprite;
    void Start()
    {
        rankingList = GameManager.Instance._rankingSystem;
        //rankingList.ResetRanking();
        //rankingList.AddPlayerScore("너", 1);
        //rankingList.AddPlayerScore("너", 2);
        //rankingList.AddPlayerScore("너", 3);
        //rankingList.AddPlayerScore("너", 4);
        //rankingList.AddPlayerScore("너", 5);
        //rankingList.AddPlayerScore("너", 6);
        //rankingList.AddPlayerScore("너", 7);
        //rankingList.AddPlayerScore("너", 8);
        //rankingList.AddPlayerScore("너", 9);

        intervalNum = maxStage - 1;
        interval = endPos.position.y - startPos.position.y;
        interval /= intervalNum;
        
        for(int i = 0; i < 8; i++)
        {
            position.Add(new Vector2(startPos.position.x + 0.5f * i, startPos.position.y));
        }
     
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        List<int> playerScores = rankingList.GetRankingScore();
        for (int i = 0; i < 8; i++)
        {
            Instantiate(rankingSprite, new Vector3(position[i].x, position[i].y + playerScores[i] * interval), Quaternion.identity);
        }
    }
}
