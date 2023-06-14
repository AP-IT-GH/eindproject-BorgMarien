using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InputManager : MonoBehaviour
{
    public GameObject bullet;
    public GameObject pistol;
    public GameObject AR;
    
    private Grab_pistol pistol_grab_handler;
    private Grab_AR AR_grab_handler;
    
    float timer = 4f;
    bool start= false;
    public float shootrate = 20f;
    public float shot_speed;

    public float shootrate_AR;

    public float shot_speed_ar;

    public UI_manager Ui_manager;
    public Moving_Target moving_target_manager;

    public AudioSource Pistol_shot_sound;
    public AudioSource Ar_shot_sound;
  
    
    // Start is called before the first frame update
    void Start()
    {
       pistol_grab_handler = pistol.GetComponent<Grab_pistol>();
       AR_grab_handler = AR.GetComponent<Grab_AR>();
    }

   

     

    // Update is called once per frame
    void Update()
    {
        //controller setup
       var LeftHandControllers = new List<UnityEngine.XR.InputDevice>(); 
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand,LeftHandControllers);

         //controller setup
       var RightHandControllers = new List<UnityEngine.XR.InputDevice>(); 
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand,RightHandControllers);
        

       
      

        // right trigger buttons press
        bool pressed;
       if(RightHandControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton,out pressed) && pressed){
        if(Ui_manager.timer_started){
             //if pistol
            if( pistol_grab_handler.is_currently_grabbed() && timer >=shootrate){
               
                //shoot
                if(pistol_grab_handler.Has_amo_left()){
                    //bullet
                    GameObject newProjectile = Instantiate(bullet, transform.position+(5*transform.forward),transform.rotation);
                    newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward* shot_speed,ForceMode.VelocityChange);
                    //-1 amo
                    pistol_grab_handler.Remove_bullet_when_shot();
                    //sound
                    Pistol_shot_sound.Play();
                    //firerate
                    start=true;
                    timer=0f;
                }
             
            }

            if(start){

                if(timer < shootrate){
                    timer +=Time.deltaTime;
                }else{
                    timer= shootrate;
                    start=false;
                }
            }
            //if ar 
            else if(AR_grab_handler.is_currently_grabbed() && timer >=shootrate_AR){
                if(AR_grab_handler.Has_amo_left()){
                    //bullet
                    GameObject newProjectile = Instantiate(bullet, transform.position+(20*transform.forward),transform.rotation);
                    newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward* shot_speed_ar ,ForceMode.VelocityChange);
                    //-1 amo
                    AR_grab_handler.Remove_bullet_when_shot();
                    //sound 
                    Ar_shot_sound.Play();
                    //firerate
                    start=true;
                    timer=0f;
                }

            if(start){

                if(timer < shootrate_AR){
                    timer += Time.deltaTime;
                }else{
                    timer= shootrate;
                    start=false;
                }
            }
       }
        }
           
    }

        // lift trigger buttons press
        bool L_pressed;
       if(LeftHandControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton,out L_pressed) && L_pressed){
            //if pistol
            if( pistol_grab_handler.is_currently_grabbed()){
               if(pistol_grab_handler.Has_amo_left()==false){
                    pistol_grab_handler.reload();
               }
            }
            //if ar 
            else if(AR_grab_handler.is_currently_grabbed()){
                if(AR_grab_handler.Has_amo_left()==false){
                    AR_grab_handler.reload();
               }
            }
         }     

         if(LeftHandControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton,out L_pressed) && L_pressed){
            //start timer 
            Ui_manager.start_timer();
            //reset targets 
            moving_target_manager.Reset();
            //reset score
            Ui_manager.Score=0;
            Ui_manager.AI_score=0;
         }     

       

 
    }
    }
