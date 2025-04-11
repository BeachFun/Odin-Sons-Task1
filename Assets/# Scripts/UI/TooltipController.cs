using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TooltipController : MonoBehaviour, IPointerEnterHandler, IPointerMoveHandler, IPointerExitHandler
{
    [SerializeField] private string tip;
    [SerializeField] private float appearDelay = 4f;
    [SerializeField] private Vector2 offset = new Vector2(20f, 10f);
    [SerializeField] private GameObject tooltipUI; // TODO: временное решение, переделать на инъекции зависимости через DI-контейнер

    private TMP_Text textTooltip;
    private Coroutine m_waitRoutine;


    private void Awake()
    {
        textTooltip = tooltipUI.GetComponent<TMP_Text>() ?? tooltipUI.GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        tooltipUI.SetActive(false);
    }


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (m_waitRoutine is not null)
            StopCoroutine(m_waitRoutine);

        m_waitRoutine = StartCoroutine(Wait());
    }

    void IPointerMoveHandler.OnPointerMove(PointerEventData eventData)
    {
        if (tooltipUI.activeSelf)
        {
            tooltipUI.transform.position = PostionCalc();
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tooltipUI.SetActive(false);

        if (m_waitRoutine is not null)
            StopCoroutine(m_waitRoutine);
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(appearDelay);

        textTooltip.text = tip;
        tooltipUI.SetActive(true);
        tooltipUI.transform.position = PostionCalc();
    }

    private Vector3 PostionCalc()
    {
        Vector3 pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        pos.x += offset.x / 10;
        pos.y += offset.y / 10;

        return pos;
    }
}