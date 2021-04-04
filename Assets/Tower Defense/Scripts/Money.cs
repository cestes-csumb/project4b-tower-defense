using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
     public TMPro.TextMeshProUGUI currentCoins;
     int coins;
     // Start is called before the first frame update
     void Start()
     {
          coins = 100;
     }

     // Update is called once per frame
     void Update()
     {
          currentCoins.SetText("Current Money: $" + coins.ToString());
     }

     public void UpdateMoney(int coinsFromEnemy)
     {
          coins += coinsFromEnemy;
     }

     public int GetCurrentMoney() {
          return coins;
     }
}
