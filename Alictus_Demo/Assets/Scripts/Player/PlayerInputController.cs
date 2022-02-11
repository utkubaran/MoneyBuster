using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private float yOffset = 35f;

    private GameObject selectedObject;

    private Camera mainCam;

    private bool isPlaying;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
        EventManager.OnLevelFinish.AddListener( () => isPlaying = false );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFail.RemoveListener( () => isPlaying = false );
        EventManager.OnLevelFinish.RemoveListener( () => isPlaying = false );
    }

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Start()
    {
        isPlaying = true;       // todo delete after events are enabled
    }

    void Update()
    {
        DragObject();
    }

    private void DragObject()
    {
        if (!isPlaying) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();
                bool isMagnifyingGlass = hit.transform.GetComponent<MagnifyingGlassController>();
                bool isUVLight = hit.transform.GetComponent<UVLightController>();
                bool isMoney = hit.transform.GetComponent<Money>();

                if(!isMagnifyingGlass && !isUVLight && !isMoney) return;

                selectedObject = hit.transform.gameObject;
            }
        }
        else if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            if (selectedObject.GetComponent<Money>())
            {
                selectedObject.GetComponent<Money>().IsReleased = true;
            }
            
            selectedObject.GetComponent<IInteractable>().GoBackStation();
            selectedObject = null;
        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = mainCam.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, yOffset, worldPosition.z);
            selectedObject.GetComponent<IInteractable>()?.OnDrag();
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane);
        
        Vector3 worldMousePosFar = mainCam.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = mainCam.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);      // todo add layermask
        return hit;
    }
}
