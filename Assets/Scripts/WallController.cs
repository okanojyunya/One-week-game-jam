using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallController : MonoBehaviour
{
    [SerializeField] UnityEvent _actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _actions.Invoke();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
