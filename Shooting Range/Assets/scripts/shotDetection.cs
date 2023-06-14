using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotDetection : MonoBehaviour
{
    public GameObject Target;
    public  UI_manager Ui_Manager;
    public AudioSource Target_hit_sound;
    public AudioSource Special_target_hit_sound;
   private void OnTriggerEnter(Collider other){
    //player shot 
        if(other.gameObject.tag == "bullet"){
            //add points 
            if(Target.tag=="Special_target"){
                this.Ui_Manager.Special_target_hit();
                Special_target_hit_sound.Play();
            }else{
                Ui_Manager.add_point();
                Target_hit_sound.Play();
                other.gameObject.active=false;
            }
            //flip target 
            if(Target.tag =="left_target"){
                Target.transform.parent.Rotate(-90f,0.0f,0.0f);
            }else{
                
                Target.transform.parent.Rotate(-90f,0.0f,0.0f);
            }
        }
    //ai shot 
    if(other.gameObject.tag == "AI_bullet"){
            //add points 
            if(Target.tag=="Special_target"){
                this.Ui_Manager.Special_target_hit_AI();
                Special_target_hit_sound.Play();
            }else{
                Ui_Manager.add_point_AI();
                Target_hit_sound.Play();
                other.gameObject.active=false;
                
            }
            //flip target 
            if(Target.tag =="left_target"){
                Target.transform.parent.Rotate(-90f,0.0f,0.0f);
            }else{
                
                Target.transform.parent.Rotate(-90f,0.0f,0.0f);
            }
        }
   }
}
