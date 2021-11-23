using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personaje1 : MonoBehaviour
{
    //MOVIMEINTO Y ANIMACIÓNM
    public float velocidadMove = 1.0f;
    public float giro = 10.0f;
    private Animator anim;
    public float Horizontal, vertical;

    //SALTO
    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool enSuelo;
    public int fuerzaExtra = 0;

    //VIDAS, RESPAWN Y TEXTO
    public int vidas;
    public float limitex = 0;
    public float limitey = 0;
    public float limitez = 0;
    public Transform Respawn_zone;
    public Text GameOver;
    public Button resetButton;
    public Text reset;

    //Agacharse
    public float velocidadInicial;
    public float velocidadAgachado;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        enSuelo = false;
        GameOver.enabled = false;
        resetButton.image.enabled = false;
        reset.enabled = false;
        velocidadInicial = velocidadMove;
        velocidadAgachado = velocidadMove * 0.3f;
    }

    // En computadoras que corre menos cuadros por segundo, todo va a ocurrir en el mismo tiempo.
    void FixedUpdate()
    {
        transform.Rotate(0, Horizontal * Time.deltaTime * giro, 0);
        transform.Translate(0, 0, vertical * Time.deltaTime * velocidadMove);
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");        

        anim.SetFloat("VelX", Horizontal);
        anim.SetFloat("VelY", vertical);

        //SE REALIZA EL SALTO DEL PERSONAJE
        if (enSuelo){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("agachado", true);
                velocidadMove = velocidadAgachado;
            }
            else
            {
                anim.SetBool("agachado", false);
                velocidadMove = velocidadInicial;
            }

            anim.SetBool("tocaSuelo", true);
        }else{
            estoyCayendo();
        }

        //VIDAS Y GAME OVER
        if(vidas > 0){
            // Debug.Log(vidas);
            if(transform.position.x > limitex || transform.position.x < -limitex)
            {
                vidas = vidas - 1;
                this.transform.position = Respawn_zone.transform.position;
            }
            if(transform.position.y > limitey || transform.position.y < -limitey)
            {
                vidas = vidas - 1;
                this.transform.position = Respawn_zone.transform.position;
            }
            if(transform.position.z > limitez || transform.position.z < -limitez)
            {
                vidas = vidas - 1;
                this.transform.position = Respawn_zone.transform.position;
            }
        }else{
            Destroy(this.gameObject);
            GameOver.enabled = true;
            resetButton.image.enabled = true;
            reset.enabled = true;
        }

    }

    void estoyCayendo()
    {
        rb.AddForce(fuerzaExtra * Physics.gravity);

        anim.SetBool("Salto", false);
        anim.SetBool("tocaSuelo", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Vidrio")
        {
            transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Fuego")
        {
            vidas = vidas - 1;
            this.transform.position = Respawn_zone.transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Vidrio")
        {
            transform.parent = null;
        }
    }

}
