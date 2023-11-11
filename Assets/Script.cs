using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class SpeedRacer : MonoBehaviour
{
    // Declare and initialise the car's information
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;

    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    public TextMeshProUGUI modelText;
    public TextMeshProUGUI fuelText;

    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    public Fuel carFuel = new Fuel(100);


    void Start()
    {
        //print("The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.");
        modelText.text = "The racer model is " + carModel + " by " + carMaker + ".\nIt has a " + engineType + " engine.";

        CheckWeight();

        if (yearMade <= 2009)
        {
            //print("It was first introduced in " + yearMade);
            modelText.text += "\nIt was first introduced in " + yearMade;
            int carAge = CalculateAge(yearMade);
            print("That makes it " + carAge + " years old.");
        }
        else
        {
            print("It was introduced in the 2010s");
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
        //if (carFuel.fuelLevel <= 0)
        //{
        //    return;
        //}

        carFuel.fuelLevel = Mathf.Max(0, carFuel.fuelLevel - 10);


        //carFuel.fuelLevel -= 10;

        //if (carFuel.fuelLevel <= 0)
        //{
        //    carFuel.fuelLevel = 0;
        //}
    }
    public void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                //print("Fuel level is nearing two-thirds.");
                fuelText.text = "Fuel level at " + carFuel.fuelLevel + " is nearing two-thirds.";
                break;
            case 50:
                //print("Fuel level is at half amount.");
                fuelText.text = "Fuel level at " + carFuel.fuelLevel + " Fuel level is at half amount.";
                break;
            case 10:
                //print("Warning! Fuel level is critically low.");
                fuelText.text = "Fuel level at " + carFuel.fuelLevel + " Warning! Fuel level is critically low.";
                break;
            default:
                //print("Nothing to report.");
                fuelText.text = "Fuel level at " + carFuel.fuelLevel + " Nothing to report.";
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