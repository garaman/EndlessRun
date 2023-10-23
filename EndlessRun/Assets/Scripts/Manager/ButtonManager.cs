using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int createCount;
    [SerializeField] Button buttonprefab;
    [SerializeField] Transform createPosition;

    List<Button> buttons = new List<Button>();
    List<string> buttonTexts = new List<string>() { "Start","Shop","Option","Quit"};
    Button button;
    
    void Start()
    {
        buttons.Capacity = 10;
        CreateButton();
        Register();
    }

    public void CreateButton()
    {
        for (int i = 0; i < createCount; i++)
        {
            button = Instantiate(buttonprefab);

            button.transform.SetParent(createPosition);

            button.GetComponentInChildren<TextMeshProUGUI>().text = buttonTexts[i];

            buttons.Add(button);
        }

    }


    private void Register()
    {
        for (int i = 0; i < createCount; i++)
        {
            switch(i)
            {
                case 0:
                    buttons[i].onClick.AddListener(A);
                    break;
                case 1:
                    buttons[i].onClick.AddListener(B);
                    break;
                case 2:
                    buttons[i].onClick.AddListener(C);
                    break;
                case 3:
                    buttons[i].onClick.AddListener(D);
                    break;

            }
            
        }
    }

    public void A()
    {        
        Debug.Log("Start");
    }

    public void B()
    {    
        Debug.Log("B");
    }

    public void C()
    {     
        Debug.Log("C");
    }

    public void D()
    {   
        Debug.Log("D");
    }
}
