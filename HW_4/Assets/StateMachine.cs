using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject firstScreen;
    [SerializeField] private GameObject secondScreen;
    [SerializeField] private GameObject thirdScreen;

    private GameObject currentScreen;
     

    // Start is called before the first frame update
    void Start()
    {
        firstScreen.SetActive(true);
        currentScreen = firstScreen;
    }

    public void ChangeScreen(GameObject state)
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
