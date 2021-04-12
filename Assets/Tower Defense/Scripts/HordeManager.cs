using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class HordeManager : MonoBehaviour
{

     public Wave enemyWave;
     public Path enemyPath;
     public Path bigPath;
     public Money moneyManager;
     public AudioSource speaker;
     public int enemyCount;
     private bool checkForEnd;
     private bool showButton;
     public Button button;
     public GoalTrigger goal;

     IEnumerator Start()
     {
          enemyCount = 0;
          //Debug.Log("before spawn small");
          StartCoroutine("SpawnSmallEnemies");
          StartCoroutine("SpawnBigEnemies");
          button.gameObject.SetActive(false);
          yield break;

     }

     //pick our enemy to spawn
     //spawn it
     //wait
     IEnumerator SpawnSmallEnemies()
     {
          for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
          {

               for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfSmall; j++)
               {
                    Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].smallMichaelEnemy).GetComponent<Enemy>();
                    enemyCount++;
                    spawnedEnemy.route = enemyPath;
                    spawnedEnemy.money = moneyManager;
                    spawnedEnemy.speaker = speaker;
                    spawnedEnemy.manager = this;
                    yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenSmallEnemies);

               }

               yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave); // cooldown between groups
          }
          checkForEnd = true;
          //Debug.Log("done with small");

     }

     IEnumerator SpawnBigEnemies()
     {
          //Debug.Log("big bad");
          for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
          {

               for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfLarge; j++)
               {
                    Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].bigAwesomeSuperBadGuyClayEnemy).GetComponent<Enemy>();
                    enemyCount++;
                    spawnedEnemy.route = bigPath;
                    spawnedEnemy.money = moneyManager;
                    spawnedEnemy.speaker = speaker;
                    spawnedEnemy.manager = this;
                    yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenLargeEnemies);

               }

               yield return new WaitForSeconds(enemyWave.coolDownBetweenLargeWave); // cooldown between groups
          }
     }

     private void Update()
     {
          if (enemyCount == 0 && checkForEnd == true) {
               RestartGame();
          }
          if (goal.getTriggerCount() >= 5) {
               RestartGame();
          }
     }

     private void RestartGame() {
          checkForEnd = false;
          button.gameObject.SetActive(true);
     }

     public bool GetShowButton() {
          return showButton;
     }
}



[Serializable]
public struct Group
{
     public GameObject smallMichaelEnemy;
     public GameObject bigAwesomeSuperBadGuyClayEnemy;
     public int numberOfSmall;
     public int numberOfLarge;
     public float coolDownBetweenSmallEnemies;
     public float coolDownBetweenLargeEnemies;
}

[Serializable]
public struct Wave
{
     public Group[] groupsOfEnemiesInWave;
     public float coolDownBetweenSmallWave;
     public float coolDownBetweenLargeWave;
}

