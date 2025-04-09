using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardUI : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private bool m_isBackSide;
    [SerializeField] private GameObject frontSide;
    [SerializeField] private GameObject backSide;

    [Header("Family Name")]
    [SerializeField] private string m_familyName;
    [SerializeField] private TMP_Text textFrontFamilyName;

    [Header("Character Name")]
    [SerializeField] private string m_name;
    [SerializeField] private TMP_Text textFrontName;
    [SerializeField] private TMP_Text textBackName;

    [Header("Character Description")]
    [SerializeField] private string m_descriptin;
    [SerializeField] private TMP_Text textDescription;

    [Header("Family Rune")]
    [SerializeField] private Sprite m_spriteFamilyRune;
    [SerializeField] private Image imageFamilyRune1;
    [SerializeField] private Image imageFamilyRune2;

    [Header("Family Rune Perc")]
    [SerializeField] private string m_perc1Format = "фамильная руна:\n{0}";
    [SerializeField] private string m_perc1Name;
    [SerializeField] private TMP_Text textPerc1;
    [SerializeField] private Image imagePerc1;

    [Header("Ace Aspect Perc")]
    [SerializeField] private string m_perc2Format = "аспект асов:\n{0}";
    [SerializeField] private string m_perc2Name;
    [SerializeField] private Sprite m_spritePerc2;
    [SerializeField] private TMP_Text textPerc2;
    [SerializeField] private Image imagePerc2;

    [Header("Indicators")]
    [SerializeField] private IndicatorUI indicator1;
    [SerializeField] private IndicatorUI indicator2;
    [SerializeField] private IndicatorUI indicator3;

    [Header("Person")]
    [SerializeField] private Sprite m_spritePerson;
    [SerializeField] private Image imagePerson;

    [Header("Avatar")]
    [SerializeField] private Sprite m_spriteAvatarBorder;
    [SerializeField] private Sprite m_spriteAvatarBackground;
    [SerializeField] private Sprite m_spriteAvatar;
    [SerializeField] private Image imageAvatarBorder;
    [SerializeField] private Image imageAvatarBackground;
    [SerializeField] private Image imageAvatar;

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


        if (m_isBackSide)
        {
            backSide?.SetActive(true);
            frontSide?.SetActive(false);
        }
        else
        {
            backSide?.SetActive(false);
            frontSide?.SetActive(true);
        }
    }
#endif


    public void Flip()
    {
        m_isBackSide = !m_isBackSide;

        if (m_isBackSide && backSide is not null)
        {
            backSide.SetActive(true);
            frontSide.SetActive(false);
        }
        else if (frontSide is not null)
        {
            backSide.SetActive(false);
            frontSide.SetActive(true);
        }
    }
}
