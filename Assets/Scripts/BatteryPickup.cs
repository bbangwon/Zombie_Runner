using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FlashLightSystem flashLightSystem = other.GetComponentInChildren<FlashLightSystem>();
            if(flashLightSystem != null)
            {
                flashLightSystem.RestoreLightAngle(restoreAngle);
                flashLightSystem.AddLightIntensity(addIntensity);
                Destroy(gameObject);
            }
        }
    }
}
