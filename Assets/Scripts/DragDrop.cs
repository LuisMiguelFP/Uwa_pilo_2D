using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;

    public bool colocado = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (colocado) return;

        startPosition = rectTransform.position;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (colocado) return;

        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (colocado) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Si no se soltó sobre una zona válida → regresar
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<DropZone>() == null)
        {
            rectTransform.position = startPosition;
        }
    }

    // Este método lo llama DropZone si fue incorrecto
    public void VolverAlInicio()
    {
        rectTransform.position = startPosition;
    }
}
