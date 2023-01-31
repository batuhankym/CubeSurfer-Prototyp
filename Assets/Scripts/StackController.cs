using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public PlayerForwardMovement playerForwardMovement;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _stackSound;
    [SerializeField] private AudioClip _pointSound;

    public List<GameObject> _lastCube = new List<GameObject>();
    public GameObject lastCube;
    public GameObject parentObject;
    [SerializeField] private GameObject pointImg;
    [SerializeField] private int amountScore = 1;
    [SerializeField] private Transform[] Scores;
    private int scoreIndex;
    
    private void Start()
    {
        playerForwardMovement.GetComponent<PlayerForwardMovement>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        lastCube = _lastCube[_lastCube.Count - 1];
        if (_lastCube.Count <= 1)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            parentObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            _audioSource.PlayOneShot(_stackSound,1f);
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

        if (other.gameObject.CompareTag("Point"))
        {
            _audioSource.PlayOneShot(_pointSound,1f);
            Score.Instance.UpdateScore(amountScore);
            amountScore++;
            other.transform.DOMove(pointImg.transform.position, 60f);
            Destroy(other.gameObject,1f);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            playerForwardMovement.playerForwardSpeed = 0;
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
