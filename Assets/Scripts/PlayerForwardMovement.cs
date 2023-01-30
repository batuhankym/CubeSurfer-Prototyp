using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public Animator playerAnim;

    
    
    public float playerForwardSpeed;

    private void Start()
    {
        playerForwardSpeed = 0;
        playerAnim.GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            playerForwardSpeed = 3;
        }
        transform.Translate(Vector3.forward * (playerForwardSpeed * Time.deltaTime));

        if (playerForwardSpeed > 0)
        {
            playerAnim.SetTrigger("run");
        }
        else
        {
            playerAnim.SetTrigger("idle");
        }
    }
}
