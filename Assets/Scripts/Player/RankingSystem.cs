using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RankingSystem
{
    private List<PlayerScoreData> _playerRankings = new List<PlayerScoreData>();

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
        PlayerPrefs.SetString("PlayerRankings", jsonData);
        PlayerPrefs.Save();
    }

    public void LoadRankings()
    {
        // PlayerPrefs에서 로드
        string jsonData = PlayerPrefs.GetString("PlayerRankings", "");
        if (!string.IsNullOrEmpty(jsonData))
        {
            _playerRankings = JsonUtility.FromJson<Serialization<PlayerScoreData>>(jsonData).ToList();
            SortRankings();
        }
    }
    public void ShowScores()
    {
        foreach (PlayerScoreData player in _playerRankings)
        {
            Debug.Log($"{player.playerName}: {player.score}"); // 콘솔에 표시
        }
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
