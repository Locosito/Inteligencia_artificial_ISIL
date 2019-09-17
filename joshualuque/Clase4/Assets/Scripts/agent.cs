using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agent : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 desired = Vector3.zero;
    Vector3 steer = Vector3.zero;
    float maxSpeed = 5;
    float maxSteer = 15;

    Transform target;

    void Update()
    {
        target = GameObject.Find("Target").transform;

        // desired
        desired = -(target.position - transform.position).normalized * maxSpeed;
        //steer
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
        //velocity
        velocity += steer * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}

/*
    float tx = 0;
    float ty = 0;

    Update

    tx += 0.01f;
    ty += 0.01f;

    float x = -5 + 10 * Mathf.PerlinNoise(tx,0);
    float y = -5 + 10 * Mathf.PerlinNoise(0,ty);
    transform.position = new Vector(x,y,0);


 */