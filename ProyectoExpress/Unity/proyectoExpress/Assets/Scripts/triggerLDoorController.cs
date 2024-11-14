using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator LDoor = null;  // Animator para la puerta izquierda
    [SerializeField] private Animator RDoor = null;  // Animator para la puerta derecha

    [SerializeField] private AudioSource audioSource = null;  // Componente AudioSource para reproducir sonidos
    [SerializeField] private AudioClip openDoorSound;  // Clip de audio que se reproducirá al abrir la puerta

    [SerializeField] private bool openTriggerL = false;
    [SerializeField] private bool closeTriggerL = false;

    [SerializeField] private bool openTriggerR = false;
    [SerializeField] private bool closeTriggerR = false;

    private bool isLeftDoorOpen = false;
    private bool isRightDoorOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Control de la puerta izquierda
            if (openTriggerL && !isLeftDoorOpen)
            {
                Debug.Log("openTriggerL activado. Abriendo puerta izquierda.");
                LDoor.SetTrigger("OpenLDoor");
                audioSource.PlayOneShot(openDoorSound);  // Reproduce el sonido de abrir puerta
                isLeftDoorOpen = true;
            }
            else if (closeTriggerL && isLeftDoorOpen)
            {
                Debug.Log("closeTriggerL activado. Cerrando puerta izquierda.");
                LDoor.SetTrigger("CloseLDoor");
                isLeftDoorOpen = false;
            }

            // Control de la puerta derecha
            if (openTriggerR && !isRightDoorOpen)
            {
                Debug.Log("openTriggerR activado. Abriendo puerta derecha.");
                RDoor.SetTrigger("OpenRDoor");
                audioSource.PlayOneShot(openDoorSound);  // Reproduce el sonido de abrir puerta
                isRightDoorOpen = true;
            }
            else if (closeTriggerR && isRightDoorOpen)
            {
                Debug.Log("closeTriggerR activado. Cerrando puerta derecha.");
                RDoor.SetTrigger("CloseRDoor");
                isRightDoorOpen = false;
            }
        }
    }
}
