using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    private Animator animator;
    [Header("UI")]
    [SerializeField] Slider torchSlider;
    [SerializeField] TMP_Text torchText;
    [Header("Keyboard")]
    [SerializeField] KeyCode torchButton;
    [Header("Prefabs")]
    [SerializeField] GameObject torchPrefab;
    [Header("Scripts")]
    [SerializeField] SavedData savedData;
    private bool torchSwitcher = false;
    private bool isInvoked = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(torchButton))
        {
            if (savedData.torchCount > 0)
            {
                torchSwitcher = !torchSwitcher;
                if (torchSwitcher)
                {
                    isInvoked = true;
                }
            }
            else
            {
                torchSwitcher = false;
            }
            torchPrefab.SetActive(torchSwitcher);
            animator.SetBool("isTorch", torchSwitcher);
        }
        if (torchSwitcher)
        {
            if (isInvoked)
            {
                InvokeRepeating(nameof(UpdateSlider), 0f, 1f);
                isInvoked = false;
            }
            if (savedData.torchLife == 0)
            {
                torchSwitcher = false;
                savedData.torchCount--;
                UpdateCount();
                torchPrefab.SetActive(torchSwitcher);
                animator.SetBool("isTorch", torchSwitcher);
                if (savedData.torchCount > 0)
                {
                    savedData.torchLife = 60;
                    torchSlider.value = 60;
                }
            }
        }
        else
        {
            CancelInvoke(nameof(UpdateSlider));
        }
    }
    public void UpdateCount()
    {
        torchText.text = savedData.torchCount.ToString();
    }
    public void UpdateSlider()
    {
        savedData.torchLife--;
        torchSlider.value = savedData.torchLife;
    }
}
