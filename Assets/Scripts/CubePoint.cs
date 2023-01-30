using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CubePoint : MonoBehaviour
{
    private Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        transform.DOScale(1.5f, 0.5f);
        Invoke("InActive",0.5f);
    }

    private void InActive()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.LookAt(transform.position + mainCam.transform.forward);
    }

  
}
