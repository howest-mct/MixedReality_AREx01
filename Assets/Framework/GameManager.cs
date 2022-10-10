
using System;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    
    public UnityEvent GoEvent;
    public GameObject CursorPrefab;

    private GameObject cursor = null;
    
    private void Awake()
    {
        if ((instance != null) && (instance != this))
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void ShowCursor_(Vector3 point_)
    {
        if (cursor == null)
        {
            cursor = Instantiate(CursorPrefab);
        }
        cursor.transform.position = point_;
        //cursor.transform.rotation = transform_.rotation;
    }

    private Transform GetCursorPosition_()
    {
        return cursor ? cursor.transform : null;
    }
    
    static public void ShowCursor(Vector3 point_)
    {
        instance.ShowCursor_(point_);
    }
    
    static public void Go()
    {
        instance.GoEvent.Invoke();
    }

    static public Transform GetCursorPosition()
    {
        return instance.GetCursorPosition_();
    }
    
}
