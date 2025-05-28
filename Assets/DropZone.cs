using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string objetoEsperado;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject arrastrado = eventData.pointerDrag;

        if (arrastrado != null && arrastrado.tag == objetoEsperado)
        {
            // Posiciona el objeto y lo bloquea
            arrastrado.transform.position = transform.position;

            DragDrop drag = arrastrado.GetComponent<DragDrop>();
            if (drag != null)
            {
                drag.colocado = true;
            }

            // Feedback opcional
            GetComponent<UnityEngine.UI.Image>().color = Color.green;
        }
        else
        {
            // Si es incorrecto, devolver al inicio
            if (arrastrado != null)
            {
                DragDrop drag = arrastrado.GetComponent<DragDrop>();
                if (drag != null)
                {
                    drag.VolverAlInicio();
                }
            }
        }
    }
}
