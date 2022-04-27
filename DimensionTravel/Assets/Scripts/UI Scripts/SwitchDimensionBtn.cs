using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchDimensionBtn : MonoBehaviour
{
    public int firstNextLevel;
    public int secondNextLevel;
    public Text nextLevelNotif;
    private int counter;

    public void SwitchChangeStts()
    {
        counter++;
        if (counter % 2 == 1)
        {
            FindObjectOfType<Car2DController>().nextLevel = firstNextLevel;
            nextLevelNotif.text = "Next Level: " + FindObjectOfType<Car2DController>().nextLevel.ToString();
        }
        else
        {
            FindObjectOfType<Car2DController>().nextLevel = secondNextLevel;
            nextLevelNotif.text = "Next Level: " + FindObjectOfType<Car2DController>().nextLevel.ToString();
        }
    }
}
