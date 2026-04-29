using UnityEngine;

public class LanternaChronos : MonoBehaviour
{
    public GameObject cenarioAtual;
    public GameObject cenarioAntigo;

    private bool mostrandoAntigo = false;

    void Start()
    {
        cenarioAtual.SetActive(true);
        cenarioAntigo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AlternarTempo();
        }
    }

    void AlternarTempo()
    {
        mostrandoAntigo = !mostrandoAntigo;

        cenarioAtual.SetActive(!mostrandoAntigo);
        cenarioAntigo.SetActive(mostrandoAntigo);
    }
}