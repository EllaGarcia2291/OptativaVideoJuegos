using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Control : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
   //public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    public float altura_salto=0;
    public int Limites_saltos = 0;
    bool esta_en_suelo;
    public int vidas = 0;
    public float limite_x = 0;
    public float limite_z = 0;
    public float limite_y = 0;
    public Transform Respawn_zone;
    public Text GAME_OVER;
    public Text CONTINUAR;

    // Start is called before the first frame update
   //void Start();
   
      // anim = GetComponent<Animator>();
 
  

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        esta_en_suelo = true;
        anim = GetComponent<Animator>();
        GAME_OVER.enabled = false;
        CONTINUAR.enabled = false;

    }
    void FixedUpdate()
    {
        transform.Rotate(0,x * UnityEngine.Time.deltaTime * velocidadRotacion,0);
        transform.Translate(0, 0, y * UnityEngine.Time.deltaTime * velocidadMovimiento);
        

    }
    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space) && esta_en_suelo == true){ 
        Jump();
        //para asignar un valor a una tecla
         }
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        
        anim.SetFloat("Velx",x);
        anim.SetFloat("Vely",y);
    //zona cero
        
        Debug.Log (vidas);

         if(vidas > 0){
            if(transform.position.y > limite_y || transform.position.y < -limite_y){
            vidas=vidas -1;
            this.transform.position = Respawn_zone.transform.position;
        }
        }
       
        else {
      // Destroy(this.gameObject);
       // Debug.Log("Game over");
        GAME_OVER.enabled = true;
        CONTINUAR.enabled = true;
        if(Input.GetKeyDown(KeyCode.C)){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        }

           
    }

    void Jump(){
        esta_en_suelo = true;
        rb.AddForce(0,altura_salto,0, ForceMode.Impulse);
    }

     void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Suelo")){
            esta_en_suelo = true;
        }
    }
    
}
    
        


    
    


