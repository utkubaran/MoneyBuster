using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlassController : MonoBehaviour, IInteractable
{
    private Vector3 stationPos;

    private Vector3 offset;

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
}
