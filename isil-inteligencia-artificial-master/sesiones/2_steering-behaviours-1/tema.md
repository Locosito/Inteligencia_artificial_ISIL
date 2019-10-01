# Steering Behaviours - 1

## Definición

Los Steering Behaviours son algoritmos que se basan en la idea de que un NPC se mueve siguiendo objetivos específicos y que cada objetivo puede ser convertido en un vector al cual seguir en cada instante de tiempo.

Se manejarán los siguientes términos:

- **Agente**

  Así llamaremos a cualquier entidad a la que le estemos aplicando un algoritmo de steering behaviours.

- **Velocidad máxima (maxSpeed)**

  Es un número que nos indica la **velocidad natural** de nuestro agente. El agente puede acelerar o desacelerar, pero nunca sobrepasará este valor máximo.

- **Vector deseado (desired)**

  Es el vector que nos indica el objetivo en sí, y es hacia donde nuestro agente **debería** estar moviéndose. Este vector es el que calcularemos de manera distinta en cada algoritmo, pues es el único necesario para definir el movimiento.

- **Cambio máximo (maxSteer)**

  Es un número que nos indica el **nivel máximo de cambio** que podremos aplicar al vector velocidad para asemejarse al vector deseado. Si este valor es alto, el cambio será más inteligente.

- **Vector de cambio (steer)**

  Este vector se define como el cambio que debería tener el vector velocidad para **asemejarse** al vector deseado.

  
  $$
  steer= clamp(desired - velocity, maxSteer)
  $$



Para plasmar todo esto en código, vamos a crear la siguiente clase:

```C#
using UnityEngine;

class SBAgent : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 desired = Vector3.zero;
    Vector3 steer = Vector3.zero;
    float maxSpeed = 1.0f;
    float maxSteer = 1.0f
}
```

De modo que si nuestro **NPC** hereda de la clase **SBAgent**, ya podríamos manipular las propiedades de un agente y aplicar los algoritmos de steering behaviours de una manera más cómoda.

```C#
using UnityEngine;

class Npc : SBAgent
{
    void Start()
    {
    	velocity = new Vector3(1, 1, 0); // se define cualquier velocidad inicial
        maxSpeed = 0.5f; // velocidad
        maxSteer = 0.3f; // inteligencia o capacidad de reacción
    }
    
    void Update()
    {
    	// cálculo del vector deseado
    	// el cual cambia en cada algoritmo
    	// desired = ...
    	
    	steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
    	velocity += steer * Time.deltaTime;
    	transform.position += velocity * Time.deltaTime;
    }
}
```



## Seek y Flee

Existen muchos algoritmos de este tipo, de los cuales nosotros veremos los siguientes:

### Seek

Ocurre cuando el agente sigue a un objetivo (**target**). Y la fórmula del vector deseado sería la siguiente:
$$
desired = norm(targetPosition - position)*maxSpeed
$$


### Flee

Similar a Seek, pero en lugar de seguir al target, huye de él. Es por ello que simplemente invertimos la dirección:
$$
desired = norm(position - targetPosition)*maxSpeed
$$


## Clase SB

Para utilizar estos algoritmos con mayor legibilidad y comodidad, crearemos una clase estática **SB** (Steering Behaviours), la cual contendrá cada uno de los algoritmos de este tipo que vayamos implementando.

```C#
using UnityEngine;

class SB {
    static public Vector3 Seek(SBAgent agent, Vector3 targetPosition)
    {
        // calcula el deseado
        Vector3 desired = 
            (targetPosition - agent.transform.position).normalized * agent.maxSpeed;
       
        // la forma de calcular el steer es siempre la misma
        Vector3 steer = 
           Vector3.ClampMagnitude(desired - velocity, maxSteer);
        
        return steer;
    }
    
    static public Vector3 Flee(SBAgent agent, Vector3 targetPosition)
    {
        // calcula el deseado
        Vector3 desired = 
            (agent.transform.position - targetPosition).normalized * agent.maxSpeed;
       
        // la forma de calcular el steer es siempre la misma
        Vector3 steer = 
           Vector3.ClampMagnitude(desired - velocity, maxSteer);
        
        return steer;
    }
}
```

Cada algoritmo devolverá una fuerza **steer**, la cual aplicaremos a nuestra velocidad. Y dado que los vectores ***desired*** y ***steer*** ahora lo estamos utilizado de manera interna en nuestra clase **SB**, podríamos remover ambas propiedades de la clase **SBAgent**, la cual quedaría como sigue:

```C#
using UnityEngine;

class SBAgent : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    float maxSpeed = 1.0f;
    float maxSteer = 1.0f
}
```

Permitiéndonos manipular así, la velocidad del agente (**maxSpeed**) y su capacidad de reacción (**maxSteer**).