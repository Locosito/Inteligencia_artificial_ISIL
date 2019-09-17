using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SbAgent : MonoBehaviour
{
 public Vector3 velocity = Vector3.zero;
 Vector3 desired ;
 Vector3 steer ;

 public float maxSpeed = 1f;
 public float maxSteer = 1f;
}
