using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    private GameObject[] moneys;

    private int moneyCount;

    private bool isFinished;

    private void OnEnable()
    {
        EventManager.OnCheckCompleted.AddListener( () => moneyCount-- );
    }

    private void OnDisable()
    {
        EventManager.OnCheckCompleted.AddListener( () => moneyCount-- );
    }

    void Start()
    {
        moneys = GameObject.FindGameObjectsWithTag("Money");
        moneyCount = moneys.Length;
    }

    private void Update()
    {
        if (moneyCount <= 0 && !isFinished)
        {
            isFinished = true;
            StartCoroutine(AnounceLevelFinish());
        }
    }

    private IEnumerator AnounceLevelFinish()
    {
        yield return new WaitForSeconds(1f);
        EventManager.OnLevelFinish?.Invoke();
    }
}
