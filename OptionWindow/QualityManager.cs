using UnityEngine;
using TMPro;

public class QualityManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _qualityDropdown;
    private const string QUALITY_TAG = "QualityLevel";

    private void Start()
    {
        _qualityDropdown.value = PlayerPrefs.HasKey(QUALITY_TAG) ? PlayerPrefs.GetInt(QUALITY_TAG) : 0;

        QualitySettings.SetQualityLevel(_qualityDropdown.value);
    }

    public void ChangeQuality()
    {
        try
        {
            QualitySettings.SetQualityLevel(_qualityDropdown.value);
            PlayerPrefs.SetInt(QUALITY_TAG, _qualityDropdown.value);
        }
        catch { Debug.LogWarning("Не удалось изменить качество!"); }
    }
}
