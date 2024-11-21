using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR.Input;

public class LightToggle : MonoBehaviour
{
    public Light targetLight;
    public Transform player;
    public ParticleSystem fireParticles;
    public float activationDistance = 5f;

    public AudioSource chirpingAudioSource;  // AudioSource para el sonido en loop
    public AudioClip stinguishClip;           // AudioClip para el sonido que se reproducirá una vez

    private bool isLightOn = true;

    void Start()
    {

        // Si el campo player no está asignado, buscar el CenterEyeAnchor del OVRCameraRig
        if (player == null)
        {
            GameObject ovrCameraRig = GameObject.Find("OVRCameraRig");
            if (ovrCameraRig != null)
            {
                player = ovrCameraRig.transform.Find("TrackingSpace/CenterEyeAnchor");
            }
        }

        // Configurar el AudioSource para reproducir en loop
        chirpingAudioSource.loop = true;
        chirpingAudioSource.Play();  // Comenza a reproducir el sonido en loop cuando se inicie el juego

    }

    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro de la distancia de activación y la luz está encendida
        if (distanceToPlayer < activationDistance && isLightOn)
        {
            // Si el jugador presiona el botón se apaga la luz
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                targetLight.enabled = false;
                fireParticles.Stop();
                isLightOn = false;

                // Detener el sonido de chirping y reproducir el sonido de stinguish
                chirpingAudioSource.Stop();
                chirpingAudioSource.PlayOneShot(stinguishClip);
            }
        }
    }
}