using TMPro;
using UnityEngine;

public class TextValue : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void UpdateText(int intValue)
    {
        text.text = intValue.ToString();
    }
}
