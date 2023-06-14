using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_wall : MonoBehaviour
{
    public UI_manager Ui_manager;
    public List<Rigidbody> targets;
    public bool LeftWall;
    public float Timer;
    public float flip_chance;

    // Start is called before the first frame update
    void Start()
    {
     
            Flip();
            //repeat
            InvokeRepeating("Flip", Timer,Timer);
      
    }

    // Update is called once per frame
    void Update()
    {
           //start 
        
    }

    void Flip(){
        //50/50 voor flip 
          if(Ui_manager.timer_started){
        System.Random rnd = new System.Random();
        foreach (var target in targets)
        {
              
            int chance =rnd.Next(0,100);
            if(chance < flip_chance){
                
                    //flip
                  
                    if(LeftWall){
                        if(target.transform.rotation.x < -0.7){
                            
                            target.transform.Rotate(90f,0.0f,0.0f);
                        }
                    }else{
                         if(target.transform.rotation.x > 0.7){
                            target.transform.Rotate(90f,0.0f,0.0f);
                        }
                    }
                
            }
            else{
           
               
                    if(LeftWall){
                        if(target.transform.rotation.x > -0.7){
                        
                            target.transform.Rotate(-90,0.0f,0f);
                        }
                    }else{
                         if(target.transform.rotation.x < 0.7){
                            target.transform.Rotate(-90f,0.0f,0.0f);
                        }
                    }
                
            }
        }
          }else{
            reset();
        }

    }

    void reset(){
        foreach (var target in targets)
        {    
            if(LeftWall){
                if(target.transform.rotation.x > -0.7){         
                    target.transform.Rotate(-90,0.0f,0f);
                }
            }else{
                if(target.transform.rotation.x < 0.7){
                    target.transform.Rotate(-90f,0.0f,0.0f);
                }
            }
                
            
        }
    }


}
