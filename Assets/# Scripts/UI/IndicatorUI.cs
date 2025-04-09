using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string m_label;
    [Range(0f, 1f), Tooltip("Среднее значение процента")]
    [SerializeField] private float m_precentAvg = .5f;
    [Range(0f, 1f)]
    [SerializeField] private float m_precent;
    [SerializeField] private Sprite m_upSprite;
    [SerializeField] private Sprite m_downSprite;
    [SerializeField] private Color m_backgroundColor = Color.white;

    [Header("Bindings")]
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TMP_Text textPrecent;
    [SerializeField] private UIGradient background;
    [SerializeField] private Image imageIndicator;


    public string Label
    {
        get => m_label;
        set
        {
            m_label = value;

            if (textLabel is not null)
            {
                textLabel.text = value;
            }
        }
    }

    public float Precent
    {
        get => m_precent;
        set
        {
            if (value < 0 || value > 100) return;

            m_precent = value;

            if (textPrecent is not null)
            {
                textPrecent.text = string.Format("{0:P0}", m_precent);
            }

            if (imageIndicator is not null)
            {
                if (m_precent == m_precentAvg) imageIndicator.color = new(0, 0, 0, 0);
                else imageIndicator.color = Color.white;

                if (m_precent > m_precentAvg)
                    imageIndicator.sprite = m_upSprite;
                if (m_precent < m_precentAvg)
                    imageIndicator.sprite = m_downSprite;
            }

            if (background is not null)
            {
                background.gameObject.GetComponent<Image>().fillAmount = m_precent;
            }
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        Label = m_label;
        Precent = m_precent;

        if (background is not null)
        {
            background.m_color1 = m_backgroundColor;
        }
    }
#endif
}
