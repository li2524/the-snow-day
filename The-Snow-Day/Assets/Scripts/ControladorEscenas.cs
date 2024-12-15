using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorEscenas : MonoBehaviour
{

    public void CargarEscenario(string nombreEscenario)
    {
        SceneManager.LoadScene(nombreEscenario);
    }

    public void SalirDeJuego()
    {
        Application.Quit();
    }



}
