using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, IInteractable
{
    [SerializeField]
    private MoneyData.MoneyValidity moneyValidity;

    private Vector3 stationPos;

    private void Start()
    {
        stationPos = transform.position;
    }

    public void OnDrag()
    {
        return;
    }

    public void GoBackStation()
    {
        LeanTween.move(this.gameObject, stationPos, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isMoneyStack = other.GetComponent<MoneyStackHolder>();
        bool isPaperShredder = other.GetComponent<PaperShredder>();

        if (moneyValidity == MoneyData.MoneyValidity.Valid && isMoneyStack)
        {

        }
        else if (moneyValidity == MoneyData.MoneyValidity.Invalid && isPaperShredder)
        {
            
        }
    }
}
