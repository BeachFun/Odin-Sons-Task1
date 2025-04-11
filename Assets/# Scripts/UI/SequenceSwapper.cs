using UnityEngine;

public abstract class SequenceSwapper<T> : MonoBehaviour
{
    [SerializeField] protected T[] m_sequence;

    protected int m_current;

    public abstract void Next();
}
