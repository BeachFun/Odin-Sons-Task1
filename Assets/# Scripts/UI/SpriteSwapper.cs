using UnityEngine;
using UnityEngine.UI;

public class SpriteSwapper : SequenceSwapper<Sprite>
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = m_sequence[m_current];
    }

    public override void Next()
    {
        m_current = (m_current + 1) % m_sequence.Length;
        image.sprite = m_sequence[m_current];
    }
}
