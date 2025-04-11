using UnityEngine;
using UnityEngine.EventSystems;

public class UIResizableWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public RectTransform resizeHandle; // Assign in Inspector
    public Vector2 minSize = new Vector2(100, 100);
    public Vector2 maxSize = new Vector2(800, 800);

    private RectTransform rectTransform;
    private Vector2 originalSize;
    private Vector2 originalMousePosition;

    private bool resizing = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(resizeHandle, eventData.position, eventData.pressEventCamera))
        {
            resizing = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out originalMousePosition);
            originalSize = rectTransform.sizeDelta;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!resizing) return;
        Vector2 localMousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localMousePos);
        Vector2 offset = localMousePos - originalMousePosition;
        Vector2 newSize = originalSize + new Vector2(offset.x, -offset.y); // Y reversed due to pivot
        newSize = Vector2.Max(minSize, Vector2.Min(maxSize, newSize));
        rectTransform.sizeDelta = newSize;
    }
}
