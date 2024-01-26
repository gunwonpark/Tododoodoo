using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunUiUpdqte : MonoBehaviour
{
    [SerializeField] Transform EndUi;
    [SerializeField] Transform RunUi;
    Vector3 startPos;
    Vector3 distance;
    float percentage;
    private void Start()
    {
        startPos = RunUi.transform.position;
        distance = EndUi.position - startPos;
    }
    void GetPercentage(float timeForWeek, float currentTime)
    {
        percentage = currentTime / timeForWeek;
        MoveRunUi();
    }
    void MoveRunUi()
    {
        RunUi.position = new Vector3(startPos.x + (distance.x * percentage), startPos.y + (distance.y * percentage), startPos.z + (distance.z * percentage));
    }
}
