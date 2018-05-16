using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
  public GameObject MarcadorDestino;
  public LayerMask caminable;
  public LayerMask seleccionable;

  // Update is called once per frame
  void Update()
  {
    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    Debug.DrawRay(mouseRay.origin, mouseRay.direction * 5000, Color.green);
    RaycastHit hit;

    if (Input.GetMouseButtonDown(1))
    {
      bool hasHit = Physics.Raycast(mouseRay, out hit, 5000);
      if (hasHit)
      {
        //forma teradicional
        //var mascaraChocado = LayerMask.GetMask(LayerMask.LayerToName(hit.collider.gameObject.layer));

        //si tenemos en cuenta qeu es una potencia de 2 es facil calcularla
        var mascaraChocado = (int)Mathf.Pow(2, hit.collider.gameObject.layer);

        if ((mascaraChocado & caminable.value) == mascaraChocado)
        {
          MarcadorDestino.transform.position = hit.point;
          GetComponent<AICharacterControl>().target = MarcadorDestino.transform;
        }
        else
        {
          print("Click en otra layer");
        }
      }
    }
  }
}