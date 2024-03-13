using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS_Comparison : MonoBehaviour
{
    public GameObject[] firstSet;
    public GameObject[] secondSet;

    public GameObject WinnersQ;
    public GameObject lostxd;

    public float comparisonDelay = 1f;

    void Start()
    {
        StartCoroutine(CompareSetsWithDelay());
    }

    IEnumerator CompareSetsWithDelay()
    {
        yield return new WaitForSeconds(comparisonDelay);
        CompareSets();
    }

    void CompareSets()
    {
        string[] firstSetNames = GetGameObjectNames(firstSet);
        string[] secondSetNames = GetGameObjectNames(secondSet);

        bool foundMatchingSet = false;

        foreach (string name in firstSetNames)
        {
            if (ArrayContainsName(secondSetNames, name) && ArrayContainsActiveGameObjectWithName(firstSet, name) && ArrayContainsActiveGameObjectWithName(secondSet, name))
            {
                Debug.Log("At least one active " + name + " is found in both sets.");
                foundMatchingSet = true;
                break;
            }
        }

        if (foundMatchingSet)
        {
            if (WinnersQ != null)
            {
                WinnersQ.SetActive(true);
            }
        }
        
        else
        {
            if (lostxd != null)
            {
                lostxd.SetActive(false);
            }
        }
    }

    string[] GetGameObjectNames(GameObject[] gameObjects)
    {
        string[] names = new string[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            names[i] = gameObjects[i].name;
        }
        return names;
    }

    bool ArrayContainsName(string[] array, string value)
    {
        foreach (string element in array)
        {
            if (element == value)
            {
                return true;
            }
        }
        return false;
    }

    bool ArrayContainsActiveGameObjectWithName(GameObject[] array, string name)
    {
        foreach (GameObject go in array)
        {
            if (go.name == name && go.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}