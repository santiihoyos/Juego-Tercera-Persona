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
    public LayerMask Seleccionable;
    public LayerMask atacable;
    public GameObject[] PrefabAtaques;
    public ControladorUI ControladorUi;

    [Space] public float Vida;
    public float Mana;


    [SerializeField] private float _manaMax;
    [SerializeField] private float _vidaMax;
    [SerializeField] private GameObject _atacadoActual;
    [SerializeField] private GameObject _posicionLanzadorHechizos;

    [Serializable]
    public class LayerChangeEvent : UnityEvent<string>
    {
    }

    public LayerChangeEvent OnLayerClickChangeEvent;

    private LayerMask _layerActualBajoElCursor;
    private int _mascaraChocado;
    private AnimationClip _clipAtaque;
    private GameObject _disparoActual;
    private bool _disparando = false;


    void InstanciaAtaque()
    {
        transform.LookAt(_atacadoActual.transform);
        var disparo = Instantiate(PrefabAtaques[0], _posicionLanzadorHechizos.transform.position,
            _posicionLanzadorHechizos.transform.rotation);
        disparo.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10f, ForceMode.VelocityChange);
    }

    void SpawmeaPhoton()
    {
    }

    private void Start()
    {
        Mana = _manaMax;
        Vida = _vidaMax;
    }

    void LanzaPhoton()
    {
        print("Lanza disparo!");
        //_disparoActual.transform.parent = null;
        //_disparoActual.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10f, ForceMode.VelocityChange);
        print("Spawmea disparo!");
        _disparoActual = Instantiate(PrefabAtaques[0], _posicionLanzadorHechizos.transform.position,
            _posicionLanzadorHechizos.transform.rotation);
        _disparoActual.GetComponent<EffectSettings>().Target = _atacadoActual;
        //_disparoActual.transform.parent = _posicionLanzadorHechizos.transform;
        _disparando = false;
    }

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
                else if ((_mascaraChocado & atacable.value) == _mascaraChocado)
                {
                    if (Mana >= 10)
                    {
                        _atacadoActual = hit.collider.gameObject;
                        GetComponent<Animator>().SetTrigger("ataca");
                        _disparando = true;
                        Mana -= 10;
                        ControladorUi.SetMana(Mana / _manaMax);
                    }
                }

                print(LayerMask.LayerToName(hit.collider.gameObject.layer));
            }
        }

        if (_disparando)
        {
            transform.LookAt(_atacadoActual.transform);
        }
    }
}