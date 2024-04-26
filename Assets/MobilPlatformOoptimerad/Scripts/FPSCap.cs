using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCap : MonoBehaviour
{
    [SerializeField] int targetFramerate = 90;
    //This script unlocks the framerate of the Oculus headset
    void Start()
    {
        float[] rates;
        Unity.XR.Oculus.Performance.TryGetAvailableDisplayRefreshRates(out rates);

        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(targetFramerate);

        float rate;
        Unity.XR.Oculus.Performance.TryGetDisplayRefreshRate(out rate);
    }
}
