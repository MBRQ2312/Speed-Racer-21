using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedRacerUi : MonoBehaviour
{
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;
    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    public Fuel carFuel = new Fuel(100);

    public TMP_Text carDescriptionUI;
    public TMP_Text carAgeUI;
    public TMP_Text carWeightUI;
    public TMP_Text carFuelLevelUI;
    //public TMP_Text carTypeUI;


    public global::System.Int32 YearMade { get => YearMade1; set => YearMade1 = value; }
    public global::System.Int32 YearMade1 { get => yearMade; set => yearMade = value; }
    public global::System.Int32 YearMade2 { get => yearMade; set => yearMade = value; }

    void Start()
    {
        carDescriptionUI.text = "The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.";

        CheckWeight();

        if (YearMade <= 2009)
        {
            carAgeUI.text = "It was first introduced in " + YearMade;

            int carAge = CalculateAge(YearMade);

            carAgeUI.text += ". That makes it " + carAge + " years old.";

        }
        else
        {
             carAgeUI.text = "It was introduced in the 2010's";
             carAgeUI.text += "And its maximum acceleration is " + maxAcceleration + " m/s2";
        }

        print(CheckCharacteristics());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    public void ConsumeFuel()
    {
        carFuel.fuelLevel -= 10;
    }
    public void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                carFuelLevelUI.text = "Fuel level is nearing two-thirds.";
                break;
            case 50:
                carFuelLevelUI.text = "Fuel level is at half amount.";
                break;
            case 10:
                carFuelLevelUI.text = "Warning! Fuel level is critically low.";
                break;
            default:
                carFuelLevelUI.text = "Nothing to report.";
                break;
        }
    }
    void CheckWeight()
    {

        if (carWeight < 1500)
        {
            carWeightUI.text = "The " + carModel + " weighs less than 1500 kg.";
        }
        else
        {
            carWeightUI.text = "The " + carModel + " weighs over 1500 kg.";
        }
    }

    int CalculateAge(int yearMade)
    {
        return 2021 - yearMade;
    }

    string CheckCharacteristics()
    {
    
        if (isCarTypeSedan)
        {
            return "The car is a sedan type.";

        }
        else if (hasFrontEngine)
        {
            return "The car is not a sedan, but has a front engine.";

        }
        else
        {
            return "The car is neither a sedan, nor is its engine a front engine.";
        }
    }
}
