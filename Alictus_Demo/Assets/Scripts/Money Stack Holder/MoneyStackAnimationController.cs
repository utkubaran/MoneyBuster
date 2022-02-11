using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStackAnimationController : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => animator?.SetTrigger("LevelStart") );
        EventManager.OnMoneyInStack.AddListener(PlayAddingStackAnimation);
        EventManager.OnLevelFinish.AddListener( () => animator?.SetTrigger("LevelCompleted") );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => animator?.SetTrigger("LevelStart") );
        EventManager.OnMoneyInStack.RemoveListener(PlayAddingStackAnimation);
        EventManager.OnLevelFinish.RemoveListener( () => animator?.SetTrigger("LevelCompleted") );
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void PlayAddingStackAnimation()
    {
        animator.SetTrigger("AddMoney");
    }
}
