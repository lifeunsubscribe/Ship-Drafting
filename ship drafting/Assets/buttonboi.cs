//UnityEngine.UI is needed for any code pertaining to UI components
using UnityEngine.UI;
//UnityEngine is needed for unity code
using UnityEngine;

//This class is name of our script, which I called buttonboi. Monobehavior automatically comes with all of them
public class buttonboi : MonoBehaviour
{
    //we add a Button to represent start PGM, and make it public so we can 
    //assign the button object to the script once we finish writing it
    public Button PGM;
    //we add a public text component (we'll assign PGMtext to it) so we can change the words on the button
    public Text pressed;
    //this flag will indicate whether the button is on or off, don't set it to true until we click it
    private bool _ClickedOn = false;
    //these will be assigned the two particle systems we just made
    public ParticleSystem energee;
    //these variables are the units that facilitate particle emission 
    private ParticleSystem.EmissionModule energeeEmission;


    void Awake()
    {
        //link the private emission module to the public component emission module in awake
        energeeEmission = energee.emission;
    }

    // Use this for initialization
    void Start()
    {
        //onClick.AddListener() will run a function when the mouse button is released
        //PGM is the button object we use as a trigger and we made a function to dictate the particle behavior
        PGM.onClick.AddListener(RunEnergy);
        //make sure particles aren't automatically emitting
        energeeEmission.enabled = false;


    }

    // Update is called once per frame, useless in this context
    void Update()
    {

    }

    //what the thing makes the thing do after its clicked
    void RunEnergy()
    {
        //if statement runs if the button is off at the time if clicking
        if (_ClickedOn == false)
        {
            //the button color changes
            PGM.GetComponent<Image>().color = new Color(0.43F, 0.98F, 1F);
            //the button label changes
            pressed.text = "PGM (on)";
            //state changes from off to on
            _ClickedOn = true;

            //the particle systems start running
            energeeEmission.enabled = true;

            return;
        }

        //runs if button is already on when clicked
        if (_ClickedOn == true)
        {
            //change color back
            PGM.GetComponent<Image>().color = new Color(0.67F, 0.906F, 0.84F);
            //make label indiicate its off
            pressed.text = "PGM (off)";
            //change state indicator
            _ClickedOn = false;

            //disable the particel systems
            energeeEmission.enabled = false;

            return;
        }

    }


}
