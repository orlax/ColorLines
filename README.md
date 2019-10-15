# ColorLines
Un juego pequeño sobre llevar un laser de un punto a otro usando espejos. 

Este juego fue hecho como una prueba tecnica para una convocatoria de trabajo, la prueba consistia en replicar el juego de reflektor 

Video del gameplay en YouTube: https://www.youtube.com/watch?v=NbcqSdnDKwc 

En su estado actual el juego tiene 12 niveles jugables y ha replicado las siguientes mecanicas del juego original: 

- laser que es emitido y sigue las propiedades de la luz, usando raycasting. 
- espejos reflectores que pueden ser usados por el jugador para dirigir el laser. 
- un receptor que recibe el laser y cumple con la condicion para ganar del juego. 
- elementos que tienen que ser destruidos con el laser como una condicion extra para ganar el juego. 
- bloques que bloquean el curso del laser. 
- bloques que reflejan el laser como espejos. 
- reflectores que rotan de forma automatica. 
- elementos que no pueden ser destruidos y que inician un estado de sobrecarga cuando son golpeados por el laser. 
- un sistema de sobrecarga que causa una condicion de final del juego. 
- un sistema de energia que puede causar una condicion de final de juego. 
- puntos de "fibra optica" que transportan el laser de un punto a otro siguiendo la direccion de entrada. 


mecanicas del deflektor original que no fueron replicadas:

- los bugs que avanzan de forma aleatoria en el espacio y causan cambios en los reflectors. 
- distintas clases de prismas que cambian la direccion del laser de forma secuencial o aleatoria. 

Con mas tiempo para desarrollar este juego, una lista de cosas por hacer seria: 

- resolver bugs en casos de eje que provocan a el laser a quedarse "pegado" en ciertos objetos, aveces causando una sobrecarga mas rapido de lo normal. 
- agregar mas y mejores niveles. 
- agregar un material animado para el laser. 
- implementar los distintos tipos de prismas. 
- agregar una pantalla de seleccion de nivel. 
- agregar una trancision animada entre un nivel y otro, usando "streaming" para mover la camara al siguiente nivel sin necesidad de recargar la escena. 
- mejorar el diseño visual y sonoro (sobre todo el sonoro). 

