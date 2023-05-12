using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_TriggerObjectType
{
    Coin = 0,
    Goal,
    Obstacle,
    Checkpoint
}

public class TriggerObject : MonoBehaviour
{
    [SerializeField]
    ScriptableEvent triggerEvent;

    [SerializeField]
    bool setInactiveWhenTrigger = true;

    [SerializeField]
    E_TriggerObjectType triggerObjType;

    [SerializeField]
    ScriptableInt playerCollisionLayer;

    public E_TriggerObjectType GetTriggerObjType { get => triggerObjType; }

    private void Start()
    {
        LevelManager.Instance.SubscribeTriggerObject(this);
    }


    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.layer != playerCollisionLayer.DefaultValue)
            return;

        triggerEvent.RaiseEvent();
        if (setInactiveWhenTrigger)
            gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.layer != playerCollisionLayer.DefaultValue)
            return;

        if (this.enabled == false)
            return;

        triggerEvent.RaiseEvent();
        if (setInactiveWhenTrigger)
            gameObject.SetActive(false);
    }
}
