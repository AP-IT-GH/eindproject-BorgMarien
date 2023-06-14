using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_floor : MonoBehaviour
{ 
    public UI_manager Ui_manager;
    public List<Rigidbody> targets; //4 targets 
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
    void Flip(){
        if(Ui_manager.timer_started){
            System.Random rnd = new System.Random();
            foreach (var target in targets)
            {
                        
                int chance =rnd.Next(0,100);
                if(chance < flip_chance){
                    if(target.transform.rotation.x ==0){
                       
                        target.transform.Rotate(90f,0.0f,0.0f);
                    }
                    }else{
                        if(target.transform.rotation.x<0){
                            
                                target.transform.Rotate(-90f,0.0f,0.0f);
                        }
                   }
            }
        }else{
            reset();
        }
        //50/50 voor flip 
       

    }

        void reset(){
        foreach (var target in targets)
        {    
            if(target.transform.rotation.x<0){
                
                    target.transform.Rotate(-90f,0.0f,0.0f);
                }
                
            
        }
    }
}
