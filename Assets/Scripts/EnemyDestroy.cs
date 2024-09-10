using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] UnityEvent actions;
    int destorytime = 2;
    void Start()
    {
        actions.Invoke();
        Destroy(gameObject, destorytime);
    }
}
