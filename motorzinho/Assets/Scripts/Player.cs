using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;

    public int forcaPulo = 7;
    public bool noChao;
    private Rigidbody rb;

    void Start()
    {
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        noChao = true;

    }

    void Update()
    {
        //controles do jogador
        float h = Input.GetAxis("Horizontal"); //-1 esquerda,0 nada, 1 direita
        float v = Input.GetAxis("Vertical");// -1 pra tras, 0 nada, 1 pra frente

        //movimentação
        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        //pulo
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }


        //reiniciando cena quando jogador cai
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
