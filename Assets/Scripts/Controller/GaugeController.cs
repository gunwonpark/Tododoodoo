using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private Transform goalPos;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform playerIcon;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = goalPos.position.y - startPos.position.y;
    }

    public void InitPlayerIcon()
    {
        playerIcon.position = startPos.position;
    }

    public void UpdatePlayerIcon(float maxTime, float currentTime)
    {
        playerIcon.position = startPos.position + new Vector3(0, distance * (currentTime / maxTime), 0);
    }
}
