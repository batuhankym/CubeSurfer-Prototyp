using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using DG.Tweening;
using Unity.Mathematics;

public class StackController : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    private int _currentAmountForWowWfx;
    private int _maxAmountForWowWfx = 4;
    
    
    public Animator victoryAnim;
    public PointTower pointTower;
    private bool _isCubeCount4 = false;
    [SerializeField] private GameObject wowVFX;
    public PlayerForwardMovement playerForwardMovement;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _stackSound;
    [SerializeField] private AudioClip _pointSound;
    public bool isMultiply = false;

    public List<GameObject> _lastCube = new List<GameObject>();
    public GameObject lastCube;
    public GameObject parentObject;
    [SerializeField] private GameObject pointImg;
    private int maxScore;
    public int amountScore;
    [SerializeField] private Transform[] Scores;
    [SerializeField] private GameObject amountMultipler;
    private int scoreIndex;
    public PlayerSwerveMovement _playerSwerveMovement;
    
    private void Start()
    {

        _playerSwerveMovement.GetComponent<PlayerSwerveMovement>();
        playerForwardMovement.GetComponent<PlayerForwardMovement>();
        _audioSource = GetComponent<AudioSource>();
        pointTower.GetComponent<PointTower>();
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

            _currentAmountForWowWfx += 1;
            if (_currentAmountForWowWfx >= _maxAmountForWowWfx)
            {
                Instantiate(wowVFX, transform.position, quaternion.identity);
                _currentAmountForWowWfx = 0;
            }

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
            amountScore++;
            Score.Instance.UpdateScore(amountScore);
            other.transform.DOMove(pointImg.transform.position, 60f);
            Destroy(other.gameObject,1f);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            amountMultipler.SetActive(true);
            playerForwardMovement.playerForwardSpeed = 0;
            victoryAnim.SetTrigger("victory");
            _uiManager.winCondition.SetActive(true);
            _uiManager.winCondition.transform.DOScale(1.3f, 2).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
            playerForwardMovement.GetComponent<PlayerForwardMovement>().enabled = false;
            _playerSwerveMovement.GetComponent<PlayerSwerveMovement>().enabled = false;



        }

        if (other.gameObject.CompareTag("Tower"))
        {
            isMultiply = true;
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

    public void ShrinkParentYPositionForTower()
    {
        parentObject.transform.DOMoveY(parentObject.transform.position.y - 0.2f, 0f);

    }
    
    
}
