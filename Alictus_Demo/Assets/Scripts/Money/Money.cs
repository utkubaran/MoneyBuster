using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, IInteractable
{
    [SerializeField]
    private MoneyData.MoneyValidity moneyValidity;

    private MoneyAnimationController moneyAnimationController;

    private Vector3 stationPos;

    private bool isReleased;
    public bool IsReleased { set { isReleased = value; } }

    private void Awake()
    {
        moneyAnimationController = GetComponent<MoneyAnimationController>();
    }

    private void Start()
    {
        stationPos = transform.position;
        isReleased = false;
    }

    public void OnDrag()
    {
        return;
    }

    public void GoBackStation()
    {
        return;
        // LeanTween.move(this.gameObject, stationPos, 0.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isReleased) return;

        isReleased = false;
        bool isMoneyStack = other.GetComponent<MoneyStackHolder>();
        bool isPaperShredder = other.GetComponent<PaperShredder>();

        if (isPaperShredder)
        {
            EventManager.OnMoneyInShredder?.Invoke();

            if (moneyValidity == MoneyData.MoneyValidity.Invalid)
            {
                EventManager.OnCorrectCheck?.Invoke();
            }

            PlaceToShredder();
        }
        else if (isMoneyStack)
        {
            EventManager.OnMoneyInStack?.Invoke();

            if (moneyValidity == MoneyData.MoneyValidity.Valid)
            {
                EventManager.OnCorrectCheck?.Invoke();
            }

            AddToStack();
        }

        EventManager.OnCheckCompleted?.Invoke();
    }

    private void PlaceToShredder()
    {
        LeanTween.move(this.gameObject, new Vector3(-35f, 7.5f, -9f), 0.25f);
        LeanTween.rotate(this.gameObject, new Vector3(0f, -90f, 0f), 0.25f);
        GetComponent<Collider>().enabled = false;
        moneyAnimationController.PlayShredAnimation();
        Destroy(this.gameObject, 1.5f);
    }

    private void AddToStack()
    {
        LeanTween.move(this.gameObject, new Vector3(35f, 8.5f, 32.5f), 0.25f);
        LeanTween.rotate(this.gameObject, new Vector3(0f, 90f, 0f), 0.25f);
        GetComponent<Collider>().enabled = false;
    }
}
