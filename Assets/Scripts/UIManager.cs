using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public GameObject touchButton, slideImg;


    void Start()
    {
        touchButton.transform.DOMoveX(400f, 1f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            slideImg.SetActive(false);
        }
    }
}
