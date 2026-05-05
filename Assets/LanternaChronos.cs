using UnityEngine;
using UnityEngine.InputSystem;

public class LanternaChronos : MonoBehaviour
{
    public GameObject cenarioAtual;
    public GameObject cenarioAntigo;

    // Nova variável para receber a ação do Input System
    public InputActionReference acaoTrocarCenario;

    private bool mostrandoAntigo = false;

    void Start()
    {
        cenarioAtual.SetActive(true);
        cenarioAntigo.SetActive(false);
    }

    // O Update foi removido. Agora usamos OnEnable para "ligar" a escuta do botão
    private void OnEnable()
    {
        if (acaoTrocarCenario != null)
        {
            acaoTrocarCenario.action.Enable();
            
            acaoTrocarCenario.action.performed += AlternarTempo;
        }
    }

    // Usamos OnDisable para "desligar" a escuta e evitar erros na memória
    private void OnDisable()
    {
        if (acaoTrocarCenario != null)
        {
            acaoTrocarCenario.action.Disable();
            
            acaoTrocarCenario.action.performed -= AlternarTempo;
        }
    }

    // A função agora recebe o CallbackContext do Input System
    void AlternarTempo(InputAction.CallbackContext context)
    {
        mostrandoAntigo = !mostrandoAntigo;

        cenarioAtual.SetActive(!mostrandoAntigo);
        cenarioAntigo.SetActive(mostrandoAntigo);
    }
}