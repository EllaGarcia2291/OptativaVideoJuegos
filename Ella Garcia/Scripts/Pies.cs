using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{
    public Control control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private  void OnTriggerStay (Collider other)
        {
            control.puedoSaltar=true;

        }
    private  void OnTriggerExit(Collider other)
        {
            control.puedoSaltar=false;
        }
    }

