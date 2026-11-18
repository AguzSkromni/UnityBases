using UnityEngine;

public class GeneratorScript : MonoBehaviour
{


    //1. Recordar qué prefab debe crear.Eso es un campo público o[SerializeField] que tú asignas desde el Inspector.
    //2. Medir el tiempo que ha pasado desde la última esfera.
    //3. Crear una copia del prefab cuando ese tiempo llega al intervalo, y reiniciar la medición.

    //Inspect the bullet Prefab
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float timerLeft = 5f;   // intervalo en segundos
    [SerializeField] private int maxObjetos = 5;

    private float temporizador;
    private int contadorObjectosCreados = 0;


    void Start()
    {
        temporizador = timerLeft;
    }


    // Update is called once per frame
    void Update()
    {
        if (contadorObjectosCreados >= maxObjetos) return;

        temporizador -= Time.deltaTime;

        if (temporizador <= 0f)
        {
            GameObject bala = Instantiate(bulletObject, transform.position, Quaternion.identity);
            contadorObjectosCreados++;
            temporizador = timerLeft;
            Debug.Log("Objetos creados: " + contadorObjectosCreados);
        }
    }
}
