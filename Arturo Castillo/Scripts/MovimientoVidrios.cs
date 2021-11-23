using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoVidrios : MonoBehaviour
{
    public GameObject vidrio;
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
        velocidad = 4;
        dificultad = 1;
    }

    // Update is called once per frame
    void Update()
    {
        vidrio.transform.position = Vector3.MoveTowards(vidrio.transform.position, destino, velocidad * dificultad * Time.deltaTime);

        if(vidrio.transform.position == endPoint.position)
        {
            destino = startPoint.position;
        }

        if(vidrio.transform.position == startPoint.position)
        {
            destino = endPoint.position;
        }
    }
}
