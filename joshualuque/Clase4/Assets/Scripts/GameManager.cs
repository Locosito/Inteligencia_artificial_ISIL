using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> agents = new List<GameObject>();
    int N = 10;

    void Start()
    {
        for(int i = 0; i < N; i++){
            GameObject agent = Resources.Load<GameObject>("Agent");
            agent.transform.position = new Vector3(Random.Range(-5,5),Random.Range(-5,5),0);
            Instantiate(agent);
        }
    }

    void Update()
    {
        
    }
}
