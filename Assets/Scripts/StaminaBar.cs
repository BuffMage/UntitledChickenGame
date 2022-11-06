using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField]
    private static Image fillBar;
    // Start is called before the first frame update
    void Start()
    {
        fillBar = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    public static void UpdateFillBar(float stamina)
    {
        fillBar.fillAmount = stamina;
    }
}
