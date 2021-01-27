#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h> 
typedef struct {
	char nombre [20];
	int socket;
	pthread_t thread;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;

typedef struct {
	char nombre[20];
	char palabra[20];
}Ganador;


typedef struct {
	Conectado jugadores[4];
	int puntuaciones[4];
	Ganador ganadores[4];
	char palabra[20];
	int contadoraciertos;
	int contadorerrores;
	int contadorganadores;
	int ronda;
	int num;
} Partida;


Partida misPartidas[100];  //tabla de partidas
//cuenta el numero de jugadores de cada partida que adivinan las palabras


void init(ListaConectados *lista) {
	int i;
	for (i=0; i<100; i++) {
		strcpy (lista->conectados[i].nombre, "");
		lista->conectados[i].socket = 0;
	}
}

void init2(Partida partidas[100]) {
	//inicializa la lista de partidas
	int i;
	for (i=0; i<100; i++) {
		partidas[i].num=0;			
	}
}

int Pon (ListaConectados *lista, char nombre[20], int socket) {
	//A??ade nuevo conectados. Retorna 0 si ok y -1 si la lista 
	//ya estaba llena y no lo ha podido a??adir y -2 si ya hay otro usuario
	//conectado con el mismo nombre
	if (lista->num == 100)
		return -1;
	else {
		int encontrado = 0;
		int i=0;
		while ((i < lista->num) && (!encontrado))
		{
			if (lista->conectados[i].socket==socket)
				encontrado = 1;
			i++;
		}
		if (encontrado){
			return -2;
		}
		else
		{
			//a??ade el conectado al final de la lista
			strcpy (lista->conectados[lista->num].nombre, nombre);  
			lista->conectados[lista->num].socket = socket;
			lista->num++;
			return 0;
		}
	}	
}
int PonNombre (ListaConectados *lista, int socket, char nombre[20]) {
	// Pone el nombre al conectado de la lista de conectados 
	// que tiene el socket que le paso como parametro.
	// Devuelve 0 si ha asignado el nombre al conectado que tiene el soket que le paso como parametro
	// Devuelve -1 si no ha encontrado el socket del conectado
	// Devuelve -2 si ha encontrado el socket del conectado pero ya tiene nombre
	int encontrado = 0;
	int i=0;
	while ((i < lista->num) && (!encontrado))
	{
		if (lista->conectados[i].socket==socket)
			encontrado = 1;
		if (!encontrado)
			i++;
	}
	int f = DamePosicion (lista, nombre); //Guardo la posicion de la lista de conectados que tiene dicho nombre o -1 en su defecto
	if ((encontrado) && (f==-1)){
		strcpy (lista->conectados[i].nombre, nombre);
		return 0;
	}
	else if ((!encontrado) && (f==-1)) 
		return -1;
	else 
		return -2;
}

int DameSocket (ListaConectados *lista, char nombre[20]) {
	//Devuelve el socket del conectado que tiene el nombre que le paso como parametro
	// o -1 si no est?? en la lista
	int i=0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
		
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else
		return -1;
}

int DamePosicion (ListaConectados *lista, char nombre[20]) {
	//Devuelve la posicion del conectado que tiene el nombre que le paso como parametro
	// o -1 si no est?? en la lista
	int i=0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
		
	}
	if (encontrado)
		return i;
	else
		return -1;
}

int DameNombre (ListaConectados *lista, int socket, char nombre[20]) {
	// Devuelve la posicion y el nombre del conectado que tiene el socket que le pasamos como par??metro
	// o -1 si no est?? en la lista 
	int i=0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado)
	{
		if (lista->conectados[i].socket == socket)
			encontrado =1;
		if (!encontrado)
			i=i+1;
		
	}
	if (encontrado) {
		strcpy(nombre, lista->conectados[i].nombre);
		return i;
	}	
	else {
		return -1;
		strcpy(nombre, "Nombre no encontrado.");
	}
}

