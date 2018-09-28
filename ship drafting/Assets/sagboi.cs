using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sagboi : MonoBehaviour {

    public Button sag;
    public ParticleSystem partbois;

    void Sag()
    {
        partbois.GetComponent<Image>().color = new Color(0.43F, 0.98F, 1F);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
