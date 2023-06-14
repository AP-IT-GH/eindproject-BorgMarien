using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum weapons{ Handgun,Ar};
public class UI_manager : MonoBehaviour
{
    public float Timer=60;
    public float Score;
    public float AI_score;

   public bool timer_started=false;

    public weapons Weapon;
    public AI_shooter_manager ai_manager;

    public Text Timer_ui;
    public Text Amo_ui;
    public Text Score_ui;
    public Text AI_score_ui;
    public Text Start_ui;

    public Grab_pistol pistol_manager;
    public Grab_AR ar_manager;
    public AudioSource End_sound;
    public AudioSource Start_sound;

    public GameObject Player_fireworks;
    public GameObject Ai_fireworks;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer_ui.text = Math.Floor(Timer) +" s remaining";
        Score_ui.text ="Your Score: " + Score;
        AI_score_ui.text ="Score AI: " + AI_score;

        if(pistol_manager.is_currently_grabbed()){
            if(pistol_manager.is_reloading){
                Amo_ui.text = "Reloading";
            }else{  
                Amo_ui.text = pistol_manager.current_amo +"/"+pistol_manager.Max_amo;
            }
        }else if(ar_manager.is_currently_grabbed()){
            if(ar_manager.is_reloading){
                Amo_ui.text = "Reloading";
            }else{
                Amo_ui.text = ar_manager.current_amo +"/"+ar_manager.Max_amo;
            }
           
        }else{
            Amo_ui.text="grab a gun";
        }

 
        if(timer_started){
            if(Timer >1){
                Timer -= Time.fixedDeltaTime;
                Start_ui.text="";
            }else{
                
                timer_started= false;
                Start_ui.text="Press x to play";
                End_sound.Play();
                ai_manager.start=false;

                //check winner 
                if(Score > AI_score){
                    //you won 
                    Player_fireworks.active=true;
                }else if(Score < AI_score){
                    //ai wins 
                    Ai_fireworks.active=true;
                }else{
                    //draw
                    Player_fireworks.active=true;
                    Ai_fireworks.active=true;
                }
            }
        }
    }

    public void add_point(){
        this.Score++;
    }
    public void Special_target_hit(){
        this.Score = this.Score*2;
    }

     public void add_point_AI(){
        this.AI_score++;
        this.ai_manager.AddReward(1f);
    }
    public void Special_target_hit_AI(){
        this.AI_score = this.AI_score*2;
    }

    public void start_timer(){
        Ai_fireworks.active=false;
        Player_fireworks.active=false;
        Start_sound.Play();
      
        StartCoroutine(reset_timer());
        //start ai 
        ai_manager.start=true;
       
    }

    IEnumerator reset_timer(){
        yield return new WaitForSeconds(4);
        Timer=60;
        timer_started=true;
    }


}

