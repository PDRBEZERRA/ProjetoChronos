using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRDetector : MonoBehaviour
{
    void Start()
    {

    }
    public bool IsVREnabled()
    {
        var displaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetSubsystems(displaySubsystems);

        foreach (var subsystem in displaySubsystems)
        {
            if (subsystem.running) return true;
        }
        return false;
    }
}
