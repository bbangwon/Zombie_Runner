using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    
    [SerializeField] float zoomOut = 60f;    
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOutSensitivity = 1f;
    [SerializeField] float zoomInSensitivity = 0.25f;

    bool zoomedInToggle = false;

    StarterAssetsInputs starterAssetsInputs;

    private void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.m_Lens.FieldOfView = zoomIn;
                starterAssetsInputs.lookSenstivity = zoomInSensitivity;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.m_Lens.FieldOfView = zoomOut;
                starterAssetsInputs.lookSenstivity = zoomOutSensitivity;
            }            
        }
    }
}
