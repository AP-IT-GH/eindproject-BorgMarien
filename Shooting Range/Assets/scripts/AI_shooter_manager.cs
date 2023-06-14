using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class AI_shooter_manager : Agent
{
    public GameObject bullet;
    public float shot_speed;
    public GameObject gun;

    public bool start = false;
    public List<GameObject> gun_positions;

    private Vector3 orig_position;
    private Quaternion orig_rotation;


    private float times_shot = 0;
    void reset_position()
    {
        gun.transform.position = orig_position;
        gun.transform.rotation = orig_rotation;
    }

    void shoot()
    {
        GameObject newProjectile = Instantiate(bullet, transform.position + (5 * transform.right), transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.right * shot_speed, ForceMode.VelocityChange);
        times_shot++;


    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetButton("a") ? 1.0f : 0.0f;
        continuousActionsOut[1] = Input.GetButton("z") ? 1.0f : 0.0f;
        continuousActionsOut[2] = Input.GetButton("e") ? 1.0f : 0.0f;
        continuousActionsOut[3] = Input.GetButton("r") ? 1.0f : 0.0f;
        continuousActionsOut[4] = Input.GetButton("t") ? 1.0f : 0.0f;
        continuousActionsOut[5] = Input.GetButton("y") ? 1.0f : 0.0f;
        continuousActionsOut[6] = Input.GetButton("u") ? 1.0f : 0.0f;
        continuousActionsOut[7] = Input.GetButton("i") ? 1.0f : 0.0f;
        continuousActionsOut[8] = Input.GetButton("o") ? 1.0f : 0.0f;
        continuousActionsOut[9] = Input.GetButton("p") ? 1.0f : 0.0f;
        continuousActionsOut[10] = Input.GetButton("q") ? 1.0f : 0.0f;
        continuousActionsOut[11] = Input.GetButton("s") ? 1.0f : 0.0f;
        continuousActionsOut[12] = Input.GetButton("d") ? 1.0f : 0.0f;
        continuousActionsOut[13] = Input.GetButton("f") ? 1.0f : 0.0f;
        if (start)
        {
            //move gun to target positions 
            //a
            if (continuousActionsOut[0] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[0].transform.position;
                gun.transform.rotation = gun_positions[0].transform.rotation;

                shoot();
            }

            //z
            else if (continuousActionsOut[1] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[1].transform.position;
                gun.transform.rotation = gun_positions[1].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[2] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[2].transform.position;
                gun.transform.rotation = gun_positions[2].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[3] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[3].transform.position;
                gun.transform.rotation = gun_positions[3].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[4] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[4].transform.position;
                gun.transform.rotation = gun_positions[4].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[5] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[5].transform.position;
                gun.transform.rotation = gun_positions[5].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[6] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[6].transform.position;
                gun.transform.rotation = gun_positions[6].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[7] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[7].transform.position;
                gun.transform.rotation = gun_positions[7].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[8] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[8].transform.position;
                gun.transform.rotation = gun_positions[8].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[9] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[9].transform.position;
                gun.transform.rotation = gun_positions[9].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[10] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[10].transform.position;
                gun.transform.rotation = gun_positions[10].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[11] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[11].transform.position;
                gun.transform.rotation = gun_positions[11].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[12] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[12].transform.position;
                gun.transform.rotation = gun_positions[12].transform.rotation;
                shoot();
            }
            else if (continuousActionsOut[13] == 1F)
            {
                reset_position();
                gun.transform.position = gun_positions[13].transform.position;
                gun.transform.rotation = gun_positions[13].transform.rotation;
                shoot();
            }

        }

    }



    public override void OnEpisodeBegin()
    {
        times_shot = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actionbuffers)
    {

        if (start)
        {
            Debug.Log(actionbuffers.ContinuousActions[0]);
            //if a press 
            if (actionbuffers.ContinuousActions[0] == 1f)
            {
                //change position to a 
                reset_position();
                gun.transform.position = gun_positions[0].transform.position;
                gun.transform.rotation = gun_positions[0].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[1] == 1f)
            {
                //change position to z
                reset_position();
                gun.transform.position = gun_positions[1].transform.position;
                gun.transform.rotation = gun_positions[1].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[2] == 1f)
            {
                //change position to e
                reset_position();
                gun.transform.position = gun_positions[2].transform.position;
                gun.transform.rotation = gun_positions[2].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[3] == 1f)
            {
                //change position to r
                reset_position();
                gun.transform.position = gun_positions[3].transform.position;
                gun.transform.rotation = gun_positions[3].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[4] == 1f)
            {
                //change position to t
                reset_position();
                gun.transform.position = gun_positions[4].transform.position;
                gun.transform.rotation = gun_positions[4].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[5] == 1f)
            {
                //change position to y
                reset_position();
                gun.transform.position = gun_positions[5].transform.position;
                gun.transform.rotation = gun_positions[5].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[6] == 1f)
            {
                //change position to u
                reset_position();
                gun.transform.position = gun_positions[6].transform.position;
                gun.transform.rotation = gun_positions[6].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[7] == 1f)
            {
                //change position to i
                reset_position();
                gun.transform.position = gun_positions[7].transform.position;
                gun.transform.rotation = gun_positions[7].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[8] == 1f)
            {
                //change position to o
                reset_position();
                gun.transform.position = gun_positions[8].transform.position;
                gun.transform.rotation = gun_positions[8].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[9] == 1f)
            {
                //change position to p
                reset_position();
                gun.transform.position = gun_positions[9].transform.position;
                gun.transform.rotation = gun_positions[9].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[10] == 1f)
            {
                //change position to q
                reset_position();
                gun.transform.position = gun_positions[10].transform.position;
                gun.transform.rotation = gun_positions[10].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[11] == 1f)
            {
                //change position to s
                reset_position();
                gun.transform.position = gun_positions[11].transform.position;
                gun.transform.rotation = gun_positions[11].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[12] == 1f)
            {
                //change position to d
                reset_position();
                gun.transform.position = gun_positions[12].transform.position;
                gun.transform.rotation = gun_positions[12].transform.rotation;
                shoot();
            }
            else if (actionbuffers.ContinuousActions[13] == 1f)
            {
                //change position to f
                reset_position();
                gun.transform.position = gun_positions[13].transform.position;
                gun.transform.rotation = gun_positions[13].transform.rotation;
                shoot();
            }

            //max 10 tries before end episode 
            if (times_shot > 10)
            {
                EndEpisode();
            }
        }
    }



    public void set_reward(float reward)
    {
        AddReward(reward);
    }

    private void Start()
    {
        orig_position = gun.transform.position;
        orig_rotation = gun.transform.rotation;
        times_shot = 0;
    }

}
