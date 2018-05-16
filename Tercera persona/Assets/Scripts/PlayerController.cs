using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public GameObject MarcadorDestino;
    public LayerMask caminable;
    public LayerMask seleccionable;
    public LayerMask atacable;

    [Serializable]
    public class LayerChangeEvent : UnityEvent<string>
    {
    }

    public LayerChangeEvent OnLayerClickChangeEvent;

    private LayerMask _layerActualBajoElCursor;
    private int _mascaraChocado;
    
    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * 5000, Color.green);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(mouseRay, out hit, 5000);
        if (hasHit)
        {
            //si tenemos en cuenta qeu es una potencia de 2 es facil calcularla
            _mascaraChocado = (int) Mathf.Pow(2, hit.collider.gameObject.layer);
            
            if (_layerActualBajoElCursor != hit.collider.gameObject.layer)
            {
                OnLayerClickChangeEvent.Invoke(LayerMask.LayerToName(hit.collider.gameObject.layer));
                _layerActualBajoElCursor = hit.collider.gameObject.layer;
                print("Detectada otra capa");
            }

            if (Input.GetMouseButtonDown(1))
            {
                //forma teradicional
                //var mascaraChocado = LayerMask.GetMask(LayerMask.LayerToName(hit.collider.gameObject.layer));

                if ((_mascaraChocado & caminable.value) == _mascaraChocado)
                {
                    var pos = hit.point;
                    pos.y = 0.1f;
                    MarcadorDestino.transform.position = pos;
                    GetComponent<AICharacterControl>().target = MarcadorDestino.transform;
                }

                print(LayerMask.LayerToName(hit.collider.gameObject.layer));
            }
        }
    }
}