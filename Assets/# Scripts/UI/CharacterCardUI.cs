using DG.Tweening;
using Spine;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("General")]
    [SerializeField] private bool m_isBackSide;
    [SerializeField] private float m_flipDuration;
    [SerializeField] private bool m_isAnimated;

    [Header("Base")]
    [SerializeField] private Sprite m_spriteFrontBackground;
    [SerializeField] private Sprite m_spriteBackBackground;
    [Space]
    [SerializeField] private Image imageBackground;
    [SerializeField] private GameObject frontSide;
    [SerializeField] private GameObject backSide;

    [Header("Family Name")]
    [SerializeField] private string m_familyName;
    [Space]
    [SerializeField] private TMP_Text textFrontFamilyName;

    [Header("Character Name")]
    [SerializeField] private string m_name;
    [Space]
    [SerializeField] private TMP_Text textFrontName;
    [SerializeField] private TMP_Text textBackName;

    [Header("Character Description")]
    [SerializeField] private string m_descriptin;
    [Space]
    [SerializeField] private TMP_Text textDescription;

    [Header("Family Rune")]
    [SerializeField] private Sprite m_spriteFamilyRune;
    [Space]
    [SerializeField] private Image imageFamilyRune1;
    [SerializeField] private Image imageFamilyRune2;

    [Header("Family Rune Perc")]
    [SerializeField] private string m_perc1Format = "Фамильная руна:\n{0}";
    [SerializeField] private string m_perc1Name;
    [SerializeField] private TMP_Text textPerc1;
    [Space]
    [SerializeField] private Image imagePerc1;

    [Header("Ace Aspect Perc")]
    [SerializeField] private string m_perc2Format = "Аспект асов:\n{0}";
    [SerializeField] private string m_perc2Name;
    [SerializeField] private Sprite m_spritePerc2;
    [Space]
    [SerializeField] private TMP_Text textPerc2;
    [SerializeField] private Image imagePerc2;

    [Header("Indicators")]
    [SerializeField] private IndicatorUI indicator1;
    [SerializeField] private IndicatorUI indicator2;
    [SerializeField] private IndicatorUI indicator3;

    [Header("Person")]
    [SerializeField] private Sprite m_spritePerson;
    [SerializeField] private SkeletonDataAsset m_skeletonPersonDA;
    [Space]
    [SerializeField] private Image imagePerson;
    [SerializeField] private SkeletonGraphic skeletonPerson;

    [Header("Avatar")]
    [SerializeField] private Sprite m_spriteAvatarBorder;
    [SerializeField] private Sprite m_spriteAvatarBackground;
    [SerializeField] private Sprite m_spriteAvatar;
    [SerializeField] private SkeletonDataAsset m_skeletonAvatarDA;
    [Space]
    [SerializeField] private Image imageAvatarBorder;
    [SerializeField] private Image imageAvatarBackground;
    [SerializeField] private Image imageAvatar;
    [SerializeField] private SkeletonGraphic skeletonAvatar;

    [Header("Avatar rune GFX")]
    [SerializeField] private SkeletonDataAsset m_skeletonRuneDA;
    [Space]
    [SerializeField] private SkeletonGraphic skeletonRuneGFX;

    private float m_indicator1Rate;
    private float m_indicator2Rate;
    private float m_indicator3Rate;


    public string FamilyName
    {
        get => m_familyName;
        set
        {
            m_familyName = value;

            if (textFrontFamilyName is not null) textFrontFamilyName.text = m_familyName;
        }
    }
    public string CharacterName
    {
        get => m_name;
        set
        {
            m_name = value;

            if (textFrontName is not null) textFrontName.text = m_name;
            if (textBackName is not null) textBackName.text = m_name;
        }
    }
    public string Description
    {
        get => m_descriptin;
        set
        {
            m_descriptin = value;

            if (textDescription is not null) textDescription.text = m_descriptin;
        }
    }
    public string FamilyRuneName
    {
        get => m_perc1Name;
        set
        {
            m_perc1Name = value;

            if (textPerc1 is not null) textPerc1.text = string.Format(m_perc1Format, m_perc1Name);
        }
    }
    public Sprite FamilyRune
    {
        get => m_spriteFamilyRune;
        set
        {
            m_spriteFamilyRune = value;

            if (imageFamilyRune1 is not null) imageFamilyRune1.sprite = m_spriteFamilyRune;
            if (imageFamilyRune2 is not null) imageFamilyRune2.sprite = m_spriteFamilyRune;
            if (imagePerc1 is not null) imagePerc1.sprite = m_spriteFamilyRune;
        }
    }
    public string AceAspectName
    {
        get => m_perc2Name;
        set
        {
            m_perc2Name = value;

            if (textPerc2 is not null) textPerc2.text = string.Format(m_perc2Format, m_perc2Name);
        }
    }
    public Sprite AceAspect
    {
        get => m_spritePerc2;
        set
        {
            m_spritePerc2 = value;

            if (imagePerc2 is not null) imagePerc2.sprite = m_spritePerc2;
        }
    }
    public float FuryRate
    {
        get => m_indicator1Rate;
        set
        {
            m_indicator1Rate = value;

            if (indicator1 is not null) indicator1.Precent = value;
        }
    }
    public float RewardRate
    {
        get => m_indicator2Rate;
        set
        {
            m_indicator2Rate = value;

            if (indicator2 is not null) indicator2.Precent = value;
        }
    }
    public float TimeRate
    {
        get => m_indicator3Rate;
        set
        {
            m_indicator3Rate = value;

            if (indicator3 is not null) indicator3.Precent = value;
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        FamilyName = m_familyName;
        CharacterName = m_name;
        Description = m_descriptin;

        FamilyRuneName = m_perc1Name;
        FamilyRune = m_spriteFamilyRune;

        AceAspectName = m_perc2Name;
        AceAspect = m_spritePerc2;

        if (imagePerson is not null) imagePerson.sprite = m_spritePerson;

        if (imageAvatarBorder is not null) imageAvatarBorder.sprite = m_spriteAvatarBorder;
        if (imageAvatarBackground is not null) imageAvatarBackground.sprite = m_spriteAvatarBackground;
        if (imageAvatar is not null) imageAvatar.sprite = m_spriteAvatar;

        ChangeSide(m_isBackSide);

        if (m_isAnimated)
        {
            imageAvatar?.gameObject.SetActive(false);
            imagePerson?.gameObject.SetActive(false);

            skeletonAvatar?.gameObject.SetActive(true);
            skeletonPerson?.gameObject.SetActive(true);
        }
        else
        {
            imageAvatar?.gameObject.SetActive(true);
            imagePerson?.gameObject.SetActive(true);

            skeletonAvatar?.gameObject.SetActive(false);
            skeletonPerson?.gameObject.SetActive(false);
        }

        if (skeletonAvatar is not null) skeletonAvatar.skeletonDataAsset = m_skeletonAvatarDA;
        if (skeletonPerson is not null) skeletonPerson.skeletonDataAsset = m_skeletonPersonDA;
        if (skeletonRuneGFX is not null) skeletonRuneGFX.skeletonDataAsset = m_skeletonRuneDA;
    }
#endif

    private void Awake()
    {
        skeletonRuneGFX.gameObject.SetActive(false);
    }

    private void Start()
    {
        skeletonRuneGFX.AnimationState.Complete += delegate { skeletonRuneGFX.gameObject.SetActive(false); };
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!m_isAnimated) return;

        if (!m_isBackSide)
        {
            skeletonRuneGFX.gameObject.SetActive(true);
            skeletonRuneGFX.AnimationState.SetAnimation(0, "action", false);

            skeletonPerson.AnimationState.Complete += OnIdleToInTransition;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!m_isAnimated) return;

        skeletonRuneGFX.gameObject.SetActive(false);

        if (!m_isBackSide)
        {
            skeletonPerson.AnimationState.Complete += OnInToIdleTransition;
        }
    }

    private void OnInToIdleTransition(TrackEntry track)
    {
        skeletonPerson.AnimationState.SetAnimation(0, "idle", true);
        skeletonPerson.AnimationState.Complete -= OnInToIdleTransition;
    }

    private void OnIdleToInTransition(TrackEntry track)
    {
        skeletonPerson.AnimationState.SetAnimation(0, "in", true);
        skeletonPerson.AnimationState.Complete -= OnIdleToInTransition;
    }


    public void Flip()
    {
        m_isBackSide = !m_isBackSide;

        DG.Tweening.Sequence sequence = DOTween.Sequence();

        sequence
            .Append(transform.DORotate(new Vector3(0, 90, 0), m_flipDuration / 2, DG.Tweening.RotateMode.WorldAxisAdd))
            .AppendCallback(() =>
            {
                ChangeSide(m_isBackSide);
            })
            .Append(transform.DORotate(new Vector3(0, -90, 0), m_flipDuration / 2, DG.Tweening.RotateMode.WorldAxisAdd));
    }


    private void ChangeSide(bool isBackSide)
    {
        Sprite background;

        if (isBackSide)
        {
            backSide?.SetActive(true);
            frontSide?.SetActive(false);

            background = m_spriteBackBackground;
        }
        else
        {
            backSide?.SetActive(false);
            frontSide?.SetActive(true);

            background = m_spriteFrontBackground;
        }

        if (imageBackground is not null)
        {
            imageBackground.sprite = background;
        }
    }
}
