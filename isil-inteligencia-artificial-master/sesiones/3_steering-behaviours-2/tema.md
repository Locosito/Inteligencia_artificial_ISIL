# Steering Behaviours - 2

## Arrive & Mezcla de comportamientos

### Arrive

Ocurre cuando el agente sigue a un objetivo (**target**). Pero una vez cerca del objetivo, el agente debe empezar a desacelerar para acercarse cada vez más lentamente al target. Esta cercanía la definiremos con un valor $range$, que será la distancia desde donde el desaceleramiento debería empezar. La fórmula del vector deseado sería la siguiente:
$$
desired = norm(targetPosition - position)*maxSpeed
$$
Si la distancia entre el target y el agente es mayor que R, y
$$
desired = norm(targetPosition - position)*maxSpeed*\frac{distance}{range}
$$

Si la distancia entre el target y el agente es menor o igual a R.



### Actualización de la clase SB

Ahora, solo tenemos que agregar nuestro método **Arrive** a la clase **SB** que estamos construyendo.

```C#
using UnityEngine;

class SB {
    // ...
    
    static public Vector3 Arrive(SBAgent agent, Vector3 targetPosition, float range)
    {
        Vector3 difference = targetPosition - agent.transform.position;
        Vector3 distance = difference.magnitude;
        
        // cálculo del steer similar al Seek
        Vector3 desired = difference.normalized * agent.maxSpeed;
        
        // pero si está dentro del rando, se aplica el ajuste correspondiente
        if (distance <= range) desired *= distance / range;
        
        // la forma de calcular el steer es siempre la misma
        Vector3 steer = 
           Vector3.ClampMagnitude(desired - velocity, maxSteer);
        
        return steer;
    }
    
   // ...
}
```



### Mezcla de comportamientos

Cuando estemos programando un juego, lo más probable es que un agente no siempre deba seguir un único objetivo. Es decir podría seguir a un elemento mientras huye de otro, por lo que estaría siendo afectado por dos fuerzas steer (un *Seek* y un *Flee*) a la vez.

Esto lo podemos resolver simplemente acumulando los steers a medida que los necesitamos. Aquí un ejemplo:

```C#
using UnityEngine;

class Npc : SBAgent
{
	Vector3 targetToSeek;
	Vector3 targetToFlee;
	
    void Start()
    {
    	// para este ejemplo, supongamos que tenemos en el escenario
    	// a dos elementos llamados: TargetToSeek y TargetToFlee
    	targetToSeek = GameObject.Find("TargetToSeek").transform.position;
    	targetToFlee = GameObject.Find("TargetToFlee").transform.position;
    }
    
    void Update()
    {
    	// se inicializa el steer en (0, 0, 0)
    	Vector3 steer = Vector3.zero;
    	
    	// se van acumulando los steers necesarios
    	steer += SB.Seek(this, targetToSeek);
    	steer += SB.Flee(this, targetToFlee);
    	
    	// se recalculan la posición y la velocidad
    	velocity += steer * Time.deltaTime;
    	transform.position += velocity * Time.deltaTime;
    }
}
```

De esta manera iremos acumulando, en un mismo agente, los diversos steering behaviours que implementemos.