using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScoreData
{
    public string playerName;
    public int score;

    public PlayerScoreData(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}
