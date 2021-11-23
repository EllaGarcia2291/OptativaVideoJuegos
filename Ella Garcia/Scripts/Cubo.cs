using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cubo : MonoBehaviour
{
    public int Velocidad = 0;
    public float giro = 0;

    public int vidas= 0;
    public float limite_x = 0;
    public float limite_z = 0;
    public float Horizontal = 0;
    public float vertical = 0;

    public Rigidbody rb;

    public float altura_salto=0;
    public int Limites_saltos = 0;
    bool esta_en_suelo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        esta_en_suelo = true;
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        && AND O "Y"
        || OR - "O"
        */
       
        if(Input.GetKeyDown(KeyCode.Space) && esta_en_suelo == true){ 
          Jump();
        }
        Horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //ASIGNAR VELOCIDAD EN EJE Z
        transform.Translate(Vector3.forward * Time.deltaTime * Velocidad * vertical);
        //ASIGNAR VELOCIDAD EN EJE X
        transform.Translate(Vector3.right * Time.deltaTime * giro * Horizontal);

        //DEATH ZONE eje x(IZQUIERDA DERECHA)
        if(vidas > 0){
            Debug.Log(vidas);
        if(transform.position.x > limite_x || transform.position.x < -limite_x){
            vidas = vidas - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(transform.position.z > limite_z || transform.position.z < -limite_z){
            vidas = vidas - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        }else{
        Debug.Log("GAME OVER");
        }





    
    }

    void Jump(){
        esta_en_suelo = false;
        rb.AddForce(0,altura_salto,0, ForceMode.Impulse);
    }

     void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Suelo")){
            esta_en_suelo = true;
        }
    }
}   
