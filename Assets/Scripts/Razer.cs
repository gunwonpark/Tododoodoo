using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Razer : MonoBehaviour
{
    [SerializeField] Transform _warning;
    [SerializeField] Transform _lazer;
    [SerializeField] Collider2D _coll;

    [SerializeField] float layTime;
    [SerializeField] float warningTime;    

    private int warningCount;

    private readonly int    WARNING     = 4;
    private readonly float  RAY_DEALY   = 0.5f;

    public void SetupLazer(float appearPosX)
    {
        transform.position = new Vector3(appearPosX, 5, 0);

        StartCoroutine(Warning(1, 0));
    }

    private IEnumerator Warning(float start, float end)
    {
        _warning.gameObject.SetActive(true);
        SpriteRenderer warningRenderer = _warning.GetComponent<SpriteRenderer>();
        Debug.Log(warningCount);

        float currntTime = 0;
        float percent = 0;
        while (percent < 1)
        {
            currntTime += Time.deltaTime;
            percent = currntTime / warningTime;

            Color color = warningRenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            warningRenderer.color = color;
            yield return null;
        }

        if (warningCount == WARNING)
        {
            warningCount = 0;
            _warning.gameObject.SetActive(false);

            yield return new WaitForSeconds(RAY_DEALY);

            StartCoroutine(LazerAppear());
        }
        else
        {
            warningCount++;
            StartCoroutine(Warning(end, start));            
        }            
    }

    private IEnumerator LazerAppear()
    {
        AudioManager.Instance.PlaySound("Laser");

        _lazer.gameObject.SetActive(true);        

        float current = 0;
        float percent = 0;

        Vector3 startScale = new Vector3(0, 10, 0);
        Vector3 endScale = new Vector3(0.5f, 10, 0);

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / layTime;

            _lazer.localScale = Vector3.Lerp(startScale, endScale, percent);

            yield return null;
        }

        _coll.enabled = true;

        yield return new WaitForSeconds(0.5f);

        _coll.enabled = false;

        StartCoroutine(LazerDisappear());
    }

    private IEnumerator LazerDisappear()
    {
        float current = 0;
        float percent = 0;

        Vector3 startScale = new Vector3(0.5f, 10, 0);
        Vector3 endScale = new Vector3(0, 10, 0);

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / layTime;

            _lazer.localScale = Vector3.Lerp(startScale, endScale, percent);

            yield return null;
        }
        _lazer.localScale = Vector3.zero;

        _lazer.gameObject.SetActive(false);        
    }
}
