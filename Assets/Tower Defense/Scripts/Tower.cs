using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
     public List<Enemy> currentEnemies;
     public Enemy currentTarget;
     public Transform turret;
     private delegate void enemySubscription(Enemy enemy);

     private LineRenderer laser;
     private float healthPerTower;
     public float hitAmount = 10;
     public float hp;
     public Transform healthbar;

     void Start()
     {
          //laser = GetComponent<LineRenderer>();
          //laser.positionCount = 2;
          //laser.SetPosition(0, turret.transform.position);
          healthPerTower = 200f / hp;
     }

     void Update()
     {
          if (currentTarget)
          {

               currentTarget.Damage(hitAmount * Time.deltaTime);
               //laser.SetPosition(1, currentTarget.transform.position);
          }
          if (currentEnemies.Count > 0) {
               for (int i = 0; i < currentEnemies.Count; i++) {
                    if (currentEnemies[i] != null) {
                         if (currentEnemies[i].name.Contains("Big")) {
                              Damage(5 * Time.deltaTime);
                         }
                         if (currentEnemies[i].name.Contains("Small")) {
                              Damage(2.5f * Time.deltaTime);
                         }
                    }
               }
          }
     }


     void OnTriggerEnter(Collider collider)
     {
          if (collider.GetComponent<Enemy>() != null)
          {
               Enemy newEnemy = collider.GetComponent<Enemy>();
               newEnemy.DeathEvent.AddListener(delegate { BookKeeping(newEnemy); });
               currentEnemies.Add(newEnemy);
               if (currentTarget == null) currentTarget = newEnemy;
          }
     }

     void OnTriggerExit(Collider collider)
     {
          if (collider.GetComponent<Enemy>() != null)
          {
               Enemy oldEnemy = collider.GetComponent<Enemy>();
               BookKeeping(oldEnemy);
          }
     }

     void BookKeeping(Enemy enemy)
     {
          currentEnemies.Remove(enemy);
          currentTarget = (currentEnemies.Count > 0) ? currentEnemies[0] : null;

     }

     void Damage(float amount) {
          hp -= amount;
          if (hp <= 0) {
               //Debug.Log("Tower destroyed");
               Destroy(gameObject);
          }
          float percentage = healthPerTower * hp;
          Vector3 newHealthAmount = new Vector3(percentage / 200f, healthbar.localScale.y, healthbar.localScale.z);
          healthbar.localScale = newHealthAmount;
     }
}
