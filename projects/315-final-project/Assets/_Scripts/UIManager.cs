using UnityEngine;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] private TextMeshProUGUI clarityText;
    [SerializeField] private TextMeshProUGUI sanityText;

    public void UpdateClarity(int newValue)
    {
        //clarityText.text = $"Clarity: {newValue}";
    }

    public void UpdateSanity(int newValue)
    {
        sanityText.text = $"Sanity: {newValue}";
    }
}
