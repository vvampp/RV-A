using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator LDoor = null;  // Animator para la puerta izquierda
    [SerializeField] private Animator RDoor = null;  // Animator para la puerta derecha

    // Variables para controlar los triggers de apertura y cierre de la puerta izquierda
    [SerializeField] private bool openTriggerL = false;
    [SerializeField] private bool closeTriggerL = false;

    // Variables para controlar los triggers de apertura y cierre de la puerta derecha
    [SerializeField] private bool openTriggerR = false;
    [SerializeField] private bool closeTriggerR = false;

    // Variables de estado para saber si las puertas están abiertas o cerradas
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
                LDoor.SetTrigger("OpenLDoor");  // Activa la animación de apertura para la puerta izquierda
                isLeftDoorOpen = true;
            }
            else if (closeTriggerL && isLeftDoorOpen)
            {
                Debug.Log("closeTriggerL activado. Cerrando puerta izquierda.");
                LDoor.SetTrigger("CloseLDoor");  // Activa la animación de cierre para la puerta izquierda
                isLeftDoorOpen = false;
            }

            // Control de la puerta derecha
            if (openTriggerR && !isRightDoorOpen)
            {
                Debug.Log("openTriggerR activado. Abriendo puerta derecha.");
                RDoor.SetTrigger("OpenRDoor");  // Activa la animación de apertura para la puerta derecha
                isRightDoorOpen = true;
            }
            else if (closeTriggerR && isRightDoorOpen)
            {
                Debug.Log("closeTriggerR activado. Cerrando puerta derecha.");
                RDoor.SetTrigger("CloseRDoor");  // Activa la animación de cierre para la puerta derecha
                isRightDoorOpen = false;
            }
        }
    }
}
