using UnityEngine;

public class HealthTest : MonoBehaviour
{
    private HealthSystemForDummies health;

    void Start()
    {
        health = GetComponent<HealthSystemForDummies>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Mất 100 máu!");
            health.AddToCurrentHealth(-100); // mất máu
        }

    }
}
