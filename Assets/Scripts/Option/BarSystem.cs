using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSystem : MonoBehaviour
{
    public static BarSystem Instance = null;

    public Image GoodBarImage = null;
    public Image GoodBarArrowImage = null;
    public Image BadBarImage = null;
    public Image BadBarArrowImage = null;

    private int GoodMaxValue = 100;
    public int GoodCurrentValue = 100;
    private int GoodStartValue = 1;
    private int BadMaxValue = 100;
    public int BadCurrentValue = 100;
    private int BadStartValue = 1;
    private Vector2 GoodArrowCurrentPos = Vector2.zero;
    private Vector2 BadArrowCurrentPos = Vector2.zero;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    public void Init()
    {
        Reset();
    }

    public void Setup(int goodMaxValue, int badMaxValue, int goodStartValue, int badStartValue)
    {
        GoodMaxValue = Mathf.Max(1, goodMaxValue);
        BadMaxValue = Mathf.Max(1, badMaxValue);
        GoodStartValue = Mathf.Clamp(goodStartValue, 0, GoodMaxValue);
        BadStartValue =Mathf.Clamp(badStartValue, 0, badStartValue);
        Reset();
    }

    public void Reset()
    {
        GoodCurrentValue = GoodStartValue;
        BadCurrentValue = BadStartValue;
        UpdateImage();
    }

    /// <summary>
    /// �ק�ƭ�
    /// </summary>
    /// <param name="goodValue">�W���</param>
    /// <param name="badValue">�W���</param>
    public void AddValue(int goodValue, int badValue)
    {
        GoodCurrentValue = Mathf.Clamp(GoodCurrentValue + goodValue, 0, GoodMaxValue);
        BadCurrentValue = Mathf.Clamp(BadCurrentValue + badValue, 0, GoodMaxValue);
        UpdateImage();
    }

    private void UpdateImage()
    {
        GoodBarImage.fillAmount = GoodCurrentValue == 0 ? 0 : (float)GoodCurrentValue / (float)GoodMaxValue;
        BadBarImage.fillAmount = BadCurrentValue == 0 ? 0 : (float)BadCurrentValue / (float)BadMaxValue;
        GoodBarArrowImage.rectTransform.anchoredPosition = new Vector3(GoodBarArrowImage.rectTransform.anchoredPosition.x, (GoodBarImage.rectTransform.rect.height * GoodBarImage.fillAmount) + (-1 * GoodBarImage.rectTransform.rect.height / 2),  0);
        BadBarArrowImage.rectTransform.anchoredPosition = new Vector3(BadBarArrowImage.rectTransform.anchoredPosition.x, (BadBarImage.rectTransform.rect.height * BadBarImage.fillAmount) + (-1 * BadBarImage.rectTransform.rect.height / 2), 0);
    }
}
