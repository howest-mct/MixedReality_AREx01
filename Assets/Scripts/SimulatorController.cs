using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatorController : MonoBehaviour
{
    public GameObject AppManager;

#if UNITY_EDITOR

    private Camera cam;
    private Vector2 mouse_position = new Vector2();

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.Skybox;
    }

    public void MoveForward(float speed)
    {
        transform.localPosition += transform.TransformDirection(Vector3.forward * speed * Time.deltaTime);
    }

    public void MoveBackward(float speed)
    {
        transform.localPosition += transform.TransformDirection(Vector3.back * speed * Time.deltaTime);
    }

    public void MoveLeft(float speed)
    {
        transform.localPosition += transform.TransformDirection(Vector3.left * speed * Time.deltaTime);
    }

    public void MoveRight(float speed)
    {
        transform.localPosition += transform.TransformDirection(Vector3.right * speed * Time.deltaTime);
    }

    public void SetRotation(float xrot, float yrot)
    {
        transform.localRotation = Quaternion.Euler(xrot, yrot, 0.0f);
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.Repaint)
        {
            mouse_position.x = e.mousePosition.x;
            mouse_position.y = Screen.height - e.mousePosition.y;
        }
    }

    void Update()
    {

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(mouse_position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.scene.name == "Simulator")
            {
                if (Input.GetMouseButton(1))
                {
                    GameManager.ShowCursor(hit.point);
                }
            }
        }

    }


#endif

}