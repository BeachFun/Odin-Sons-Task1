using TMPro;

public class TextSwapper : SequenceSwapper<string>
{
    private TMP_Text textLabel;

    private void Awake()
    {
        textLabel = GetComponent<TMP_Text>();
        textLabel.text = m_sequence[m_current];
    }

    public override void Next()
    {
        m_current = (m_current + 1) % m_sequence.Length;
        textLabel.text = m_sequence[m_current];
    }
}