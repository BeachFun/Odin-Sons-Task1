using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorSwitch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color m_color = Color.yellow;

    private Color m_imageInitColor;
    private Color m_textInitColor;
    private Image image;
    private TMP_Text text;


    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TMP_Text>();

        if (image is not null)
            m_imageInitColor = image.color;
        if (text is not null)
            m_textInitColor = text.color;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (image is not null)
            image.color = m_color;
        if (text is not null)
            text.color = m_color;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (image is not null)
            image.color = m_imageInitColor;
        if (text is not null)
            text.color = m_textInitColor;
    }
}
