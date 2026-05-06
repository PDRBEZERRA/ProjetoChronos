using UnityEngine;
using static VRDetector;
public class DevCameraControl: MonoBehaviour
{

    //APENAS PARA DESENVOLVIMENTO

    [Header("Configurações de Rotação")]
    public float sensibilidadeMouse = 200f;
    private float rotacaoX = 0f;

    [Header("Configurações de Movimento")]
    public float velocidadeMovimento = 5f;
    public float velocidadeVertical = 3f;

    private GameObject playerObject;
    private VRDetector vrDetector;

    void Start()
    {
        Debug.Log("Game Control initialized, checking for VR Controller...");
        Debug.Log(UnityEngine.XR.XRSettings.enabled);
        //Se o VR estiver ativo e rodando, desativa este script
        if (vrDetector.IsVREnabled())
        {
            this.enabled = false;
            Debug.Log("VR controller detected, deactivating default controls.");
            return;
        }

        Debug.Log("VR Controller not detected, using default mouse and keyboard control.");

        //Obtem o Objeto Player
        playerObject = transform.parent.parent.parent.gameObject;

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

        playerObject.transform.Rotate(Vector3.up * mouseX);

        // --- MOVIMENTO ---
        float moverX = Input.GetAxis("Horizontal"); // A e D
        float moverZ = Input.GetAxis("Vertical");   // W e S

        float moverY = 0f;
        if (Input.GetKey(KeyCode.Space)) moverY = 1f; //Sobe
        if (Input.GetKey(KeyCode.LeftShift)) moverY = -1f; //Desce

        // Movimenta o player com base na camera
        Vector3 movimentoHorizontal = (transform.right * moverX) + (transform.forward * moverZ);
        movimentoHorizontal.y = 0;

        Vector3 movimentoVertical = Vector3.up * moverY;

        playerObject.transform.position += ((movimentoHorizontal * velocidadeMovimento) + (movimentoVertical * velocidadeVertical)) * Time.deltaTime;

        // Atalho para soltar o mouse se precisar (tecla Esc)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
