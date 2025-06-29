using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Переключает пошаговую анимацию сборки.
/// • В Animator-контроллере должен быть целочисленный параметр **StepIndex**.
/// • Все клипы Step1 … StepN находятся в одном слое и переходят друг в друга по условию
///   StepIndex == 0, 1, 2 …
/// </summary>
public class AssemblyStepSwitcher : MonoBehaviour
{
    [Header("Ссылки из инспектора")]
    [SerializeField] Animator animator;          // Animator с контроллером «Chair» (или любым другим)
    [SerializeField] Button buttonPrev;
    [SerializeField] Button buttonNext;
    [SerializeField] Button buttonBack;          
    [SerializeField] int totalSteps = 5;         // сколько клипов Step1 … StepN

    int _currentStep;                            // 0 … totalSteps-1

    #region UNITY - жизненный цикл
    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        buttonPrev.onClick.AddListener(Prev);
        buttonNext.onClick.AddListener(Next);
        buttonBack.onClick.AddListener(OnBack);     
    }

    void Start() => SetStep(0);
    #endregion

    #region Кнопки
    public void Next() => Change(+1);
    public void Prev() => Change(-1);

    void Change(int delta)
    {
        int next = Mathf.Clamp(_currentStep + delta, 0, totalSteps - 1);
        SetStep(next);
    }

    void OnBack()                                      
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    #endregion

    #region Внутреннее
    void SetStep(int idx)
    {
        _currentStep = idx;

        if (!animator.enabled)
            animator.enabled = true;

        animator.SetInteger("StepIndex", _currentStep);

        buttonPrev.interactable = _currentStep > 0;
        buttonNext.interactable = _currentStep < totalSteps - 1;

        Debug.Log($"Step {_currentStep + 1}/{totalSteps}");
    }
    #endregion
}
