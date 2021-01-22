using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int PlyrTurn, OppontTurn;
    public Text turnText;

    public int maxEnergy, currentEnergy, sumEnergy;
    public Text energyText;

    void Start()
    {
        isYourTurn = true;
        PlyrTurn = 1;
        OppontTurn = 0;

        maxEnergy = 1;
        currentEnergy = 1;
    }

    void Update()
    {
        if (isYourTurn == true)
            turnText.text = "Your Turn";
        else
            turnText.text = "Opponent Turn";

        energyText.text = currentEnergy + "/" + maxEnergy;

    }

    public void EndTurn()
    {
        isYourTurn = false;
        OppontTurn += 1;
    }

    public void EndOpponentTurn()
    {
        isYourTurn = true;
        PlyrTurn += 1;

        maxEnergy += sumEnergy;
        currentEnergy = maxEnergy;
    }
}
