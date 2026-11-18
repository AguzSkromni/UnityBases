using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReinicioEscena : MonoBehaviour
{

    void Update()
    {
        bool tecladoR = Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame;
        bool mandoStart = Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame;

        if (tecladoR || mandoStart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        bool tecladoN = Keyboard.current != null && Keyboard.current.nKey.wasPressedThisFrame;
        bool mandoRB = Gamepad.current != null && Gamepad.current.rightShoulder.wasPressedThisFrame;

        if (tecladoN || mandoRB)
        {
            CargarSiguienteEscena();
        }
    }

    void CargarSiguienteEscena()
    {
        int total = SceneManager.sceneCountInBuildSettings;
        int siguiente = (SceneManager.GetActiveScene().buildIndex + 1) % total;
        SceneManager.LoadScene(siguiente);
    }
}
