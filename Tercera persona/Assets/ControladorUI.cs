using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    public Image ImagenMana;
    public Image ImagenVida;
    public Image PanelGeneral;

    public void SetVida(float porcentajeVida)
    {
        ImagenVida.fillAmount = porcentajeVida;
    }

    public void SetMana(float porcentajeMana)
    {
        ImagenMana.fillAmount = porcentajeMana;
    }
}