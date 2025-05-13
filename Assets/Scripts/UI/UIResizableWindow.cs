using UnityEngine;
using UnityEngine.EventSystems;

public class UIResizableWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public RectTransform resizeHandle; // Assign in Inspector
    public Vector2 minSize = new Vector2(100, 100);
    public Vector2 maxSize = new Vector2(800, 800);

    private RectTransform _rectTransform;
    private Vector2 _originalSize;
    private Vector2 _originalMousePosition;

    private bool _resizing = false;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(resizeHandle, eventData.position, eventData.pressEventCamera))
        {
            _resizing = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, eventData.position, eventData.pressEventCamera, out _originalMousePosition);
            _originalSize = _rectTransform.sizeDelta;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_resizing) return;
        Vector2 localMousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, eventData.position, eventData.pressEventCamera, out localMousePos);
        Vector2 offset = localMousePos - _originalMousePosition;
        Vector2 newSize = _originalSize + new Vector2(offset.x, -offset.y); // Y reversed due to pivot
        newSize = Vector2.Max(minSize, Vector2.Min(maxSize, newSize));
        _rectTransform.sizeDelta = newSize;
    }
}
