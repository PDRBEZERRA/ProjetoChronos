using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChronosLantern : MonoBehaviour
{
    [Header("Components to Toggle")]
    public GameObject lightSource;    // The Spotlight
    public GameObject stencilCone;    // The Mesh with the StencilMask material

    [Header("Settings")]
    public bool isOnByDefault = false;

    private bool _isCurrentlyOn;

    void Start()
    {
        // Set initial state
        _isCurrentlyOn = isOnByDefault;
        ApplyState();
    }

    // This function will be called by the XR Grab Interactable
    public void ToggleLantern()
    {
        _isCurrentlyOn = !_isCurrentlyOn;
        ApplyState();
    }

    private void ApplyState()
    {
        if (lightSource != null) lightSource.SetActive(_isCurrentlyOn);
        if (stencilCone != null) stencilCone.SetActive(_isCurrentlyOn);

        // Optional: Add a click sound here
    }
}
