using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public Light targetLight;  
    public Transform player;   
    public ParticleSystem fireParticles; 

    public float activationDistance = 5f; 

    private bool isLightOn = true;

    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

       
        if (distanceToPlayer < activationDistance && isLightOn)
        {
            targetLight.enabled = false; 
            fireParticles.Stop();
            isLightOn = false;
        }

    }
}
