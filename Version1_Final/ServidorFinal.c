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

<<<<<<< HEAD
=======
typedef struct {
	Conectado jugadores[5];
	int num;
} Partida;

Partida misPartidas[100];
>>>>>>> dev-v4
void init(ListaConectados *lista) {
	int i;
	for (i=0; i<100; i++) {
		strcpy (lista->conectados[i].nombre, "");
		lista->conectados[i].socket = 0;
	}
}
<<<<<<< HEAD
=======

void init2(Partida partidas[100]) {
	int i;
	for (i=0; i<100; i++) {
		partidas[i].num=0;
	}
}
>>>>>>> dev-v4
int Pon (ListaConectados *lista, char nombre[20], int socket) {
	//A�ade nuevo conectados. Retorna 0 si ok y -1 si la lista 
	//ya estaba llena y no lo ha podido a�adir.
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
			strcpy (lista->conectados[lista->num].nombre, nombre);
			lista->conectados[lista->num].socket = socket;
			lista->num++;
			return 0;
			}
		}	
}
int PonNombre (ListaConectados *lista, int socket, char nombre[20]) {
	int encontrado = 0;
<<<<<<< HEAD
	int i;
=======
	int i=0;
>>>>>>> dev-v4
	while ((i < lista->num) && (!encontrado))
	{
		if (lista->conectados[i].socket==socket)
			encontrado = 1;
		if (!encontrado)
			i++;
	}
	int f = DamePosicion (lista, nombre);
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
	//Devuelve el socket o -1 si no est� en la lista
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
	//Devuelve la posicion o -1 si no est� en la lista
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
	//Queremossaber el nombre del usuario de la lista con el socket que pasamos 
	//parametro
	//Devuelve la posicion o -1 si no est� en la lista 
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
	//Retorna 0 si elimina y -1 si ese usuario no est� en la lista.
	int pos = DamePosicion (lista, nombre);
	if (pos == -1)
		return -1;
	else {
		int i;
		if (pos==0)
		{
			strcpy (lista->conectados[pos].nombre, lista->conectados[pos+1].nombre);
			lista->conectados[pos].socket = lista->conectados[pos+1].socket ;
		}
		else {
			for (i=pos; i < lista->num-1; i++)
			{
				//lista->conectados[i] = lista->conectados[i+1];
				strcpy (lista->conectados[i].nombre, lista->conectados[i+1].nombre);
				lista->conectados[i].socket = lista->conectados[i+1].socket;
			}
		}
		lista->num--;
		return 0;
		printf("%s %d\n",lista->conectados[0].nombre, lista->conectados[0].socket);
		
	}
}
	
