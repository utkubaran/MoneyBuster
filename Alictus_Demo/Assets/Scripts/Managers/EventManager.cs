using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnSceneStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnSceneFinish = new UnityEvent();
    #endregion

    #region Money Events
    public static UnityEvent OnMoneyInShredder = new UnityEvent();
    public static UnityEvent OnMoneyInStack = new UnityEvent();
    public static UnityEvent OnCheckCompleted = new UnityEvent();
    public static UnityEvent OnCorrectCheck = new UnityEvent();
    #endregion
}
