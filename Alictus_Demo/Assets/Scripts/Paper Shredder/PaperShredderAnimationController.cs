using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperShredderAnimationController : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        EventManager.OnMoneyInShredder.AddListener(PlayShredAnimation);
    }

    private void OnDisable()
    {
        EventManager.OnMoneyInShredder.RemoveListener(PlayShredAnimation);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayShredAnimation()
    {
        animator?.SetTrigger("MoneyShredStart");
    }
}
