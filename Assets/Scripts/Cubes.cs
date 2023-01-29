using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cubes : MonoBehaviour
{
    private StackController _stackController;

    private void Start()
    {
        _stackController = FindObjectOfType<StackController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.tag = "Untagged";
            _stackController.ShrinkParentYPosition();
            _stackController.RemoveLastCube();
            transform.parent = null;
        }
    }
}
