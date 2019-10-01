# Vectores

## Cheap Sheet



### Mouse Follow

```C#
using UnityEngine;

public class Npc : MonoBehaviour {
	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.Scale(new Vector3(1, 1, 0));
		transform.position = mousePosition;
	}
}
```



### Físicas

```C#
using UnityEngine;

public class Cube : MonoBehaviour {
	Vector3 velocity = new Vector3(0, 0, 0);
	Vector3 acceleration = new Vector3(0, 0, 0);

	void Update () {
		
		// ...código

		velocity += acceleration;
		transform.position += velocity;
	}
}
```

