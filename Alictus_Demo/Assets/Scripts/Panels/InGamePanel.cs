using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private TextMeshProUGUI currentMoneyText;

    private int currentMoney;

    private void OnEnable()
    {
        EventManager.OnCorrectCheck.AddListener(UpdateMoneyCounter);
    }

    private void OnDisable()
    {
        EventManager.OnCorrectCheck.RemoveListener(UpdateMoneyCounter);  
    }

    void Start()
    {
        levelText.text = "LEVEL " + (LevelManager.instance.CurrentSceneIndex + 1).ToString();
        currentMoney = 0;
        currentMoneyText.text = currentMoney.ToString();
    }

    private void UpdateMoneyCounter()
    {
        currentMoney += 10;
        currentMoneyText.text = currentMoney.ToString();
        StartCoroutine(PlayMoneyCounterAnimation());
    }

    private IEnumerator PlayMoneyCounterAnimation()
    {
        LeanTween.scale(currentMoneyText.gameObject, Vector3.one * 1.5f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.scale(currentMoneyText.gameObject, Vector3.one, 0.5f);
    }
}
