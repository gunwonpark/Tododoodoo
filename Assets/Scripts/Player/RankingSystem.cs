using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RankingSystem
{
    private List<PlayerScoreData> _playerRankings = new List<PlayerScoreData>();
    private string _filePath = "./ScoreData.json";
    public RankingSystem()
    {
        LoadRankings();
    }
    public void AddPlayerScore(string name, int score)
    {
        _playerRankings.Add(new PlayerScoreData(name, score));
        SortRankings();
        SaveRankings();
    }

    private void SortRankings()
    {
        _playerRankings = _playerRankings.OrderByDescending(player => player.score).ToList();
    }

    private void SaveRankings()
    {
        // JSON 형태로 변환하여 PlayerPrefs에 저장
        string jsonData = JsonUtility.ToJson(new Serialization<PlayerScoreData>(_playerRankings));
        System.IO.File.WriteAllText(_filePath, jsonData);
    }

    public void LoadRankings()
    {
        if (!System.IO.File.Exists(_filePath))
        {
            System.IO.File.WriteAllText(_filePath, "");
        }

        string jsonData = System.IO.File.ReadAllText(_filePath);
        if (!string.IsNullOrEmpty(jsonData))
        {
            _playerRankings = JsonUtility.FromJson<Serialization<PlayerScoreData>>(jsonData).ToList();
            SortRankings();
        }
    }
    public string GetRankingLIst(int max = 10)
    {
        int showNumber = 1;
        string rankingList = "";
        foreach (PlayerScoreData player in _playerRankings)
        {
            rankingList += $"No. {showNumber} {player.playerName} {player.score} \n\n";
            // Debug.Log($"{showNumber}. {player.playerName} {player.score}");
            if (showNumber == max) return rankingList;
            showNumber++;
        }

        return rankingList;
    }

    public void ResetRanking()
    {
        _playerRankings.Clear();
        SaveRankings();
    }
}


[System.Serializable]
public class Serialization<T>
{
    [SerializeField]
    private List<T> _data;
    public List<T> ToList() { return _data; }
    public Serialization(List<T> data) { this._data = data; }
}
