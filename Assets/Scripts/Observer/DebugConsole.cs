using System.Collections;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    private IEnumerator Start()
    {
        Health[] health = FindObjectsOfType<Health>();
        Level level = GetComponent<Level>();

        while (true)
        {
            yield return new WaitForSeconds(1);

            Debug.Log($"Exp: {level.GetExperience()}, Level: {level.GetLevel()}");

            //Debugs all observers health
            for (int i = 0; i < health.Length; i++)
            {
                Debug.Log("Player" + i + $" Health: {health[i].GetHealth()}");
            }
        }
    }
}