int Eliminar (ListaConectados *lista, char nombre[20]) {
	//Retorna 0 si elimina y -1 si ese usuario no est?? en la lista.
	int pos = DamePosicion (lista, nombre);
	if (pos == -1)
		return -1;
	else {
		int i;
		/*		if (pos==0)*/
		/*		{*/
		/*			strcpy (lista->conectados[pos].nombre, lista->conectados[pos+1].nombre);*/
		/*			lista->conectados[pos].socket = lista->conectados[pos+1].socket ;*/
		/*		}*/
		/*		else {*/
		for (i=pos; i < lista->num-1; i++)
		{
			//lista->conectados[i] = lista->conectados[i+1];
			strcpy (lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			lista->conectados[i].socket = lista->conectados[i+1].socket;
		}
		/*		}*/
		lista->num--;
		return 0;
		printf("%s %d\n",lista->conectados[0].nombre, lista->conectados[0].socket);
		
	}
}

void DameConectados (ListaConectados *lista, char conectados[100]) {
	//Pone en conectados los nombres de todos los conectados separados
	//por /. Primero pone el n??mero de conectados. Ejemplo: 
	//"3/Juan/Maria/Pedro"
	sprintf (conectados,"%d", lista->num);
	int i;
	for (i=0; i < lista->num; i++)
		sprintf (conectados, "%s/%s", conectados, lista->conectados[i].nombre);
}
////////////////////////////////////////////////////////////////////////////////
int crearPartida(Partida partidas[100], char nombre [20], int socket)
{
	//Crea nueva partida con el nombre del jugador que invita (anfitrion). La nueva partida se colocar?? en la primera
	//posici??n libre de la tabla partidas.
	//Retorna el id de la partida si ok y -1 si la tabla partidas est?? llena.
	int i=0;
	int encontrado=0;
	while ((i < 100) && (!encontrado))
	{
		if (partidas[i].num==0)
			encontrado=1;
		if (!encontrado) 
			i++;
	}
	if (encontrado) {
		strcpy(partidas[i].jugadores[partidas[i].num].nombre,nombre);
		partidas[i].jugadores[partidas[i].num].socket=socket;
		partidas[i].num++;
		return i;
	}
	else {
		return -1;
	}
}
void EliminarPartida (Partida partidas[100], int id) {
	//Vacia la partida con el id que le pasamos por parametro.
	partidas[id].num=0;
}

int PonPartida(Partida partidas[100], char nombre [20], int socket, int id) {
	//A??ade al invitado a la partida con el id que pasamos por par??metro.
	//Si esa partida contiene 4 jugadores no a??adir?? al invitado y retornar?? -1,
	//En otro caso, lo a??adir?? y retornar?? 0.
	if (partidas[id].num==4) {
		return -1;
	}
	else {
		strcpy(partidas[id].jugadores[partidas[id].num].nombre,nombre);
		partidas[id].jugadores[partidas[id].num].socket=socket;
		partidas[id].num++;
		return 0;
	}
}


int DamePartidas (Partida partidas[100], char nombre [20], char PartidasActivas[100]) {
	//Me da una lista con las partidas en las que se encuentra el usuario presente
	//separados por / y comenzando por el numero de partidas. Ex: 2/1/2
	//Si no hay ninguna me devuelve -1, sino 0.	
	
	char solution[100];
	strcpy(solution,"");
	int i=0;
	int cont=0;
	//Busca en la lista de partidas si hay alguna partida en la que este jugando
	//el jugador cuyo nombre le pasamos como parametro
	while (i < 100)
	{
		int j=0;
		while (j<partidas[i].num) {
			if (strcmp(partidas[i].jugadores[j].nombre,nombre)==0) { 
				if (partidas[i].num>=2)  //solo devuelve las partidas en las que hay 2 o mas jugadores
				{
					cont=cont+1;
					sprintf (solution,"%s/%d", solution, i);
				}
			}
			j++;
		}	
		i++;
	}
	
	if (cont==0) {
		return -1;
	}
	else {		
		sprintf (PartidasActivas,"%d%s",cont,solution);
		printf("Nombre: %s, Partidas activas: %s\n",nombre, PartidasActivas);
		return 0;
	}
}

void DameNombresJugadores (Partida partidas[100], int id, char noms[100]) {
	//Me da una lista de "n?Jugs/Nombre1/Personaje1/Nombre2/Personaje2...NombreN/PersonajeN/"
	//De los jugadores que jueguen una determinada partida.
	char solution[100];
	int j=0;
	strcpy(solution,"");
	sprintf (solution,"%s%d/", solution, partidas[id].num);
	while (j<partidas[id].num) {
		sprintf (solution,"%s%s/", solution, partidas[id].jugadores[j].nombre);
		j++;
	}
	strcpy (noms, solution);
}

int EstaEnPalabra(Partida partidas[100], char letra[1], int id){
	//Retorna -1 si la letra no est??? en la palabra o 0 si la letra est??? en la palabra	
	int n=0;
	int encontrado=0;
	int veces=0;
	int longitud = strlen(partidas[id].palabra);
	while(n<longitud){
		char letracomparacion;
		if( partidas[id].palabra[n] == letra[0]){
			encontrado=1;
			veces=veces+1;
		}
		n=n+1;
	}	
	if (encontrado)
		return veces;
	else
		return -1;
}



void quicksort(int A[4], int izq, int der){
	
	int pivote=A[izq]; // tomamos primer elemento como pivote
	int i=izq;         // i realiza la b??????squeda de izquierda a derecha
	int j=der;         // j realiza la b??????squeda de derecha a izquierda
	int aux;	
	
	while(i < j){                          // mientras no se crucen las b??????squedas                                   
		while(A[i] >= pivote && i < j)
			i=i+1;		// busca elemento mayor que pivote
		while(A[j] < pivote)   
			j=j-1;			// busca elemento menor que pivote
		if (i < j) {                        // si no se han cruzado                      
			aux= A[i];                      // los intercambia
			A[i]=A[j];
			A[j]=aux;
		}
	}
	
	A[izq]=A[j];      // se coloca el pivote en su lugar de forma que tendremos                                    
	A[j]=pivote;      // los menores a su izquierda y los mayores a su derecha
	
	if(izq < j-1)
		quicksort(A,izq,j-1);          // ordenamos subarray izquierdo
	if(j+1 < der)
		quicksort(A,j+1,der);          // ordenamos subarray derecho
	
}


void printArray(int arr[4], int size) 
{ 
	int i; 
	for (i=0; i < size; i++) 
		printf("%d\n", arr[i]); 
} 



void DamePuntuacionesJugadores(Partida partidas[100], int id, char ListaPuntuaciones[100]){
	//Devuelve una lista del tipo Jugador1/PuntuacionJugador1/Jugador2/PuntuacionJugador2/....JugadorN/Puntuaci???nN
	
	strcpy(ListaPuntuaciones,"");
	int n;	
	int izq=0;
	int der=partidas[id].num;
	int A[4];
	char jugadornombre[20];
	int jugadorpuntuacion;
	
	for (n=0;n<partidas[id].num;n++){
		A[n]=partidas[id].puntuaciones[n];
		printf("Puntuacion: %d\n",A[n]);
	}
	
	quicksort(A,izq,der-1);
	printArray(A,partidas[id].num);
	int m;
	int posicionesusadas[4];//Guardo las posiciones del array de jugadores que ya he a???adido a la lista de puntuaciones7
	posicionesusadas[0]=-1;
	posicionesusadas[1]=-1;
	posicionesusadas[2]=-1;
	posicionesusadas[3]=-1;
	int contador=0;
	int encontrado=0;
	
	for(n=0;n<partidas[id].num;n++)
	{
		for(m=0;m<partidas[id].num;m++){
			if(partidas[id].puntuaciones[m]==A[n])
			{
				
				for(int t=0;t<4 && (!encontrado);t++){  //mira si esta cogida esta posicion en la lista de puntuaciones
					if(posicionesusadas[t]==m)
						encontrado=1;
				}
				
				if (!encontrado){
					posicionesusadas[contador]=m;
					contador++;
					strcpy(jugadornombre,partidas[id].jugadores[m].nombre);
					jugadorpuntuacion=partidas[id].puntuaciones[m];
					sprintf(ListaPuntuaciones,"%s%s/%d/",ListaPuntuaciones,jugadornombre,jugadorpuntuacion);	
					
				}
				encontrado=0;
				
			}
		}
		
		
	}	
	printf("Lista puntuaciones: %s\n",ListaPuntuaciones);
}

void DameGanadoresyPalabras(Partida partidas[100], int id, char ListaPalabras[100]){
	//Devuelve una lista del tipo JugadorGanador1/Palabra1/JugadorGanador2/Palabra2/....../JugadorGanadorN/PalabraN
	strcpy(ListaPalabras,"");
	int n;
	for(n=0;n<partidas[id].num;n++){
		if(strcmp(partidas[id].ganadores[n].palabra,"")!=0)
			sprintf(ListaPalabras,"%s%s/%s/",ListaPalabras,partidas[id].ganadores[n].nombre,partidas[id].ganadores[n].palabra);		
	}	
}


void SignOut (char username[20], MYSQL *conn)
{
	//Borra de la base de datos el jugador con el username que le paso como parametro
	//Devuelve 0 si lo ha borrado o -1 si no lo ha borrado
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [1000];
	strcpy(consulta,"");
	// Buscamos si hay algun jugador que tenga el mismo nombre de usuario y la misma contrase?????????a
	sprintf (consulta, "SET FOREIGN_KEY_CHECKS = 0; DELETE FROM JUGADOR WHERE JUGADOR.USERNAME = '%s'; SET FOREIGN_KEY_CHECKS = 1;", username);
	printf("%s\n",consulta);
	//Utilizamos el sprintf para poder hacer una consulta sin tener que concatenar las diferentes restricciones.
	//Buscamos que no haya ningun error al consultar los datos.
	int found;
	int err;
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error sign out al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//Recogemos el resultado de la consulta. Este nos devuelve un puntero en MYSQL_RES
	//con el cual vemos si el jugador con el username, pasword y ID, esta en la base de datos
	//o directamente no existe ese jugador. 
}
////////////////////////////////////////////////////////////////////////////////	
int registro (char username [20], char password [15], MYSQL *conn)
{
	// Devuelve 1 si el jugador ya existe en la base de datos o a??ade el jugador a la base de datos
	// y devuelve 0
	char consulta[1000];
	MYSQL_RES *resultado;
	MYSQL_RES *resultado2;
	MYSQL_ROW fila;
	MYSQL_ROW row;
	int err;
	int found;
	char IDn [100];
	int ID;
	
	sprintf (consulta, "SELECT * FROM (JUGADOR) WHERE JUGADOR.USERNAME = '%s';", username);
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de un jugador
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	
	if (row != NULL)
		found = 1;	
	
	else
	{	
		// Ahora obtenemos el identificador del jugador anterior y 
		// vamos aumentandolo a medida que se registra un usuario.
		sprintf (IDn, "SELECT MAX(JUGADOR.ID) FROM JUGADOR;");
		err = mysql_query(conn, IDn);
		resultado2 = mysql_store_result (conn);
		fila = mysql_fetch_row (resultado2);
		ID = atoi(fila[0]);
		ID=ID+1;
		// Ahora construimos el string con el comando SQL
		// para insertar el usuario con su password y su identificador en la base. 
		// Ese string es: INSERT INTO JUGADOR VALUES ('ID', 'username', password);
		sprintf (consulta, "INSERT INTO JUGADOR VALUES (%d, '%s', '%s');", ID, username, password);
		printf("consulta = %s\n", consulta);
		// Ahora ya podemos realizar la insercion 
		err = mysql_query(conn, consulta);
		found = 0;
		// Si hay alg??n problema, nos mostrar?? que hay un error la introducir los datos.
		if (err!=0) {
			printf ("Error al introducir datos la base %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}	
	}
	
	return found;  //nos dice si el jugador ya existe en el registro
	
}

int login (char username [20], char password [15], MYSQL *conn)
{
	// Devuelve 0 si se ha podido logear el jugador cuyo nombre de usuario le pasamos como parametro o -1 si no se ha podido logear
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [1000];
	// Buscamos si hay algun jugador que tenga el mismo nombre de usuario y la misma contrase??a
	sprintf (consulta, "SELECT * FROM (JUGADOR) WHERE JUGADOR.USERNAME = '%s' AND JUGADOR.PASSWD = '%s';", username, password);
	int found;
	char misConectados[300];
	int err;
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Recogemos el resultado de la consulta. Este nos devuelve un puntero en MYSQL_RES
	//con el cual vemos si el jugador con el username, pasword y ID, esta en la base de datos
	//o directamente no existe ese jugador. 
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row != NULL) 
		found = 1;
	else
		found = 0;	
	
	return found; //nos dice si el usuario ha podido conectarse a la base de datos.
}
////////////////////////////////////////////////////////////////////////////////	
void insertarinfo (char respuesta2[512], MYSQL *conn)
{
	// Devuelve 1 si el jugador ya existe en la base de datos o a??ade el jugador a la base de datos
	// y devuelve 0
	char consultasss[512];
	strcpy(consultasss, respuesta2);
	char consulta[1000];
	MYSQL_RES *resultado;
	MYSQL_RES *resultado2;
	MYSQL_ROW fila;
	MYSQL_ROW row;
	char IDn[100];
	char IDJ[100];
	int IDj;
	char username[20];
	int puntuacion;
	int ID;
	int err;
	char *p;
	char *t;
	int numerojugadores;
	int posicion=0;
	int contadorganadores;
	int palabras=0;
	int i;
	int idjugador;
	
	sprintf (consulta, "SELECT * FROM (JUGADOR) WHERE JUGADOR.USERNAME = '%s';", username);
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de un jugador
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	
	
	p = strtok(consultasss, "/");
	p = strtok(NULL,"/");
	p = strtok(NULL,"/");
	numerojugadores = atoi(p);
	p = strtok(NULL, "/");
	contadorganadores = atoi(p);
	// Ahora obtenemos el identificador del jugador anterior y 
	// vamos aumentandolo a medida que se registra un usuario.
	sprintf (IDn, "SELECT MAX(PARTIDA.ID) FROM PARTIDA;");
	err = mysql_query(conn, IDn);
	resultado2 = mysql_store_result (conn);
	fila = mysql_fetch_row (resultado2);
	ID = atoi(fila[0]);
	ID=ID+1;
	// Ahora construimos el string con el comando SQL
	// para insertar el usuario con su password y su identificador en la base. 
	// Ese string es: INSERT INTO JUGADOR VALUES ('ID', 'username', password);
	sprintf (consulta, "INSERT INTO PARTIDA VALUES (%d, %d);", ID, numerojugadores);
	printf("consulta = %s\n", consulta);
	// Ahora ya podemos realizar la insercion 
	err = mysql_query(conn, consulta);
	// Si hay alg??n problema, nos mostrar?? que hay un error la introducir los datos.
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	for (i=0; i<numerojugadores; i++)
	{
		p = strtok(NULL, "/");
		strcpy(username, p);
		sprintf (IDJ, "SELECT JUGADOR.ID FROM JUGADOR WHERE JUGADOR.USERNAME = '%s';", username);
		err = mysql_query(conn, IDJ);
		resultado2 = mysql_store_result (conn);
		fila = mysql_fetch_row (resultado2);
		IDj = atoi(fila[0]);
		p = strtok(NULL, "/");
		puntuacion = atoi(p);
		posicion ++;
		sprintf (consulta, "INSERT INTO PARTICIPACION VALUES (%d, %d, %d, %d);",IDj, ID, puntuacion, posicion);
		printf("consulta = %s\n", consulta);
		// Ahora ya podemos realizar la insercion 
		err = mysql_query(conn, consulta);
		// Si hay alg??n problema, nos mostrar?? que hay un error la introducir los datos.
		if (err!=0) {
			printf ("Error al introducir datos la base %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}		
		
	}
	
}
//Funci?n que busca el jugador que ha avidivinado la palabra 
/*int buscarGanador (char JugadoresPalabras[100], char username[20])*/
/*{*/
/*	int palabras;*/
/*	char *t = strtok(JugadoresPalabras, "/");*///nombreh/palabra/nombrel/palabra
/*	while (t != NULL){*/
/*		if (strcmp(t,username)==0)*/
/*			palabras = palabras + 1;*/
/*		t = strtok(NULL, "/");*/
/*		t = strtok(NULL, "/");*/
/*	}*/
/*	return palabras;*/
/*}*/
//Consulta1: Nos devuelve la m??xima puntuaci??n obtenida por el jugador pasado por par??metro.
void consulta1 (char nombre [20], MYSQL *conn, char respuesta [512])
{
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	sprintf(consulta, "SELECT DISTINCT PARTICIPACION.PUNTUACION FROM (JUGADOR, PARTICIPACION) WHERE PARTICIPACION.PUNTUACION =(SELECT MAX(PARTICIPACION.PUNTUACION) FROM (JUGADOR, PARTICIPACION) WHERE PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME = '%s');", nombre);
	//Utilizamos el sprintf para poder hacer una consulta sin tener que concatenar las diferentes restricciones.
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		strcpy (respuesta, "Error al consultar datos de la base");
		exit (1);
	}
	
	//Recogemos el resultado de la consulta. 
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		strcpy (respuesta, "No se han obtenido datos en la consulta");
	}
	else
	{
		sprintf(respuesta, "La mejor puntuaci??n que ha conseguido %s es de: ",  nombre);
		int cont=0;
		while (row !=NULL) 
		{
			//Si todo es correcto, el resultado de la consulta sera el siguiente:	
			if (cont!=0)
			{
				sprintf (respuesta, "%s %s", respuesta, row[0]);
			}
			else 
				sprintf (respuesta, "%s", row[0]);
			cont = cont+1;
			row = mysql_fetch_row (resultado);
		}
	}
}
//Consulta 2: Obtenemos la mejor posici??n en la que ha quedado el jugador pasado por par??metro.
void consulta2 (char username [20], MYSQL *conn, char respuesta [512])
{
	//Consulta: Usernames de los jugadores que han quedado en primer lugar en alguna de las partidas en las que
	//el jugador introducido por el usuario ha jugado y en las que el numero de participantes >= 3
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	sprintf (consulta, "SELECT DISTINCT PARTICIPACION.POSICION FROM (JUGADOR, PARTICIPACION) WHERE PARTICIPACION.POSICION = (SELECT MIN(PARTICIPACION.POSICION) FROM (JUGADOR, PARTICIPACION) WHERE PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME = '%s');", username);
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		strcpy (respuesta, "Error al consultar datos de la base");
		exit (1);
	}
	
	//Recogemos el resultado de la consulta. 
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		strcpy (respuesta, "No se han obtenido datos en la consulta");
	}
	else
	{
		sprintf(respuesta, "La mejor posici??n que ha conseguido %s es de: ", username);
		int cont=0;
		while (row !=NULL) 
		{
			//Si todo es correcto, el resultado de la consulta sera el siguiente:	
			if (cont!=0)
			{
				sprintf (respuesta, "%s %s", respuesta, row[0]);
			}
			else 
			{
				sprintf (respuesta, "%s", row[0]);
			}
			cont = cont+1;
			row = mysql_fetch_row (resultado);
		}
	}
	
	
}

