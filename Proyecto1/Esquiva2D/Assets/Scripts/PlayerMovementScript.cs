using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{

    /// <summary>
    /// Fuerza ejercida para arriba
    /// </summary>
    [SerializeField] private float jumpForce = 8f;

    /// <summary>
    /// Tiempo maximo que puede flotar en aire
    /// </summary>
    [SerializeField] private float maxTime;

    /// <summary>
    /// Factor que corta el movimiento vertical
    /// </summary>
    [SerializeField] private float factorCut;

    /// <summary>
    /// Input action de movimiento del player
    /// </summary>
    [SerializeField] private InputActionReference inputActionReference;

    /// <summary>
    /// Objecto vacio de hijo en player, para hacer RayCast desde los pies
    /// </summary>
    [SerializeField] private Transform puntoPies;

    /// <summary>
    /// Distancia del rayo para detectar el collider
    /// </summary>
    [SerializeField] private float rayTrace = 0.1f;

    /// <summary>
    /// LayerMask que referencia la layer del suelo (Floor)
    /// </summary>
    [SerializeField] private LayerMask capaSuelo;


    /// <summary>
    /// Booleano que indica si esta en piso
    /// </summary>
    private bool isOnFloor;

    /// <summary>
    /// Booleano que indica si un boton se pulso
    /// </summary>
    private bool botonPulsado = false;

    /// <summary>
    /// Booleano que indica el frame antes del boton pulsado
    /// </summary>
    private bool botonPulsadoAntes = false;

    /// <summary>
    /// Booleano que indica si el player esta saltando
    /// </summary>
    private bool isJumping = false;


    /// <summary>
    /// Rigibody para captura el rigibody del Player
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// RayCast que apunta hacia abajo 
    /// </summary>
    private Vector2 rayCastDown = Vector2.down;

    /// <summary>
    /// Raycast que se usa para extraer si el raycast golpeo la capa floor
    /// </summary>
    private RaycastHit2D raycastHit2D;


    /// <summary>
    /// On Wake asigna el RigiBody al rb creado
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// Fixed Update que llama a calculoRayTrace, PressedButton y rb
    /// </summary>
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        calculoRayTrace();
        pressedButton();
    }


    /// <summary>
    /// Metodo void que verifica si un boton esta siendo pulsado, si esta siendo pulsado
    /// revisa si es igual al frame anterior y verifica si esta en suelo para poder aplicar
    /// la fuerza de brinco
    /// </summary>
    void pressedButton()
    {
        botonPulsado = inputActionReference.action.IsPressed();

        if (botonPulsado != botonPulsadoAntes)
        {
            if (botonPulsado)
            {
                if (isOnFloor == true)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    isJumping = true;
                    Debug.Log("Pulsación" + isJumping);
                }
            }
            else
            {
                Debug.Log("Liberación");
            }
        }

        botonPulsadoAntes = botonPulsado;
    }


    /// <summary>
    /// Metodo que funciona para verificar mediante un trace el objecto que esta debajo
    /// apuntando a la capa suelo (floor) para verificarlo y definir valores booleanos
    /// </summary>
    void calculoRayTrace()
    {
        Vector2 origen = puntoPies.position;
        //Debug.Log("Position: " + posicion2D);

        raycastHit2D = Physics2D.Raycast(origen, rayCastDown, rayTrace, capaSuelo);
        Debug.DrawRay(origen, rayCastDown * rayTrace, Color.red);

        if (raycastHit2D.collider != null)
        {
            isOnFloor = true;
            isJumping = false;
        }
        else
        {
            isOnFloor = false;
        }
    }
}
