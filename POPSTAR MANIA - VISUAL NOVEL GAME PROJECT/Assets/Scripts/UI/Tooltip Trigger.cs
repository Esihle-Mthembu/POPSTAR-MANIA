using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler

{
    [TextArea]
    public string tooltipMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover detected");
        TooltipSystem.Instance.Show(tooltipMessage);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Instance.Hide();
    }
}
