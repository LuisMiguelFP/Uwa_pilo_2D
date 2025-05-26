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
            arrastrado.transform.position = transform.position;
            Debug.Log("¡Correcto!");
        }
        else
        {
            Debug.Log("Incorrecto");
        }
    }
}