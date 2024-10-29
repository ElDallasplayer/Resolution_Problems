//PROBLEMA PLANTEADO:
//Una computadora comienza imprimiendo los números 2023, 2024 y 2025.
//Luego continúa imprimiendo sin parar la suma de los últimos 3 números que imprimió: 6072, 10121, 18218, …
//¿Cuáles son los últimos 4 dígitos del número impreso en la posición 2023202320232023?
//Por ejemplo, en la posición 50, está impreso el número 8188013234823360 que termina en 3360.

//VALORES INICIALES
long val1 = 2023;
long val2 = 2024;
long val3 = 2025;

//AQUI GUARDO UNA LISTA DE LOS ULTIMOA VALORES DISPONIBLES CON EL OBJETIVO DE COMPROBAR LA EXISTENCIA DE UNA SECUENCIA
Dictionary<(long, long, long), int> valuesList = new Dictionary<(long, long, long), int>();

//targetPosition ME SERVIRA PARA BUSCAR UNA POSICION
long targetPosition = 2023202320232022; //Busco un valor menor por el indice
//long targetPosition = 49; =>Me sirvio para validar que me daba el valor mostrado en la prueba (Al manejarse con indices, inicia de cero, asi que el valor buscado es 49)

long valtemp = 0; //AQUI ALMACENO EL SIGUIENTE VALOR CALCULADO
int index = 0; //INDEX ES MI CANTIDAD DE ITERACIONES

//AQUI DEJARE TODOS LOS VALORES GENERADOS
List<long> digistsLast = new List<long>();
digistsLast.Add(val1 % 10000);
digistsLast.Add(val2 % 10000);
digistsLast.Add(val3 % 10000);

//ESTE ES UN BUCLE PARA HACER UNA BUSQUEDA INFINITA HASTA ENCONTRAR UN CICLO
while (true)
{
    //AQUI, SEGUN LO PEDIDO EN LA SOLICITUD, ME ENCARGO DE SUMAR LOS 3 NUMEROS, Y UTILIZO % 10000 PARA QUEDARME CON LOS ULTIMOS 4 DIGITOS
    // GUARDAR SOLO ESTOS DIGITOS ME SERVIRA PARA SABER DONDE SE REPITEN
    valtemp = (val1 + val2 + val3) % 10000; 

    digistsLast.Add(valtemp);

    //AQUI MUEVO LOS VALORES PARA QUE SE SUMEN CORRECTAMENTE EN LA SIGUIENTE ITERACION
    val1 = val2;
    val2 = val3;
    val3 = valtemp;


    var valuesKey = (val1, val2, val3);
    if (valuesList.ContainsKey(valuesKey)) //BUSCO LA EXISTENCIA DE STATE COMO TUPLA, YA QUE EL DICTIONARY ME PERMITE BUSCAR MAS FACIL EL VALOR USANDO UNA KEY, ASI SABRE SI SE REPITE
    {
        break; //CUANDO ENCUENTRA UNA CONINCIDENCIA, SE DETIENE
    }
    else
    {
        //SI NO ENCUENTRO UNA CONCIDENCIA, CARGO LOS VALORES DE LA TUPLA EN LA LISTA DE VALORES PARA VER MAS ADELANTE EN QUE PUNTO INICIA EL PATRON
        valuesList[valuesKey] = index++;
    }
}

//BUSCO CUANDO SE REPITE LA SECUENCIA
int patternStart = valuesList[(val1, val2, val3)];
int cycleLength = digistsLast.Count - patternStart;

//(targetPosition - patternStart) => Cuantas posiciones hay desde el inicio del ciclo hasta el punto que estoy buscando.
//% cycleLength => Operador modulo me da la ubicacion del patron dentro de la lista
long indexPattern = (targetPosition - patternStart) % cycleLength;

//BUSCO LOS ULTIMOS 4 DIGITOS DE LA LISTA CREADA ANTERIORMENTE SEGUN EL INICIO DEL PATRON MAS EL INDICE DEL PATRON
long problemResponse = digistsLast[patternStart + (int)indexPattern];

Console.ReadKey();