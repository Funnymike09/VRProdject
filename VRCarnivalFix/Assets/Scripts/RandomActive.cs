using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActive : MonoBehaviour
{
    public GameObject[] gameObjectActive;

    private void OnEnable()
    {
        int randomIndex = Random.Range(0, gameObjectActive.Length);

        gameObjectActive[randomIndex].SetActive(true);

        for (int i = 0; i < gameObjectActive.Length; i++)
        {
            if (i != randomIndex)
            {
                gameObjectActive[i].SetActive(false);
            }
        }
    }
}


