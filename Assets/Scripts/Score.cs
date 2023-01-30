using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   public static Score Instance;
   
   public TextMeshProUGUI scoreText;

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
   }

}
