using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGamePanel;

    [SerializeField]
    private GameObject tapToPlayPanel;

    [SerializeField]
    private GameObject levelFinishPanel;

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => tapToPlayPanel.SetActive(true) );
        EventManager.OnSceneStart.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnSceneStart.AddListener( () => levelFinishPanel.SetActive(false) );

        EventManager.OnLevelStart.AddListener( () => tapToPlayPanel.SetActive(false) );
        EventManager.OnLevelStart.AddListener( () => inGamePanel.SetActive(true) );
        EventManager.OnLevelStart.AddListener( () => levelFinishPanel.SetActive(false) );

        EventManager.OnLevelFinish.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnLevelFinish.AddListener( () => levelFinishPanel.SetActive(true) );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => tapToPlayPanel.SetActive(true) );
        EventManager.OnSceneStart.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnSceneStart.RemoveListener( () => levelFinishPanel.SetActive(false) );

        EventManager.OnLevelStart.RemoveListener( () => tapToPlayPanel.SetActive(false) );
        EventManager.OnLevelStart.RemoveListener( () => inGamePanel.SetActive(true) );
        EventManager.OnLevelStart.RemoveListener( () => levelFinishPanel.SetActive(false) );

        EventManager.OnLevelFinish.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnLevelFinish.RemoveListener( () => levelFinishPanel.SetActive(true) );
    }

    public void PressTapToPlayButton()
    {
        EventManager.OnTapToPlayButtonPressed?.Invoke();
    }

    public void PressNextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }
}
