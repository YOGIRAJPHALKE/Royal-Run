using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 60f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;
    [SerializeField] ParticleSystem SpeedupParticleSystem;
    CinemachineCamera cinemachineCamera;

    void Awake()
    {
     cinemachineCamera = GetComponent<CinemachineCamera>();   
        
    }

    public void ChangeCameraFOV(float SpeedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(SpeedAmount));
        if(SpeedAmount>0)
        {
            SpeedupParticleSystem.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float SpeedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;

        float targetFOV = Mathf.Clamp(startFOV + zoomSpeedModifier * SpeedAmount,minFOV,maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime/zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV,targetFOV,t);
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
