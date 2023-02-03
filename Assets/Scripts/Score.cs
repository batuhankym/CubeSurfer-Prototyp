using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   public static Score Instance;
   public StackController _stackController;
   public TextMeshProUGUI scoreText;


   private void Start()
   {
      _stackController.GetComponent<StackController>();
   }

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else if (Instance != this)
      {
         Destroy(gameObject);
      }
   }

   public void UpdateScore(int score)
   {
      scoreText.text = score.ToString();
      if (_stackController.isMultiply)
      {
         score *= 8;
         scoreText.text = score.ToString();
      }
   }

}
