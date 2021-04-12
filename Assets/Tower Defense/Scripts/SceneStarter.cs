using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneStarter : MonoBehaviour
{
     float startTimer;
     bool readyTimer;
     public Button startButton;
     // Start is called before the first frame update
     void Start()
     {
          startTimer = 2.5f;
          readyTimer = false;
     }

     // Update is called once per frame
     void Update()
     {
          startButton.onClick.AddListener(SetTimer);
          if (readyTimer == true)
          {
               startTimer -= Time.deltaTime;
          }
          if (startTimer <= 0.0f)
          {
               SceneManager.LoadScene("TowerDefense");
          }
     }

     void SetTimer()
     {
          readyTimer = true;
     }
}
