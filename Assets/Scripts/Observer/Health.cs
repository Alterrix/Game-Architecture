using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Level level;

    [SerializeField] private float fullhealth = 100f;
    [SerializeField] private float drainPerSecond = 2f;
    private float currentHealth = 0;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void OnEnable()
    {
        level.onLevelUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        level.onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    private void ResetHealth()
    {
        currentHealth = fullhealth;
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
}

