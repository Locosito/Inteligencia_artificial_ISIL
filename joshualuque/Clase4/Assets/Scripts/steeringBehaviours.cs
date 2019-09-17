using UnityEngine;

public class steeringBehaviours 
{
    static public Vector3 Seek(SbAgent agent,Transform target){
        Vector3 desired = (target.position - agent.transform.position).normalized * agent.maxSpeed;
         Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
         agent.velocity += steer * Time.deltaTime;
         agent.transform.position += agent. velocity * Time.deltaTime;

         return steer;
    }

    static public Vector3 flee(SbAgent agent,Transform target){
        Vector3 desired = -(target.position - agent.transform.position).normalized * agent.maxSpeed;
         Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
         agent.velocity += steer * Time.deltaTime;
         agent.transform.position += agent. velocity * Time.deltaTime;

         return steer;
    }

    static public Vector3 arrive(SbAgent agent,Transform target, float range){
        Vector3 desired;

        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;

        if(distance > range){
            desired = difference.normalized * agent.maxSpeed;
        }
        else{
            desired = difference.normalized * agent.maxSpeed * distance / range;
        }
       
         Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
         agent.velocity += steer * Time.deltaTime;
         agent.transform.position += agent. velocity * Time.deltaTime;

         return steer;
    }
}
