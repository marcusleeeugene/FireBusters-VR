using Valve.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerTeleportScript : MonoBehaviour
{
    public AudioSource teleportAudio;

    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;

    public float initialHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
    }

    public void TryLaser(SteamVR_Behaviour_Pose controllerPose)
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
        {
            if(hit.transform.tag == "Ground"){  // || hit.transform.tag == "UnlockedLevel") {
                hitPoint = hit.point;
                ShowLaser(hit, controllerPose);
            }
        }
    }

    public void DisableLaser()
    {
        laser.SetActive(false);
        reticle.SetActive(false);
    }

    public bool ShouldTeleport()
    {
        return shouldTeleport;
    }

    public void Teleport()
    {
        teleportAudio.Play();
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = initialHeight;
        // difference.y = cameraRigTransform.position.y - hitPoint.y;
        cameraRigTransform.position = hitPoint + difference;

        // difference.y = Math.Min(headTransform.position.y-cameraRigTransform.position.y, 0);
        // hitPoint.y += 0f;
        
        // cameraRigTransform.position = hitPoint;
    }

    private void ShowLaser(RaycastHit hit, SteamVR_Behaviour_Pose controllerPose)
    {
        laser.SetActive(true);
        reticle.SetActive(true);
        teleportReticleTransform.position = hitPoint + teleportReticleOffset;
        shouldTeleport = true;
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
}
