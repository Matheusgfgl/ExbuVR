using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HabilitarVr : MonoBehaviour
{
    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

    void EnableVR()
    {
        StartCoroutine(LoadDevice("CardBoard"));
    }
}
