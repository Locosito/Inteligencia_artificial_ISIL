using UnityEngine;

public class Agent : SBAgent
{
	public Transform target;
	public Transform target2;


	void Start()
	{
		maxSpeed = 10f;
		maxSteer = 1f;

		target2 = GameObject.Find("Target2").transform;
	}

	void Update()
	{
		velocity += SteeringBehaviours.Arrive(this, target, 3f);
		velocity += SteeringBehaviours.Flee(this, target2, 5f);
		velocity += SteeringBehaviours.Separate(this, GameManager.agents, 0.5f);
		transform.position += velocity * Time.deltaTime;
	}
}
