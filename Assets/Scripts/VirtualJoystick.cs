using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickKnob;
    [SerializeField] private float moveFactor;

    private Vector3 _move;
    private Vector3 _touchPosition;

    private void Start()
    {
        HideJoystick();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowJoystick();
        _touchPosition = eventData.position;
        joystickBackground.position = _touchPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HideJoystick();
        _move = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateJoystickPosition(eventData.position);
    }

    private void UpdateJoystickPosition(Vector3 currentPosition)
    {
        Vector3 direction = currentPosition - _touchPosition;

        float canvasYScale = GetCanvasYScale();
        float moveMagnitude = direction.magnitude * moveFactor * canvasYScale;

        float newWidth = joystickBackground.rect.width / 2 * canvasYScale;
        moveMagnitude = Mathf.Min(moveMagnitude, newWidth);

        _move = direction.normalized * moveMagnitude;

        Vector3 targetPos = _touchPosition + _move;
        joystickKnob.position = targetPos;
    }

    public Vector3 GetMovePosition()
    {
        return _move;
    }

    private float GetCanvasYScale()
    {
        return GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
    }

    private void ShowJoystick()
    {
        joystickBackground.gameObject.SetActive(true);
    }

    private void HideJoystick()
    {
        joystickBackground.gameObject.SetActive(false);
    }
}