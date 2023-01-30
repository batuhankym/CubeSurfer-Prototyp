using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public List<GameObject> _lastCube = new List<GameObject>();
    public GameObject lastCube;
    public GameObject parentObject;
    [SerializeField] private Transform[] Scores;
    private int scoreIndex;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        lastCube = _lastCube[_lastCube.Count - 1];

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Scores[scoreIndex].gameObject.SetActive(true);
            Scores[scoreIndex].transform.position = transform.position;


            if (scoreIndex < 4)
            {
                scoreIndex++;

            }
            else
            {
                scoreIndex = 0;
            }
            
            other.gameObject.tag = "Untagged";
            other.gameObject.transform.SetParent(transform);
            _lastCube.Add(other.gameObject);

            parentObject.transform.DOMoveY(parentObject.transform.position.y + 0.4f, 1f);
            var newCubePos = other.transform.localPosition = new Vector3(transform.localPosition.x, lastCube.transform.localPosition.y - 2, transform.localPosition.z);
            other.transform.DOLocalJump(newCubePos, 1, 1, 0.5f);

        }
    }

    public void RemoveLastCube()
    {
        _lastCube.RemoveAt(_lastCube.Count-1);
        lastCube.transform.parent = null;


    }

    public void ShrinkParentYPosition()
    {
        parentObject.transform.DOMoveY(parentObject.transform.position.y - 1.2f, 0.5f);

    }
    
    
}
