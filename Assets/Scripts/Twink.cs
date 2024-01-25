using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Twink : MonoBehaviour
{
    float fadeTime = 0.1f;
    SpriteRenderer _spRender;
    void OnEnable()
    {
        _spRender = GetComponent<SpriteRenderer>();
        StartCoroutine("StartTwinkLine");
    }
    IEnumerator StartTwinkLine()
    {
        while (true)
        {
            yield return StartCoroutine(TwinkLine(0, 1));
            yield return StartCoroutine(TwinkLine(1, 0));
        }
    }

    IEnumerator TwinkLine(float start, float end)
    {
        float currntTime = 0;
        float percent = 0;
        while (percent < 1)
        {
            currntTime += Time.deltaTime;
            percent = currntTime / fadeTime;

            Color color = _spRender.color;
            color.a = Mathf.Lerp(start, end, percent);
            _spRender.color = color;
            yield return null;
        }
    }
}