void DameConectados (ListaConectados *lista, char conectados[100]) {
	//Pone en conectados los nombres de todos los conectados separados
	//por /. Primero pone el n�mero de conectados. Ejemplo: 
	//"3/Juan/Maria/Pedro"
	sprintf (conectados,"%d", lista->num);
	int i;
	for (i=0; i < lista->num; i++)
		sprintf (conectados, "%s/%s", conectados, lista->conectados[i].nombre);
}
////////////////////////////////////////////////////////////////////////////////
int crearPartida(Partida partidas[100], char nombre [20], int socket)
{
	//Crea nueva partida con el nombre del jugador que invita. La nueva partida se colocar� en la primera
	//posici�n libre de la tabla partidas.
	//Retorna el id de la partida si ok y -1 si la tabla partidas est� llena.
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
	//A�ade al invitado a la partida con el id que pasamos por par�metro.
	//Si esa partida contiene 5 jugadores o m�s no a�adir� al invitado y retornar� -1,
	//En otro caso, lo a�adir� y retornar� 0.
	if (partidas[id].num==5) {
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
	//separados por/ y comenzando por el numero de usuarios en la partida y el id.
	// 2/1/2, si no hay ninguna me devuelve -1, sino 0.	
	printf("Nombre: %s, PartidasActivas: %s\n",nombre,PartidasActivas);
	char solution[100];
	strcpy(solution,"");
	int i=0;
	int cont=0;
	while (i < 100)
	{
		int j=0;
		while (j<partidas[i].num) {
			if (strcmp(partidas[i].jugadores[j].nombre,nombre)==0) {
				if (partidas[i].num>=2)
				{
					cont=cont+1;
					sprintf (solution,"%s/%d", solution, i);
				}
				else
					EliminarPartida(partidas,i);
			}
			j++;
		}	
		i++;
	}
	
	if (solution=="") {
		return -1;
	}
	else {
		
		sprintf (PartidasActivas,"%d%s",cont,solution);
		printf("%s\n",PartidasActivas);
		return 0;
	}
}
////////////////////////////////////////////////////////////////////////////////	
int registro (char username [20], char password [15], MYSQL *conn)
{
	char consulta[1000];
	MYSQL_RES *resultado;
	MYSQL_RES *resultado2;
	MYSQL_ROW fila;
	MYSQL_ROW row;
	int err;
	int found;
	char IDn [10];
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
		// Si hay alg�n problema, nos mostrar� que hay un error la introducir los datos.
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
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [1000];
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

//Consulta1: Usernames de los jugadores que cumplen que el perdedor de la partida sea el nombre introducido por consola, que la posicion del jugador sea la dada por consola, 
//que la puntuación del jugador sea más pequeña que la que da el usuario y que no sea el mismo usuario.
void consulta1 (char perdedor [20], int posicion, int puntuacion, MYSQL *conn, char respuesta [512])
{
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	sprintf (consulta, "SELECT DISTINCT JUGADOR.USERNAME FROM (JUGADOR, PARTIDA, PARTICIPACION) WHERE PARTIDA.PERDEDOR = '%s' AND PARTIDA.ID = PARTICIPACION.ID_P  AND PARTICIPACION.POSICION = %d AND PARTICIPACION.PUNTUACION < %d AND PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME NOT IN ('%s');", perdedor, posicion, puntuacion, perdedor);
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
		strcpy (respuesta, "Los usuarios son: ");
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

void consulta2 (char username [20], MYSQL *conn, char respuesta [512])
{
	//Consulta: Usernames de los jugadores que han quedado en primer lugar en alguna de las partidas en las que
	//el jugador introducido por el usuario ha jugado y en las que el numero de participantes >= 3
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	strcpy(consulta,"SELECT DISTINCT JUGADOR.USERNAME FROM (JUGADOR,PARTIDA,PARTICIPACION) WHERE JUGADOR.ID = PARTICIPACION.ID_J AND PARTICIPACION.ID_P = PARTIDA.ID ");
	strcat(consulta,"AND PARTICIPACION.ID_P IN(SELECT PARTICIPACION.ID_P FROM (PARTICIPACION,JUGADOR) WHERE PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME = '");
	strcat(consulta,username);
	strcat(consulta,"') AND PARTICIPACION.POSICION = 1 AND PARTIDA.NUM_JUGADORES >= 3;");
	//Concatenamos diferentes trozos de la consulta para así introducir los parámetros
	//de forma que sea más fácil de entender.
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
	
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		strcpy (respuesta, "No se han obtenido datos en la consulta");
	}
	else
	{
		strcpy (respuesta, "Los usuarios son: ");
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

//Consulta3: IDs de partida en las que la puntuacion total de la partida sea mayor a una dada por consola,
//que se haya jugado en una fecha y hora determinada y que haya un minimo de jugadores indicado por consola.
void consulta3 (int minjug, int minpunt, char f_h [200], MYSQL *conn, char respuesta [512])
{
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char minpunts[10];
	char minjugs[10];
	
	// construimos la consulta SQL
	strcpy (consulta,"SELECT DISTINCT PARTIDA.ID FROM (PARTIDA, JUGADOR, PARTICIPACION) WHERE PARTIDA.FECHA_HORA = '");  
	strcat (consulta,f_h);
	strcat (consulta,"' ");
	strcat (consulta,"AND PARTIDA.NUM_JUGADORES >= "); 
	sprintf(minjugs,"%d ", minjug); 
	strcat (consulta, minjugs);
	strcat (consulta,"AND "); 
	sprintf(minpunts, "%d ", minpunt);
	strcat (consulta, minpunts);
	strcat (consulta,"< ( SELECT SUM(PARTICIPACION.PUNTUACION) FROM (PARTIDA, PARTICIPACION) WHERE PARTIDA.FECHA_HORA = '");
	strcat (consulta,f_h);
	strcat (consulta,"' ");
	strcat (consulta, "AND PARTIDA.ID = PARTICIPACION.ID_P) ");
	strcat (consulta,"AND PARTICIPACION.ID_P = PARTIDA.ID;");
	//Combinamos tanto el sprintf para meter las variables numericas dentro de la consulta como strings,
	//y tambien el strcat para concatenar las diferentes consultas a realizar en SQL.
	// hacemos la consulta  
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
		strcpy (respuesta, "Los ID de partida son: ");
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

ListaConectados miLista;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int res;
void *AtenderCliente (void *socket)
{
	
	char peticion[512];  //mensaje que recibimos del cliente a traves del socket
	char respuesta[512]; //mensaje que se envia al cliente a trav�s del socket
	char resolucion [512];
	char chat[100];
	int sock_conn;
	int *t;
	t = (int *) socket;
	sock_conn= *t;
	char username[20];
	char perdedor[20];
	char password [15];
	char invitado[20];
	char anfitrion[20];
	int posicion;
	int puntuacion;
	int found; //nos indica si el jugador que quiere registrarse ya esta registrado
	int minjug;
	int minpunt;
	char f_h[200];
	int ret;
<<<<<<< HEAD
=======
	int id;
	int SocketInvitado;
	int SocketAnfitrion;
	char jugada[100];
>>>>>>> dev-v4
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
				printf ("No est�.\n");
			else 
				printf ("Eliminado.\n");
			pthread_mutex_unlock(&mutex);
		}
		
		else if (codigo == 1) //piden hacer un registro
		{		
			p = strtok( NULL, "/");
			strcpy (username, p);
			p = strtok( NULL, "/");
			strcpy (password, p);
			found = registro(username, password, conn);
			
			if (found ==0) {
				sprintf (respuesta, "1/SI");
			} 
			else 
				sprintf(respuesta, "1/NO");
		}
		
		else if (codigo == 2)
		{
			// El usuario introducir� sus datos y veremos 
			// si puede entrar o no a realizar las consultas
			// si ese usuario est� registrado con esa contrase�a.
			strcpy(respuesta,"");
			p = strtok( NULL, "/");
			strcpy (username, p);
			p = strtok( NULL, "/");
			strcpy (password, p);
			pthread_mutex_lock(&mutex);
			found = login (username, password, conn);
			if (found == 0) {
				sprintf (respuesta, "2/NO/El usuario: %s, es incorrecto/", username);
				res = Eliminar (&miLista, "");
			} 
			else 
			{
				sprintf(respuesta, "2/SI");
				if (sock_conn !=-1) {
					if (res ==-1) {
						sprintf (respuesta, "%s/Lo sentimos %s, no se pueden a�adir m�s usuarios a la lista/", respuesta, username);
						res = Eliminar (&miLista, "");
					}	
					else if (res == -2) {
						sprintf (respuesta, "%s/Lo sentimos %s, el usuario ya esta en l�nea en otro dispositivo/", respuesta, username);
						res = Eliminar (&miLista, "");
					}
					else {
						int h = PonNombre(&miLista, sock_conn, username);
						if (h==0) {
							sprintf (respuesta, "%s/El usuario: %s, se ha anadido correctamente a la lista/", respuesta, username);
						}
						else if (h==-1) {
							res=Pon (&miLista, username, sock_conn);
							sprintf (respuesta, "%s/El usuario: %s, se ha anadido correctamente a la lista/", respuesta, username);
						}
						else {
							sprintf (respuesta, "%s/Lo sentimos %s, el usuario ya esta en l�nea en otro dispositivo/", respuesta, username);
							res = Eliminar (&miLista, "");
						}
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
<<<<<<< HEAD
			char resolucion [512];
=======
			strcpy(resolucion,"");
>>>>>>> dev-v4
			p = strtok( NULL, "/");
			strcpy (username, p);
			p = strtok( NULL, "/");
			posicion =  atoi (p);
			p = strtok( NULL, "/");
			puntuacion =  atoi (p);
			consulta1 (username, posicion, puntuacion, conn, resolucion);
			sprintf (respuesta,"3/%s",resolucion); 
		}
		
		else if (codigo == 4) //consulta2
		{
<<<<<<< HEAD
			char resolucion [512];
=======
			strcpy(resolucion,"");
>>>>>>> dev-v4
			p = strtok( NULL, "/");
			strcpy (username, p);
			consulta2 (username, conn, resolucion);
			sprintf (respuesta,"4/%s",resolucion); 
		}
		
		else if (codigo == 5) //consulta3
<<<<<<< HEAD
		{
			char resolucion [512];
=======
		{			
			strcpy(resolucion,"");
>>>>>>> dev-v4
			p = strtok( NULL, "/");
			minjug = atoi(p);
			p = strtok( NULL, "/");
			minpunt = atoi(p);
			p = strtok( NULL, "/");
			strcpy (f_h, p);
			consulta3 (minjug, minpunt, f_h, conn, resolucion);
			sprintf (respuesta,"5/%s",resolucion); 
<<<<<<< HEAD
=======
		}
		
		else if (codigo == 7) //RECIBO: 7/Maria/Pablo
			//ENVIO: 7/ID/Juan
		{	
			p = strtok( NULL, "/");
			while (p!=NULL)
			{	
				strcpy (invitado, p);
				SocketInvitado=DameSocket (&miLista, invitado);
				if (SocketInvitado!=-1) {
					id = crearPartida(misPartidas, username, sock_conn);
					sprintf (respuesta, "7/%d", id);
						if (id!=-1) {
							sprintf (respuesta, "%s/%s",respuesta, username);
							write (SocketInvitado,respuesta, strlen(respuesta));
						}
						else {
							sprintf (respuesta, "%s/Espera un poco... Todas las partidas est�n llenas",respuesta);
							write (sock_conn,respuesta, strlen(respuesta));
						}
				} 
				else {
					sprintf (respuesta, "%s/%s no est� en la lista",respuesta, invitado);
					write (sock_conn,respuesta, strlen(respuesta));
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
			SocketAnfitrion = misPartidas[id].jugadores[0].socket;
			if (strcmp(respuesta,"SI")==0) {
				int pon = PonPartida(misPartidas, username, sock_conn, id);
				if (pon!=-1) {
					sprintf (respuesta, "8/%d/%s/SI", id, username);
					write (SocketAnfitrion,respuesta, strlen(respuesta));
				}
				else  {
					sprintf (respuesta, "8/%d/%s/%s no cabe en esta partida", id, username, username);
					write (SocketAnfitrion,respuesta, strlen(respuesta));
					sprintf (respuesta, "8/%d/%s/Hay demasiados jugadores en esta partida", id, username);
					write (sock_conn,respuesta, strlen(respuesta));
				}
			} 
			else {
				sprintf (respuesta, "8/%d/%s/%s no quiere jugar en esta partida", id, username, username);
				write (SocketAnfitrion,respuesta, strlen(respuesta));
			}
>>>>>>> dev-v4
		}
		else if (codigo == 9) //9/ID/Chat
		{
<<<<<<< HEAD
			write (sock_conn,respuesta, strlen(respuesta)); //respuesta a un cliente
			
		}
		if ((codigo==2)||(codigo==0)) {
			
			char notificacion[100];
			char notificacion2[100];	
=======
			strcpy(respuesta,"");
			char chat[100];
			p = strtok( NULL, "/");
			id=atoi(p);
			p = strtok( NULL, "/");
			strcpy(chat,p);
			int n;
			for (n=0; n<misPartidas[id].num; n++) {
				SocketInvitado = misPartidas[id].jugadores[n].socket;
				sprintf (respuesta, "9/%s/%s", username, chat);
				printf("%s\n",respuesta);
				//Le envio a todos los jugadores de la partida id, incluido el anfitrion, el nombre del autor del mensaje y el mensaje
				write (SocketInvitado,respuesta, strlen(respuesta));
			}
		}

			
		if ((codigo ==1)||(codigo ==2)||(codigo ==3)||(codigo ==4)||(codigo ==5))
		{
			write (sock_conn,respuesta, strlen(respuesta)); //respuesta a un cliente
		}
		
		if (codigo ==2){
			
			char notificacion[100];
			char notificacion2[100];	
			strcpy(notificacion,"");
			strcpy(notificacion2,"");
>>>>>>> dev-v4
			pthread_mutex_lock(&mutex); //No me interrumpas ahora
			DameConectados (&miLista, notificacion2);
			
			pthread_mutex_unlock(&mutex); //ya puedes interrumpirme 
<<<<<<< HEAD
			sprintf (notificacion,"6/%s",notificacion2);
			int j;
			for (j=0; j<miLista.num; j++)
			{
				write (miLista.conectados[j].socket,notificacion, strlen(notificacion)); //notificar a todos los clientes conectados
			}
=======
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
			int j;
			for (j=0; j<miLista.num; j++)
			{
				if(miLista.conectados[j].socket != sock_conn)
					write (miLista.conectados[j].socket,notificacion8, strlen(notificacion8)); //notificar a todos los clientes conectados
			}
		}
		
		if ((codigo==8)) {
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
					if (h!=-1)
						write (misPartidas[j].jugadores[n].socket,notificacion4, strlen(notificacion4)); //notificar a todos los clientes pertenecientes a la partida
				}
			}
>>>>>>> dev-v4
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
	//Cerrar la conexi�n con el servidor SQL
	mysql_close (conn);
	
}

int main(int argc, char *argv[]){
<<<<<<< HEAD
=======
	init2(misPartidas);
>>>>>>> dev-v4
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
	serv_adr.sin_port = htons(50051);
	
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
		res=Pon (&miLista, "", sock_conn);
		// Crear thread y decirle lo que tiene que hacer
		pthread_create(&miLista.conectados[miLista.num-1].thread, NULL, AtenderCliente, &miLista.conectados[miLista.num-1].socket);
		i=i+1;
	}
}
