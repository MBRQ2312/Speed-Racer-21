using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedRacer : MonoBehaviour
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

    public global::System.Int32 YearMade { get => YearMade1; set => YearMade1 = value; }
    public global::System.Int32 YearMade1 { get => yearMade; set => yearMade = value; }
    public global::System.Int32 YearMade2 { get => yearMade; set => yearMade = value; }

    void Start()
    {
        print("The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.");

        CheckWeight();

        if (YearMade <= 2009)
        {
            print("It was first introduced in " + YearMade);

            int carAge = CalculateAge(YearMade);

            print("That makes it " + carAge + " years old.");

        }
        else
        {
            print("It was introduced in the 2010's");
            print("And its maximum acceleration is " + maxAcceleration + " m/s2");
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

    void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;
    }
    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                print("Fuel level is nearing two-thirds.");
                break;
            case 50:
                print("Fuel level is at half amount.");
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                break;
            default:
                print("Nothing to report.");
                break;
        }
    }
    void CheckWeight()
    {

        if (carWeight < 1500)
        {
            print("The " + carModel + " weighs less than 1500 kg.");
        }
        else
        {
            print("The " + carModel + " weighs over 1500 kg.");
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
