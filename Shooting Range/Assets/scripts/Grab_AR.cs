using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_AR : MonoBehaviour
{
    public bool is_reloading=false;
    public float Max_amo = 30;
public float reload_time;
    public float current_amo=30;
    public bool is_grabbed= false;
    public Rigidbody AR;
    private Vector3 orig_position;

       public AudioSource reload_sound_start;
      public AudioSource reload_sound_end;
          public AudioSource Grab_gun_sound;
    private Quaternion orig_rotation;
    // Start is called before the first frame update
    void Start()
    {
        orig_position= AR.transform.position;
        orig_rotation = AR.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grab_gun(){
     
        this.is_grabbed=true;
        current_amo=Max_amo;
        Grab_gun_sound.Play();
     
    }

    public void drop_gun(){
        
        this.is_grabbed=false;
    }

    public void Move_gun(){
        AR.transform.position = orig_position;
        AR.transform.rotation= orig_rotation;
    }

    public bool is_currently_grabbed(){
        return is_grabbed;
    }

     public void Remove_bullet_when_shot(){
        current_amo --;
    }

    public void reload(){
        is_reloading=true;
        reload_sound_start.Play();
        StartCoroutine(Reloading());
       
    }

    IEnumerator Reloading(){
        yield return new WaitForSeconds(reload_time);
        current_amo=Max_amo;
        reload_sound_end.Play();
        is_reloading=false;
    }

  

    public bool Has_amo_left(){
        if(current_amo>0){
            return true;
        }

        return false;
    }


}
