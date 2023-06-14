using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Target : MonoBehaviour
{
    public Rigidbody Target;
    private Vector3 orig_position;
    private Quaternion orig_rotation;
    public float speed;
    public float Max_left;
    public float Max_right;
    public bool right;
    public UI_manager Ui_manager;
    // Start is called before the first frame update
    void Start()
    {
        orig_position= Target.transform.position;
        orig_rotation= Target.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Ui_manager.timer_started){
            Vector3 CurrentPositionVector = Target.position;
                    if(right){
                        
                    
                    if(CurrentPositionVector.x > Max_right){
                    
                    
                        Target.position += new Vector3(-speed * Time.deltaTime,0,0);
                    }else{
                        right=false;
                    }
                    }else{
                        if(CurrentPositionVector.x < Max_left){
                        Target.position += new Vector3(speed * Time.deltaTime,0,0);
                        }else{
                            right=true;
                        }
                    }
        }else{
           Reset();
        }
     

    }

     public void Reset(){
 Target.transform.position= orig_position;
            Target.transform.rotation= orig_rotation;
    }
}
