using System;
using TMPro;
using UnityEngine;

public class ContadorScript : MonoBehaviour
{

    [SerializeField] private ContadorConfig config;
    [SerializeField] private TMP_Text text;

    private int valor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valor = config.valorInicial;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        text.text = "Contador: " + valor;
    }
}
