using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private bool m_isSoundOn = true;
    [SerializeField] private AudioListener playerListener;


    public void SwitchSound()
    {
        m_isSoundOn = !m_isSoundOn;

        playerListener.enabled = m_isSoundOn;
    }
}
