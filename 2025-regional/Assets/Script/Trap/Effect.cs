using UnityEngine;
public class Effect : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            Destroy(transform.GetChild(0).gameObject, particleSystem.main.duration / particleSystem.main.simulationSpeed);
        }
    }
}