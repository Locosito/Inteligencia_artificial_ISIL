# Vectores

Para efectos del curso, vamos a considerar a un vector como una colección de 3 valores: $(x y, z)$, que pueden denotar una posición, una velocidad o una aceleración.

Estos vectores se pueden operar de diversas maneras para ayudarnos a resolver distintos problemas dentro del desarrollo de un videojuego.



## Operaciones

### Suma

Si se tiene $A = (a_x, a_y, a_z)$ y $B = (b_x, b_y, b_z)$, se define su suma como:


$$
A + B = (a_x + b_x, a_y + b_y, a_z + b_z)
$$

### Resta

Si se tiene $A = (a_x, a_y, a_z)$ y $B = (b_x, b_y, b_z)$, se define su suma como:


$$
A - B = (a_x - b_x, a_y - b_y, a_z - b_z)
$$

### Producto escalar

Si se tiene $A = (a_x, a_y, a_z)$ y un valor $k \in \R$, se define el producto escalar de $A$ y $k$ como:


$$
kA = (ka_x, ka_y, ka_z)
$$

### Magnitud

Si se tiene $A = (a_x, a_y, a_z)$, podemos calcular su magnitud mediante la siguiente fórmula:


$$
|A| = \sqrt{a_x^2 + a_y^2 + a_z^2}
$$

### Distancia

Si se tiene dos vectores  $A = (a_x, a_y, a_z)$ y $B = (b_x, b_y, b_z)$, se define la distancia entre ambos como la magnitud de su diferencia:
$$
|\vec{AB}| = | A - B | \\
|\vec{AB}| = |(a_x - b_x, a_y - b_y, a_z - b_z)|\\
|\vec{AB}| = \sqrt{(a_x - b_x)^2 + (a_y - b_y)^2 + (a_z - b_z)^2}
$$

### Normalización

Si se tiene un vector A, se define al vector normal de $A$ como el vector unitario que comparte su misma dirección, y se calcula dividiendo al vector entre su magnitud:
$$
\hat{A} = \frac{A}{|A|}
$$

### Truncamiento

Si se tiene $A = (a_x, a_y, a_z)$, y deseamos truncar su magnitud a un valor dado $m$, seguiríamos la siguiente fórmula:
$$
trunc(A, m) = A, |A| < m, \\
trunc(A, m) = m\hat{A}, |A| \geq m
$$
Si la magnitud de $A$ es menor a $m$, no se hace nada; y si se supera este límite, calculamos la normal de $A$ y multiplicamos el resultado por $m$.