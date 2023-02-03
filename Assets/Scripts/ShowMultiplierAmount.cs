using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Unity.Mathematics;

public class ShowMultiplierAmount : MonoBehaviour
{
    
    [SerializeField] private Transform confettiVFX1;
    [SerializeField] private Transform player;
    [SerializeField] private Transform finishLine;
    [SerializeField] private GameObject confettiVFX;
    private Camera mainCam;
    public CinemachineVirtualCamera vcam;
    void Start()
    {
        vcam.GetComponent<CinemachineVirtualCamera>();
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        Instantiate(confettiVFX, confettiVFX1.transform.position, quaternion.identity);
        Instantiate(confettiVFX, finishLine.transform.position, quaternion.identity);
        transform.DOMoveY(1.5f, 0.5f);
       transform.position = new Vector3(player.transform.position.x +0.5f, 6, player.transform.position.z);
       transform.DOMoveY(3, 0.5f);
       //Invoke("InActive",0.5f);
    }

    private void InActive()
    {
        //gameObject.SetActive(false);
    }
    void Update()
    {
        transform.LookAt(transform.position + mainCam.transform.forward);
        mainCam.transform.RotateAround(player.position , Vector3.up ,20 *Time.deltaTime);
        vcam.transform.RotateAround(player.position,Vector3.up, 45 * Time.deltaTime);
        vcam.Follow = null;

    }
}
