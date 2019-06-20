using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//select an event
public class RandomEventsManager : MonoBehaviour
{
    [Header("Manage")]
    public List<RandomEventScriptableObject> events = new List<RandomEventScriptableObject>();

    bool mayDoRandom = true;
    public int minTimer;
    public int maxTimer;
    public float timer;
    public float wait;

    public UIManager uIManager;
    public ResourceManager resourceManager;
    [Header("UI")]
    public GameObject randomEventPanel;
    public GameObject randomName;
    public GameObject randomDis;
    public GameObject randomAddOrRemove;

    private void Start()
    {
        randomEventPanel.SetActive(false);
        randomName.SetActive(false);
        randomDis.SetActive(false);
        randomAddOrRemove.SetActive(false);
    }
    void Update()
    {
        if (mayDoRandom == true)
        {
            timer = Random.Range(minTimer, maxTimer);
            StartCoroutine(RandomTimer(timer));
            mayDoRandom = false;
        }
    }

    IEnumerator RandomTimer(float f)
    {
        yield return new WaitForSeconds(f);

        int t = Random.Range(0, events.Count);
        RandomEventScriptableObject refe = events[t];

        int index = Random.Range(0, refe.addValues.Length);
        RandomEventScriptableObject.AddSlot eventSlot = refe.addValues[index];

        int addValue = eventSlot.add ? eventSlot.amount : -eventSlot.amount;

        switch (eventSlot.material)
        {
            case RandomEventScriptableObject.MaterialType.Wood:
                //add or remove
                //resourceManager.resourcesCurrent[0] += addValue;
                resourceManager.Gain(0, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Planks:
                //resourceManager.resourcesCurrent[1] += addValue;
                resourceManager.Gain(1, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Stone:
                //resourceManager.resourcesCurrent[2] += addValue;
                resourceManager.Gain(2, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Wheat:
                //resourceManager.resourcesCurrent[4] += addValue;
                resourceManager.Gain(4, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Flour:
                //resourceManager.resourcesCurrent[5] += addValue;
                resourceManager.Gain(5, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Bread:
                //resourceManager.resourcesCurrent[6] += addValue;
                resourceManager.Gain(6, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Berry:
                //resourceManager.resourcesCurrent[7] += addValue;
                resourceManager.Gain(7, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.IronOre:
                //resourceManager.resourcesCurrent[10] += addValue;
                resourceManager.Gain(10, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.GoldOre:
                //resourceManager.resourcesCurrent[11] += addValue;
                resourceManager.Gain(11, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Iron:
                //resourceManager.resourcesCurrent[12] += addValue;
                resourceManager.Gain(12, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            case RandomEventScriptableObject.MaterialType.Gold:
                //resourceManager.resourcesCurrent[13] += addValue;
                resourceManager.Gain(13, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;
            /*case RandomEventScriptableObject.MaterialType.Population:
                //resourceManager.resourcesCurrent[15] += addValue;
                resourceManager.Gain(15, addValue);

                randomEventPanel.SetActive(true);
                randomName.SetActive(true);
                randomDis.SetActive(true);
                randomAddOrRemove.SetActive(true);

                randomName.GetComponent<Text>().text = eventSlot.eventName;
                randomDis.GetComponent<Text>().text = eventSlot.description;
                randomAddOrRemove.GetComponent<Text>().text = eventSlot.amount.ToString();

                StartCoroutine(CloseUi());
                break;*/
        }
        mayDoRandom = true;
    }
    IEnumerator CloseUi()
    {
        yield return new WaitForSeconds(wait);
        randomEventPanel.SetActive(false);
        randomName.SetActive(false);
        randomDis.SetActive(false);
        randomAddOrRemove.SetActive(false);
    }
}