using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] uint Balance = 150;
    [SerializeField] uint currentBalance;
    public uint CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentBalance = Balance;
        UpdateDisplayBalance();
    }

    public void Deposit(uint amount)
    {
        currentBalance += amount;
        UpdateDisplayBalance();
    }
    public void Withdrawal(uint amount)
    {
        currentBalance -= amount;
        UpdateDisplayBalance();

        if (currentBalance > 4000000000 || currentBalance == 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplayBalance()
    {
        displayBalance.text = "GOLD - " + currentBalance;
    }

    void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
