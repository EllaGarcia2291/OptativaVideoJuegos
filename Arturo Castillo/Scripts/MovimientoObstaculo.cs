using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    public GameObject obstaculo;
    public Transform startPoint;
    public Transform endPoint;
    public float velocidad;
    private Vector3 destino;

    // Dificultad
    public float dificultad;

    // Start is called before the first frame update
    void Start()
    {
        destino = endPoint.position;
        velocidad = 10;
        dificultad = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obstaculo.transform.position = Vector3.MoveTowards(obstaculo.transform.position, destino, velocidad * dificultad * Time.deltaTime);

        if (obstaculo.transform.position == endPoint.position)
        {
            destino = startPoint.position;
        }

        if (obstaculo.transform.position == startPoint.position)
        {
            destino = endPoint.position;
        }
    }
}
