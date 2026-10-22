using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x,y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe = 10f;

    public bool estoyAtacando1;

    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!estoyAtacando && !estoyAtacando1)
        { 
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }

        if (avanzoSolo)
        {
            rb.linearVelocity = transform.forward * impulsoDeGolpe;
        }
    }
    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Z) && puedoSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        if (Input.GetKeyDown(KeyCode.X) && puedoSaltar && !estoyAtacando1)
        {
            anim.SetTrigger("golpeo1");
            estoyAtacando1 = true;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (!estoyAtacando && !estoyAtacando1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("salte", true);
                    rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
                }
            }
         
            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
        estoyAtacando1 = false;
    }
    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }
    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }

    public void DejeDeGolpear1()
    {
        estoyAtacando1 = false;
        estoyAtacando = false;
    }
}
