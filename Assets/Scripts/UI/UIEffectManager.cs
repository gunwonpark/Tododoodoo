using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEffectManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countTimeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextFadeInOut(string count, float time)
    {
        countTimeText.text = count;

        countTimeText.DOFade(1, time / 2).OnComplete(() =>
        {
            countTimeText.DOFade(0, time / 2);
        });
    }

    public void SetText(string text)
    {
        countTimeText.alpha = 1;
        countTimeText.text = text;
    }

    public void SetActiveText(float time, bool active)
    {
        StartCoroutine(ChangeActiveState(countTimeText.gameObject, time, active));
    }

    IEnumerator ChangeActiveState(GameObject obj, float time, bool active)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(active);
    }
}
