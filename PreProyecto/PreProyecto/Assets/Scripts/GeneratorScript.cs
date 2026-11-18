using UnityEngine;

public class GeneratorScript : MonoBehaviour
{


    //1. Recordar qué prefab debe crear.Eso es un campo público o[SerializeField] que tú asignas desde el Inspector.
    //2. Medir el tiempo que ha pasado desde la última esfera.
    //3. Crear una copia del prefab cuando ese tiempo llega al intervalo, y reiniciar la medición.

    //Inspect the bullet Prefab
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float timer = 5;
    private bool bandera = true;
    private int temporizador = 0;
    private int contadorObjectosCreados = 0;


    // Update is called once per frame
    void Update()
    {

        while (bandera)
        {
            if(timer >= temporizador)
            {
                contdown();
            }
            else
            {
                Instantiate(bulletObject);
                contadorObjectosCreados++;
                Debug.Log("contador: " + contadorObjectosCreados);
            }

        }


    }

    private void contdown()
    {
            timer -= Time.deltaTime;
    }
}
