using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower9001 : MonoBehaviour
{
     public GameObject Tower;
     public GameObject World;
     public Money currentMoney;
     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
          if (Input.GetMouseButtonDown(0))
          {
               Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
               RaycastHit hit;
               if (Physics.Raycast(ray, out hit))
                    if (hit.transform.tag == "TowerSpot")
                    {
                         //Book keeping
                         //towers cost 200 currently
                         if (currentMoney.GetCurrentMoney() - 200 >= 0)
                         {
                              // if good 
                              hit.transform.gameObject.SetActive(false);
                              PlaceTower(hit.transform.position);
                              currentMoney.UpdateMoney(-200);
                         }
                         else
                         {
                              Debug.Log("Not enough cash!");
                         }
                    }
                    else
                         print("I'm looking at nothing!");

          }

          //raycast
          //hitplace
          //purse script $$$$
          //instantiate a tower

     }

     void PlaceTower(Vector3 position)
     {
          //Book keeping
          Instantiate(Tower, position, Quaternion.identity, World.transform);
     }
}
