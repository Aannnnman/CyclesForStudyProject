using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChanger : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _buttonOne;
    [SerializeField] private Button _buttonTwo;
    [SerializeField] private Button _buttonThree;
    [SerializeField] private Button _buttonFour;

    private Enemy[] _enemies;

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();

        _buttonOne.onClick.AddListener(EnemiesHealthCheck);
        _buttonTwo.onClick.AddListener(EnemiesStayWithLevel);
        _buttonThree.onClick.AddListener(ResetChanges);
        _buttonFour.onClick.AddListener(MakeEnemiesWithConcreteNameBosses);
    }

    private void OnDestroy()
    {
        _buttonOne.onClick.RemoveListener(EnemiesHealthCheck);
        _buttonTwo.onClick.RemoveListener(EnemiesStayWithLevel);
        _buttonThree.onClick.RemoveListener(ResetChanges);
        _buttonFour.onClick.RemoveListener(MakeEnemiesWithConcreteNameBosses);
    }

    private void EnemiesHealthCheck()
    {
        if (int.TryParse(_inputField.text, out int healthValue))
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.gameObject.SetActive(enemy.HealthCheck(healthValue));
            }
        }
    }

    private void EnemiesStayWithLevel()
    {
        if (int.TryParse(_inputField.text, out int levelValue))
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.gameObject.SetActive(enemy.LevelCheck(levelValue));
            }
        }
    }

    private void ResetChanges()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.gameObject.SetActive(true);
            enemy.ReturnOriginStats();
        }
    }

    private void MakeEnemiesWithConcreteNameBosses()
    {
        string nameValue = _inputField.text;

        foreach (Enemy enemy in _enemies)
        {
            enemy.TransformationToBoss(nameValue);
        }
    }
}
