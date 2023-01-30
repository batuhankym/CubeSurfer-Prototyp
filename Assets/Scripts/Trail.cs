using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Trail : MonoBehaviour
{
    public StackController _stackController;


    void Start()
    {
        _stackController.GetComponent<StackController>();
    }

    void Update()
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, _stackController.lastCube.transform.position, 7f * Time.deltaTime);
        transform.forward = _stackController.lastCube.transform.position - transform.position;
    }
}