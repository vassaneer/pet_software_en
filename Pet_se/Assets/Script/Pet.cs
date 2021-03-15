using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using API;
using UnityEngine.UI;
using System;

public class Pet : MonoBehaviour
{
    public Initial ini;
    public Sprite sprite;
    public GameObject[] go;
    public List<Text> texts;
    public List<Slider> hungers;
    public List<Slider> happys;
    public List<Text> statuss;
    public List<Text> messages;
    public object _queueLock = new object();
    // Start is called before the first frame update
    private void Awake()
    {
        for (int index = 0; index < 3; index++)
        {
            //texts.Add(GameObject.Find("nong" + (index + 1).ToString() + "statuss").GetComponent<Text>());
            hungers.Add(GameObject.Find("hungerSlider" + (index + 1).ToString()).GetComponent<Slider>());
            happys.Add(GameObject.Find("happySlider" + (index + 1).ToString()).GetComponent<Slider>());
            statuss.Add(GameObject.Find("statusText" + (index + 1).ToString()).GetComponent<Text>());
            messages.Add(GameObject.Find("messageText" + (index + 1).ToString()).GetComponent<Text>());
        }
    }
    void Start()
    {
        ini = new Initial("127.0.0.1",3306,"root","1234");
    }
    // when value in pet change
    private void Pets_PetChange()
    {
          //Debug.Log("change");
            int index = 0;
            foreach (API.Pet pet in ini.pets.Pet)
            {
                //Debug.Log(pet.speak);
                hungers[index].value = (float)pet.hungry / 100;
                happys[index].value = (float)pet.mental / 100;
                //texts[index].text = pet.name;
                statuss[index].text = pet.status;
                messages[index].text = pet.speak;
            float position_x = (GameObject.Find("nong" + (index + 1).ToString()).GetComponent<RectTransform>()).position.x;
                messages[index].transform.position = new Vector3(position_x, 0, 0);
                index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pets_PetChange();
    }
}
