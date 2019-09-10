using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circulo : MonoBehaviour
{

    float radius1 = 1;
    float radius2 = 15;

    GameObject agent2;
    Transform agent;

    void Start()
    {
        agent = GameObject.Find("agent").transform;
        agent2 = GameObject.Find("agent").gameObject;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 distancia = agent.position - transform.position;
        float sqrLen = distancia.sqrMagnitude;

        if(sqrLen <= 2){
            Destroy(agent2);
            print("ganaste");
        }
        else if(sqrLen > 200){
            Destroy(agent2);
            print("perdiste");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius1);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius2);
    }
}
