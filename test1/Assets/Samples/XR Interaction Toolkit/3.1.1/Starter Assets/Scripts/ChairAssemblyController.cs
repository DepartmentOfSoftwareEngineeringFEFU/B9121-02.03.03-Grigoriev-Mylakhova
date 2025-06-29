using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
//using TMPro;


public class ChairAssemblyController : MonoBehaviour
{
     public Animator animator;
     public GameObject InstructionPanel;
     public Button buttonPrev;
     public Button buttonNext;
     public Button buttonExit;
    // public TMP_Text stepInfoText;
    public int maxSteps = 5;

    private int currentStep = 0;


    void Start()
    {
        
        
        buttonPrev.onClick.AddListener(OnPrev);
        buttonNext.onClick.AddListener(OnNext);
        buttonExit.onClick.AddListener(OnExit);

        InstructionPanel.SetActive(false);
        ShowInstruction();
    }

    public void ShowInstruction()
    {
        InstructionPanel.SetActive(true);
        ShowStep(0);
    }

    void OnPrev()
    {
        if (currentStep > 0)
            ShowStep(currentStep - 1);
    }

    void OnNext()
    {
        if (currentStep < maxSteps - 1)
            ShowStep(currentStep + 1);
    }

    void OnExit()
    {
        InstructionPanel.SetActive(false);
    }

    void ShowStep(int step)
    {
        currentStep = step;
        animator.Play("Step" + (currentStep + 1)); // Step1, Step2
        buttonPrev.interactable = currentStep > 0;
        buttonNext.interactable = currentStep < maxSteps - 1;
        //if (stepInfoText != null)
           // stepInfoText.text = $" {currentStep + 1} {maxSteps}";
    }
}
