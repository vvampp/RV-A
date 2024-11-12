using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    public Light torchLight;
    public float minIntensity = 1.0f;
    public float maxIntensity = 3.0f;
    public float flickerSpeed = 0.1f;

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0.0f);
        torchLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
