using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    Vector3 velocity = new Vector3(3,2,0);
    Vector3 acceleration = new Vector3(0,-9.8f,0);

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;

        if(transform.position.x >= 9.41f){
            velocity.x *= -1;
        }
        if(transform.position.x <= -9.49f){
            velocity.x *= -1;
        }

        if(transform.position.y < -4.34f){
            velocity.y *= -1;
        }
    }
}
