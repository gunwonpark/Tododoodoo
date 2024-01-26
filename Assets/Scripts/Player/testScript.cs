using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    private Image _image;
    private void Start()
    {
        _image = GetComponent<Image>();
    }
    public void IncreaseGage()
    {
        _image.fillAmount += 0.11f;
    }
}
