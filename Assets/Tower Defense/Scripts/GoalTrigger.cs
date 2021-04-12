using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
     private int triggerCount;
     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }

     void OnTriggerEnter(Collider collider)
     {
          if (collider.name.Contains("Big")) {
               triggerCount++;
               //Debug.Log(triggerCount);
          }
          if (collider.name.Contains("Small")){
               triggerCount++;
               //Debug.Log(triggerCount);
          }

     }

     public int getTriggerCount()
     {
          return triggerCount;
     }


}
