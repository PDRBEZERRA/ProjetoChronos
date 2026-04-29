using UnityEngine;

public class DevCameraControl: MonoBehaviour
{

    //APENAS PARA DESENVOLVIMENTO

    [Header("Configurações de Rotação")]
    public float sensibilidadeMouse = 200f;
    private float rotacaoX = 0f;

    [Header("Configurações de Movimento")]
    public float velocidadeMovimento = 5f;
    public float velocidadeVertical = 3f;

    void Start()
    {
        //Se o VR estiver ativo e rodando, desativa este script
        if (UnityEngine.XR.XRSettings.enabled)
        {
            this.enabled = false;
            return;
        }

        // Esconde o cursor do mouse e trava ele no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // --- ROTAÇÃO (MOUSE) ---
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); // Impede de dar um "loop" vertical

        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f); // Cima/Baixo
        transform.parent.Rotate(Vector3.up * mouseX); // Esquerda/Direita (Gira o corpo)

        // --- MOVIMENTO ---
        float moverX = Input.GetAxis("Horizontal"); // A e D
        float moverZ = Input.GetAxis("Vertical");   // W e S

        float moverY = 0f;
        if (Input.GetKey(KeyCode.Space)) moverY = 1f; //Sobe
        if (Input.GetKey(KeyCode.LeftShift)) moverY = -1f; //Desce

        Vector3 movimentoHorizontal = transform.right * moverX + transform.forward * moverZ;
        Vector3 movimentoVertical = Vector3.up * moverY;
        transform.parent.position += ((movimentoHorizontal * velocidadeMovimento) + (movimentoVertical * velocidadeVertical)) * Time.deltaTime;

        // Atalho para soltar o mouse se precisar (tecla Esc)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
