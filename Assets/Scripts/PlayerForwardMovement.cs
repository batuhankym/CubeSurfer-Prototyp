using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public Animator playerAnim;

    
    
    [SerializeField] private float playerForwardSpeed;

    private void Start()
    {
        playerAnim.GetComponent<Animator>();
    }

    void Update()
    {

        transform.Translate(Vector3.forward * (playerForwardSpeed * Time.deltaTime));

        if (playerForwardSpeed > 0)
        {
            playerAnim.SetTrigger("run");
        }
    }
}
