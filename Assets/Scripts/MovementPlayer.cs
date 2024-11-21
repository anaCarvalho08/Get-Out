using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float velocidade = 5.0f;
    [SerializeField] private float forcaPulo = 5.0f;
    [SerializeField] private int chave;
    [SerializeField] private GameObject telaMorte;
    private Vector3 anguloRotacao = new Vector3(0, 90, 0);
    private bool estaVivo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Andar
    public void Andar()
    {
        if(estaVivo)
        {
            float moveV = Input.GetAxis("Vertical");
            Vector3 direcao = moveV * transform.forward;
            rb.MovePosition(rb.position + direcao * velocidade * Time.deltaTime);
        }
    }

    //Pular
    public void Pular()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
    }

    //Virar
    public void Virar()
    {
        float moveH = Input.GetAxis("Horizontal");
        Quaternion rotacao = Quaternion.Euler(anguloRotacao * moveH * Time.deltaTime);
        rb.MoveRotation(rotacao * rb.rotation);
    }

    public bool Vivo()
    {
        return estaVivo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Espinho"))
        {
            estaVivo = false;
            telaMorte.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chave"))
        {
            Destroy(other.gameObject);
            chave++;
        }

        /*if (other.gameObject.CompareTag("PassaFase0"))
        {
            SceneManager.LoadScene("Fase2");
            chaves = 0;
        }*/
    }

}
