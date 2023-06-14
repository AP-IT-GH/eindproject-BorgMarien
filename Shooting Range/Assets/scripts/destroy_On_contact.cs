using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_On_contact : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject bullet;
   public AI_shooter_manager aI_Shooter_Manager;

   void OnCollisionEnter(Collision other)
   {
    bullet.active=false;
    aI_Shooter_Manager.AddReward(-0.5f);
   }
}