//Consulta3: Nos da la cantidad de palabras m??ximas acertadas por el jugador introducido como par??metro.
void consulta3 (char nombre [20], MYSQL *conn, char respuesta [512])
{
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;	
	// construimos la consulta SQL
	sprintf(consulta, "SELECT DISTINCT PARTICIPACION.ID_P FROM (JUGADOR, PARTICIPACION) WHERE PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME = '%s';",nombre);
	err = mysql_query (conn, consulta); 
	//Buscamos que no haya ningun error al consultar los datos.
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
		strcpy (respuesta, "Error al consultar datos de la base");
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row == NULL) {
		printf ("No se han obtenido datos en la consulta\n");
		strcpy (respuesta, "Error al consultar datos en la base");
	}
	else
	{
		int cont=0;
		while (row !=NULL) 
		{
			//Si todo es correcto, el resultado de la consulta sera el siguiente:	 				
			cont = cont+1;
			row = mysql_fetch_row (resultado);
		}
		sprintf (respuesta, "La cantidad de partidas jugadas por %s es de: %d", nombre, cont);
	}		
	
}


ListaConectados miLista; //declaramos lista de conectados como variable global para que todos los thread puedan accederla
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int res;

void *AtenderCliente (void *socket)
{
	
	char peticion[512];  //mensaje que recibimos del cliente a traves del socket
	char respuesta[512]; //mensaje que se envia al cliente a trav??s del socket
	char respuesta2[512];
	char respuesta3[512];
	char resolucion [512];
	char chat[100];
	int sock_conn;
	int *t;
	t = (int *) socket;
	sock_conn= *t;
	char username[20];
	char perdedor[20];
	char password [15];
	char invitado[20];  //nombre del invit??ado
	char anfitrion[20];  //nombre del anfitrion
	int posicion;
	int puntuacion;
	int ronda;  //nos indica en que ronda estamos
	int acabada; //nos indica si la partida ha acabado
	int found; //nos indica si el jugador que quiere registrarse ya esta registrado
	int minjug;
	int minpunt;
	char f_h[200];
	int ret;
	int id;
	int SocketInvitado;
	int SocketAnfitrion;
	char jugada[100];
	char juego[100];
	// INICIALIZACIONESDB
	MYSQL *conn;
	//Creamos una conexion al servidor MYSQL.
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Se inicializa la conexion.
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T1_BBDDFIREBOYandWATERGIRL",0, NULL, 0);
	/*	conn = mysql_real_connect (conn, "localhost","root", "mysql", "T1_BBDDFIREBOYandWATERGIRL",0, NULL, 0);*/
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int terminar =0;
	//Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte.
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok(peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		//Dependiendo del valor numerico del codigo, se asociara a una consulta u otra.
		
		if (codigo ==0) //peticiOn de desconexiOn
		{
			terminar = 1;
			
			pthread_mutex_lock(&mutex);
			//Eliminamos al usuario de la lista de conectados.
			int res = Eliminar (&miLista, username);
			if (res == -1)
				printf ("No est??.\n");
			else 
				printf ("Eliminado.\n");
			pthread_mutex_unlock(&mutex);
		}
		
		else if (codigo == 1) //piden hacer un registro
		{		
			//RECIBO: 1/username/password
			//ENVIO: 1/SI o 1/NO
			p = strtok( NULL, "/");
			strcpy (username, p);
			p = strtok( NULL, "/");
			strcpy (password, p);
			found = registro(username, password, conn); //registramos al usuario
			
			if (found ==0) {
				sprintf (respuesta, "1/SI/%s",username);
			} 
			else 
				sprintf(respuesta, "1/NO/%s",username);
		}
		
		else if (codigo == 2)
		{
			// El usuario introducir?? sus datos y solo podr?? acceder si est?? 
			// registrado con esa contrase??a.
			// RECIBO: 2/username/password
			// ENVIO: 2/SI O NO/mensaje
			strcpy(respuesta,"");
			p = strtok( NULL, "/");
			strcpy (username, p);
			p = strtok( NULL, "/");
			strcpy (password, p);
			pthread_mutex_lock(&mutex);
			found = login (username, password, conn); //Nos dice si ha encontrado al usuario en la base de datos
			if (found == 0) {
				sprintf (respuesta, "2/NO/El usuario: %s, es incorrecto/", username);
				res = Eliminar (&miLista, ""); //eliminamos al conectado de  la lista de conectados
			} 
			else 
			{
				sprintf(respuesta, "2/SI");
				if (sock_conn !=-1) {
					
					int h = PonNombre(&miLista, sock_conn, username);
					if (h==0) {
						sprintf (respuesta, "%s/El usuario: %s, se ha anadido correctamente a la lista/", respuesta, username);
					}
					else if (h==-1) {
						res=Pon (&miLista, username, sock_conn); //a??adimos a la lista de conectados el conectado si lo hemos eliminado
						if(res==-1)
						{
							sprintf (respuesta, "%s/Lo sentimos %s, no se pueden a??adir m??s usuarios a la lista/", respuesta, username);
							res = Eliminar (&miLista, "");  //eliminamos al conectado de  la lista de conectados
						}
						else
						   sprintf (respuesta, "%s/El usuario: %s, se ha anadido correctamente a la lista/", respuesta, username);
					}
					else {
						sprintf (respuesta, "%s/Lo sentimos %s, el usuario ya esta en l??nea en otro dispositivo/", respuesta, username);
						res = Eliminar (&miLista, "");
					}					
				}
				else {
					sprintf (respuesta, "%s/El usuario: %s, es incorrecto/", respuesta, username);
					res = Eliminar (&miLista, "");
				}
			}
			pthread_mutex_unlock(&mutex);
		}
		
		else if (codigo == 3) //consulta1
		{
			//ENVIO: 3/respuesta
			strcpy(resolucion,"");
			p = strtok( NULL, "/");
			strcpy (username, p);
			consulta1 (username, conn, resolucion);
			sprintf (respuesta,"3/%s",resolucion); 
		}
		
		else if (codigo == 4) //consulta2
		{
			//ENVIO: 4/respuesta
			strcpy(resolucion,"");
			p = strtok( NULL, "/");
			strcpy (username, p);
			consulta2 (username, conn, resolucion);
			sprintf (respuesta,"4/%s",resolucion); 
		}
		
		else if (codigo == 5) //consulta3
		{		
			//ENVIO: 5/respuesta
			strcpy(resolucion,"");
			p = strtok( NULL, "/");
			strcpy (username, p);
			consulta3 (username, conn, resolucion);
			sprintf (respuesta,"5/%s",resolucion); 
		}
		
		else if (codigo == 7) //RECIBO: 7/Maria/Pablo
			//ENVIO: 7/ID/Juan
		{	
			strcpy (respuesta, "");
			p = strtok( NULL, "/");
			id = crearPartida(misPartidas, username, sock_conn); //crea la partida con el socket del anfitrion
			//Envio el ID de la partida y el nombre del anfitrion a todos los invitados
			//si y solo si estan conectados
			while (p!=NULL)
			{	
				strcpy (invitado, p);
				SocketInvitado=DameSocket (&miLista, invitado);  //busca el socket del invitado
				if (SocketInvitado!=-1) {
					if (id!=-1) {
						sprintf (respuesta, "7/%d/%s",id, username);
						write (SocketInvitado,respuesta, strlen(respuesta)); //Envia la invitaci??n al invitado
						printf("%s\n",respuesta);
					}
					else {
						sprintf (respuesta, "7/%d/Espera un poco... Todas las partidas est??n llenas",id);
						write (sock_conn,respuesta, strlen(respuesta));  //No envia la invitaci??n y le indica al anfitrion
						//que la tabla de partidas est?? llena
						printf("%s\n",respuesta);
					}
				} 
				else {
					sprintf (respuesta, "7/%d/%s no est?? en la lista",id,invitado); 
					//No envia la invitaci??n y le indica al anfitri??n que el invitado no est?? conectado
					write (sock_conn,respuesta, strlen(respuesta)); 
					printf("%s\n",respuesta);
				}
				p = strtok( NULL, "/");
			}
		}
		else if (codigo == 8) //RECIBO: 8/ID/SI
			//ENVIO: 8/ID/MARIA/SI
		{
			strcpy(respuesta,"");
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy (respuesta, p);
			SocketAnfitrion = misPartidas[id].jugadores[0].socket;  //el invitado saca el socket del anfitrion de la partida a la que se quiere unir
			if (strcmp(respuesta,"SI")==0) {
				int pon = PonPartida(misPartidas, username, sock_conn, id);  //Mete al invitado con su username a la partida en la que acepta unirse
				if (pon!=-1) {
					sprintf (respuesta, "8/%d/%s/SI/", id, username);
					write (SocketAnfitrion,respuesta, strlen(respuesta)); //Notifico al anfitrion que el invitado se ha unido a la partida con id ID
				}
				else  {
					sprintf (respuesta, "8/%d/%s/%s no cabe en esta partida/", id, username, username);
					write (SocketAnfitrion,respuesta, strlen(respuesta));  //Notifico al anfitrion que el invitado no cabe en la partida
					sprintf (respuesta, "8/%d/%s/Hay demasiados jugadores en esta partida/", id, username);
					write (sock_conn,respuesta, strlen(respuesta)); //Tambi??n se lo notifico al invitado
				}
			} 
			else {
				sprintf (respuesta, "8/%d/%s/%s no quiere jugar en esta partida/", id, username, username);
				write (SocketAnfitrion,respuesta, strlen(respuesta));  //Notifico al anfitrion que el invitado no quiere jugar en la partida con tal id
			}
		}
		else if (codigo == 9) // RECIBO: 9/ID/Chat
		{ 
			//ENVIO: 9/ID/Username/Chat
			strcpy(respuesta,"");
			char chat[100];
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy(chat,p);
			int n;
			//Envio el mensaje del chat a cada uno de los invitados
			for (n=0; n<misPartidas[id].num; n++) {
				SocketInvitado = misPartidas[id].jugadores[n].socket;
				sprintf (respuesta, "9/%d/%s/%s", id, username, chat);
				printf("%s al %s con socket %d\n",respuesta,misPartidas[id].jugadores[n].nombre,SocketInvitado);
				//Le envio a todos los jugadores de la partida id, incluido el anfitrion, el nombre del autor del mensaje y el mensaje
				write (SocketInvitado,respuesta, strlen(respuesta));
			}
		}
		
		else if (codigo == 11) //envio 11/ID/Username/NumerodeJugadores/Jugador1/Jugador2/Jugador3/JugadorN.
		{ 
			char nombresjugadores[100];
			strcpy(respuesta,"");
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy(juego,p);
			if (strcmp (juego,"Eliminar")==0)
			{
				EliminarPartida(misPartidas,id);
			}
			else {
				
				int n;
				pthread_mutex_lock(&mutex);
				DameNombresJugadores(misPartidas,id,nombresjugadores);
				pthread_mutex_unlock(&mutex);
				if(sock_conn == misPartidas[id].jugadores[0].socket){
					for (n=0; n<misPartidas[id].num; n++) {
						SocketInvitado = misPartidas[id].jugadores[n].socket;
						sprintf (respuesta, "11/%d/%s/%s",id,misPartidas[id].jugadores[n].nombre,nombresjugadores);
						printf("%s\n",respuesta);
						//Le envio a todos los jugadores de la partida id, incluido el anfitrion, el nombre del autor del mensaje y el mensaje
						write (SocketInvitado,respuesta, strlen(respuesta));
					}					
				}
				
			}
		}
		
		else if (codigo == 13) //recibimos 13/ID/palabra
			//envio "13/ID/palabra/longitud
		{ 
			strcpy(respuesta,"");
			char Palabra[20];
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy(Palabra,p);
			strcpy(misPartidas[id].palabra,Palabra);
			int longitud = strlen(Palabra);
			int n;
			sprintf(respuesta,"13/%d/%s/%d/",id,Palabra,longitud);
			for (n=0; n<misPartidas[id].num; n++) {
				SocketInvitado = misPartidas[id].jugadores[n].socket;
				printf("%s\n",respuesta);
				//Le envio a todos los jugadores de la partida id, el personaje y el usuario asociado a este
				//o si este personaje no est?disponible se lo indico al cliente.
				write (SocketInvitado,respuesta, strlen(respuesta));
			}
		}
		
		else if (codigo == 14) //recibimos "14/ID/invited/Juegan"
			//envio "14/ID/Invited/Juegan"
		{ 
			strcpy(respuesta,"");
			char invited[20];
			int juegan;
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy(invited,p);
			p = strtok( NULL, "/");
			juegan=atoi(p);
			sprintf (respuesta, "14/%d/%s/%d", id, invited, juegan);
			int n;
			for (n=0; n<misPartidas[id].num; n++) {
				SocketInvitado = misPartidas[id].jugadores[n].socket;
				printf("%s\n",respuesta);
				//Se lo envio a todos los jugadores de la partida id, el personaje.
				write (SocketInvitado,respuesta, strlen(respuesta));
			}
		}
		
		else if (codigo == 15) //recibimos "15/ID/letra"
			//envio "15/ID/SI/letra" si acierta la letra
			//envio "15/ID/NO/letra" si no acierta la letra
			//envio "16/ID/username/ronda/rondacabada/letra" si acaba la ronda porque alguien ha adivinado la Palabra
			//envio "16/ID/NO/ronda/rondacabada" si la ronda ha terminado porque han agotado las oportunidades
			//envio "17/ID/
		{ 
			
			int rondacabada=0;
			char PuntuacionesJugadores[100];
			char JugadoresPalabras[100];
			strcpy(respuesta,"");
			strcpy(respuesta2,"");
			strcpy(respuesta3,"");
			char letra[1];
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy(letra,p);
			pthread_mutex_lock(&mutex);
			int res= EstaEnPalabra(misPartidas,letra,id);
			pthread_mutex_unlock(&mutex);
			
			if (res != -1){
				
				misPartidas[id].contadoraciertos=misPartidas[id].contadoraciertos+res;
				misPartidas[id].puntuaciones[misPartidas[id].ronda]+=5;
				printf("Ronda: %d, Puntuacion: %d\n",misPartidas[id].ronda,misPartidas[id].puntuaciones[misPartidas[id].ronda]);
				if (misPartidas[id].contadoraciertos == strlen(misPartidas[id].palabra))
				{
					strcpy(misPartidas[id].ganadores[misPartidas[id].ronda].nombre,username);  //guardo el ganador de la ronda
					strcpy(misPartidas[id].ganadores[misPartidas[id].ronda].palabra, misPartidas[id].palabra);  //guardo la palabra acertada por el ganador
					misPartidas[id].contadorganadores=misPartidas[id].contadorganadores+1;
					misPartidas[id].puntuaciones[misPartidas[id].ronda]+=10;
					misPartidas[id].ronda=misPartidas[id].ronda+1;
					rondacabada=1;
					misPartidas[id].contadorerrores=0; //Reinicio los contadores de errores y aciertos para la proxima partida
					misPartidas[id].contadoraciertos=0;  //Reinicio los contadores de errores y aciertos para la proxima partida
					sprintf(respuesta,"16/%d/%s/%d/%d/%s",id,username,misPartidas[id].ronda,rondacabada,letra);  //la partida a acabado porque el jugador ha adivinado la palabra
					
					//Miro si se han acabado las rondas y por lo tanto la partida
					if (misPartidas[id].ronda== misPartidas[id].num){
						DameGanadoresyPalabras(misPartidas,id,JugadoresPalabras);
						DamePuntuacionesJugadores(misPartidas,id,PuntuacionesJugadores);
						sprintf(respuesta2,"17/%d/%d/%d/%s%s",id,misPartidas[id].num,misPartidas[id].contadorganadores,PuntuacionesJugadores,JugadoresPalabras);
						pthread_mutex_lock(&mutex);
						insertarinfo(respuesta2,conn); 
						pthread_mutex_unlock(&mutex);
						printf("%s\n",respuesta2);
						acabada=1;
						misPartidas[id].ronda=0;
						misPartidas[id].contadorganadores=0;//reseteo la ronda
						//Reseteo las puntuaciones
						misPartidas[id].puntuaciones[0]=0;
						misPartidas[id].puntuaciones[1]=0;
						misPartidas[id].puntuaciones[2]=0;
						misPartidas[id].puntuaciones[3]=0;
					}
				}
				else
															   sprintf(respuesta, "15/%d/SI/%s", id,letra);
			}
			else{
				misPartidas[id].contadorerrores=misPartidas[id].contadorerrores+1;
				misPartidas[id].puntuaciones[misPartidas[id].ronda]-=5;
				printf("Ronda: %d, Puntuacion: %d\n",misPartidas[id].ronda,misPartidas[id].puntuaciones[misPartidas[id].ronda]);
				
				if (misPartidas[id].contadorerrores == 15)
				{
					misPartidas[id].ronda=misPartidas[id].ronda+1;
					rondacabada=1;
					misPartidas[id].contadorerrores=0;
					misPartidas[id].contadoraciertos=0;
					sprintf(respuesta,"16/%d/NO/%d/%d",id,misPartidas[id].ronda,rondacabada);  //la partida ha acabado porque se ha llegado al cupo de errores y notifico la siguiente ronda
					
					//Miro si se han acabado las rondas y por lo tanto la partida
					if (misPartidas[id].ronda == misPartidas[id].num){
						DameGanadoresyPalabras(misPartidas,id,JugadoresPalabras);
						DamePuntuacionesJugadores(misPartidas,id,PuntuacionesJugadores);
						sprintf(respuesta2,"17/%d/%d/%d/%s%s",id,misPartidas[id].num,misPartidas[id].contadorganadores,PuntuacionesJugadores,JugadoresPalabras);
						pthread_mutex_lock(&mutex);
						insertarinfo(respuesta2,conn); 
						pthread_mutex_unlock(&mutex);
						printf("%s\n",respuesta2);
						acabada=1;
						misPartidas[id].contadorganadores=0;
						misPartidas[id].ronda=0; //reseteo la ronda
						//Reseteo las puntuaciones
						misPartidas[id].puntuaciones[0]=0;
						misPartidas[id].puntuaciones[1]=0;
						misPartidas[id].puntuaciones[2]=0;
						misPartidas[id].puntuaciones[3]=0;
					}
				}	
				else
					sprintf(respuesta, "15/%d/NO/%s", id,letra);  //le notifico al jugador que ha perdido el turno
				
			}
			
			int n;
			for (n=0; n<misPartidas[id].num; n++) {
				
				SocketInvitado = misPartidas[id].jugadores[n].socket;
				printf("%s\n",respuesta);
				//Se lo envio a todos los jugadores de la partida id, el personaje.
				write (SocketInvitado,respuesta, strlen(respuesta));
				
			}
		}
		
		if (codigo == 12)
		{
			//RECIBO: 12/username/password
			strcpy(respuesta,"");
			p = strtok( NULL, "/");
			strcpy (username, p);
			p = strtok( NULL, "/");
			strcpy (password, p);
			//Miramos si tambi?????????n se quiere dar de baja
			found = login (username, password, conn); //Nos dice si ha encontrado al usuario en la base de datos			
			res=DamePosicion(&miLista,username); //Miramos si el usuario esta conectado en ese momento. Si lo est??? no lo daremos de baja
			
			if (found == 1 && res==-1)
			{
				SignOut(username,conn);  //Damos de baja al usuario
				sprintf (respuesta, "12/El usuario %s ha sido dado de baja",username);
			}
			if (found == 1 && res!=-1)
			{
				sprintf (respuesta, "12/El usuario %s est??? en linea en otro dispositivo. Debe hacer log out",username);
			}
			else
				sprintf (respuesta, "12/Usuario o clave incorrectos");
			
		}
		
		if ((codigo ==1)||(codigo ==2)||(codigo ==3)||(codigo ==4)||(codigo ==5)|| (codigo==12))
		{
			write (sock_conn,respuesta, strlen(respuesta)); //respuesta a un cliente
		}
		
		if (codigo == 15 && acabada == 1)  //Envio el mensaje de que la partida ha acabado
		{
			int n;
			printf("%s\n",respuesta2);
			for (n=0; n<misPartidas[id].num; n++) {
				write (misPartidas[id].jugadores[n].socket,respuesta2, strlen(respuesta2));
				acabada=0;
			}
		}
		
		if (codigo ==2){
			
			char notificacion[100];
			char notificacion2[100];	
			strcpy(notificacion,"");
			strcpy(notificacion2,"");
			pthread_mutex_lock(&mutex); //No me interrumpas ahora
			DameConectados (&miLista, notificacion2);
			
			pthread_mutex_unlock(&mutex); //ya puedes interrumpirme 
			sprintf (notificacion,"6/%s/",notificacion2);
			int j;
			for (j=0; j<miLista.num; j++)
			{				
				write (miLista.conectados[j].socket,notificacion, strlen(notificacion)); //notificar a todos los clientes conectados
			}
		}
		
		if (codigo==0) {
			
			char notificacion7[100];
			char notificacion8[100];
			strcpy(notificacion7,"");
			strcpy(notificacion8,"");
			pthread_mutex_lock(&mutex); //No me interrumpas ahora
			DameConectados (&miLista, notificacion7);
			
			pthread_mutex_unlock(&mutex); //ya puedes interrumpirme 
			sprintf (notificacion8,"6/%s/",notificacion7);
			printf("%s\n",notificacion8);
			printf("Numero de conectados: %d\n",miLista.num);
			int j;
			for (j=0; j<miLista.num; j++)
			{
				if(miLista.conectados[j].socket != sock_conn)
					write (miLista.conectados[j].socket,notificacion8, strlen(notificacion8)); //notificar a todos los clientes conectados
				else
					write(miLista.conectados[j].socket,"/0",strlen("/0"));
			}
		}
		
		if ((codigo==8 || codigo==11)) {
			
			char notificacion3[100];
			char notificacion5[100];
			char notificacion4[100];
			int j;
			int h;
			
			for (j=0; j < 100; j++)
			{
				int n;				
				for (n=0; n<misPartidas[j].num; n++) {
					strcpy(notificacion3,"");
					strcpy(notificacion5,"");
					strcpy(notificacion4,"10/");
					//printf("n: %d\n",misPartidas[j].num);
					printf("Primer jugador: %s, Segundo jugador: %s\n",misPartidas[j].jugadores[0].nombre,misPartidas[j].jugadores[1].nombre);
					pthread_mutex_lock(&mutex); //No me interrumpas ahora
					h = DamePartidas (misPartidas, misPartidas[j].jugadores[n].nombre, notificacion3); //2/0/1
					strcpy(notificacion5,notificacion3);
					pthread_mutex_unlock(&mutex); //ya puedes interrumpirme
					strcat(notificacion4,notificacion5);
					strcat(notificacion4,"/");
					printf("Notificacion: %s\n",notificacion4);
					write (misPartidas[j].jugadores[n].socket,notificacion4, strlen(notificacion4)); //notificar a todos los clientes pertenecientes a la partida
				}
			}
			
		}
		
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
	//Cerrar la conexi??????n con el servidor SQL
	mysql_close (conn);
	
}

int main(int argc, char *argv[]){
	init2(misPartidas);
	init(&miLista);
	miLista.num=0;
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creando socket");
	// Hacemos el bind al port
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(50052);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error en el bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	//Si hubiese algun fallo en el momento de realizar la conexion con el servidor, nos lo notificara.
	i=0;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		//notificar a todos los clientes conectados
		sock_conn = accept(sock_listen, NULL, NULL);
		//sock_conn es el socket que usaremos para este cliente
		printf ("He recibido conexion\n");
		pthread_mutex_lock(&mutex); //No me interrumpas ahora
		res=Pon (&miLista, "", sock_conn);
		pthread_mutex_unlock(&mutex); //Ya me puedes interrumpir
		
		// Crear thread y decirle lo que tiene que hacer
		// Cuando creo la conexi??????n, a??????ado un nuevo conectado a la lista de conectados
		// y guardo en sus campos de thread y de socket los valores correspondientes
		// El campo del nombre queda vac??????o hasta que no haga log in.
		pthread_create(&miLista.conectados[miLista.num-1].thread, NULL, AtenderCliente, &miLista.conectados[miLista.num-1].socket);
		i=i+1;
	}
}
