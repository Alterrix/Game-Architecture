using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public event Action onLevelUpAction;
    [SerializeField] private UnityEvent onLevelUp;

    [SerializeField] private int pointPerLevel = 200;
    private int experiencePoints;

    //loop gain experience
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int _points)
    {
        int level = GetLevel();
        experiencePoints += _points;

        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
            if (onLevelUpAction != null)
            {
                onLevelUpAction();
            }
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointPerLevel;
    }
}
