using UnityEngine;
using UnityEngine.UI;


public class loadfill : MonoBehaviour
{
    //you already know
    public Button PGM;
    public Slider bar;
    //field component for manually inputting load value
    public InputField loadfield;
    //convenient label to confirm realtime load value
    public Text loadlabel;
    float inputload;

    //things we want the program to have before start
    private float maxload = 100f;
    private float currentload = 0f;
    private bool _ClickedOn = false;



    // Use this for initialization
    void Start()
    {
        //setting start defaults
        bar.value = 0;
        currentload = 0f;
        //set trigger for clicking PGM to run "facilitate load"
        PGM.onClick.AddListener(facilitateload);


    }

    //when you click PGM button
    void facilitateload()
    {
        if (_ClickedOn == false)
        {
            //instigates constant charge updating at rate 2f
            InvokeRepeating("adjustload", 0f, 2f);
            _ClickedOn = true;
            return;
        }
        if (_ClickedOn == true)
        {
            //stops updating until button is clicked again
            CancelInvoke("adjustload");
            _ClickedOn = false;
            return;
        }
    }

    //constanly running function due to "InvokeRepeating"
    void adjustload()
    {
        //bar fills by 5% at a time
        currentload += 5f;
        //shows exact fill at time of fill
        loadlabel.text = "Current Load: " + currentload + "%";
        //divides by 100 since load fill is represented by numbers between 0 and 1
        float calchealth = currentload / maxload;
        //updates slider visual
        bar.value = calchealth;
    }

    //function triggered by clicking manual load button
    public void onchange()
    {
        //converts field input into float value
        float number = (float)double.Parse(loadfield.text);
        //updates currentload to reflect number
        currentload = number;

        bar.value = number / 100f;
        loadlabel.text = "Current Load: " + number + "%";
    }


}
