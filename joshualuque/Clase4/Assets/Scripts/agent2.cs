using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agent2 : SbAgent
{
    public GameObject target;

    void Update()
    {
        target = GameObject.Find("Target");

        velocity += steeringBehaviours.Seek(this,target.transform);
    }

}
