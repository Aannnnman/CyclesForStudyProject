using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _level;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _levelText;

    private string _originName;
    private int _originHealth;
    private int _originLevel;

    private void Awake()
    {
        UpdateUI();

        _originName = _name;
        _originHealth = _health;
        _originLevel = _level;
    }

    public bool HealthCheck(int concreteHealth)
    {
        return _health > concreteHealth;
    }

    public bool LevelCheck(int concreteLevel)
    {
        return _level == concreteLevel;
    }

    public void TransformationToBoss(string toBossTransformationName)
    {
        if (_name == toBossTransformationName)
        {
            _name = "Boss";
            _level += 1;
            _health *= 3;

            UpdateUI();
        }
    }

    public void ReturnOriginStats()
    {
        _name = _originName;
        _health = _originHealth;
        _level = _originLevel;

        UpdateUI();
    }

    private void UpdateUI()
    {
        _nameText.text = _name;
        _healthText.text = $"HEALTH: {_health}";
        _levelText.text = $"LEVEL: {_level}";
    }
}
