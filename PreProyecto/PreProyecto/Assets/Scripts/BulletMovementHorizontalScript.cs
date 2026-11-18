using UnityEngine;

public class BulletMovementHorizontalScript : MonoBehaviour
{

    [SerializeField] private float speed = 7f;
    private Renderer renderer;

    private bool isRenderer = false;


    private Rigidbody2D rb;


    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.linearVelocity = new Vector2(speed, 0);
        renderizadoEnPantalla();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Choco el: " + other.gameObject.tag);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Juego Acabo");
            Time.timeScale = 0f;
        }
    }

    private void renderizadoEnPantalla()
    {
        if (renderer.isVisible)
        {
            isRenderer = true;
        }
        else if (isRenderer)
        {
            Destroy(gameObject);
        }
    }
}
