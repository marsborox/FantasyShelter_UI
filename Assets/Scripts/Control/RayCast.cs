using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RayCast_UI : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster m_Raycaster;
    [SerializeField] private EventSystem m_EventSystem;
    PointerEventData m_PointerEventData;

    void Start()
    {
        /*//Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();*/
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("LMB pressed in rayCast");
            //CastRay();
            RayCastGraphics();
        }
    }
    private /*static*/ void CastRay()
    {//physics raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        DrawRaycastLine(ray);
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.white, 50f);
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.collider.name);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
    private void DrawRaycastLine(Ray ray)
    {
        //draw line for debugging
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.white, 50f);
    }
    void RayCastGraphics()
    {
        //Check if the left Mouse button is clicked
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            Debug.Log("Hit " + result.gameObject.name);
            try
            {
                result.gameObject.GetComponent<IOnRayHit_UI>().RMBClick();
            }
            catch { }
        }
    }
}
