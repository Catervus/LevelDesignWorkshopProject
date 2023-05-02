using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_TriggerObjectType
{
    Coin = 0,
    Goal,
}

public class TriggerObject : MonoBehaviour
{
    [SerializeField]
    ScriptableEvent triggerEvent;

    [SerializeField]
    bool setInactiveWhenTrigger = true;

    [SerializeField]
    E_TriggerObjectType triggerObjType;

    public E_TriggerObjectType GetTriggerObjType { get => triggerObjType; }

    private void Start()
    {
        LevelManager.Instance.SubscribeTriggerObject(this);
    }


    private void OnTriggerEnter(Collider _other)
    {
        triggerEvent.RaiseEvent();
        if (setInactiveWhenTrigger)
            gameObject.SetActive(false);

    }
}
