using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCat : MonoBehaviour {

    public int hungry = 100, shit = 0, weight;

    float hungryTimeTick;
    public float hungryDeTime = 1;

    public int shitMax;
    public int shitWeight = 3;

    public float weightScale;

    bool wantPee;
    float waitPeeTime;
    public float peeDelay;


    void Start () {
        wantPee = false;
        hungryTimeTick = 0;
	}
	
	void Update () {
        if(wantPee && Time.time - waitPeeTime > peeDelay) {
            wantPee = false;
            // TODO: start pee 
        }

        hungryTimeTick += Time.deltaTime;
        if(hungryTimeTick >= hungryDeTime) {
            hungry -= 1;
            hungryTimeTick -= hungryDeTime;
        }

        if(hungry <= 0) {
            // TODO: game over
        }

        if(shit >= shitMax) {
            Global.isPoo = true;
            weight -= shitWeight;
            if (weight < 1) weight = 1;
            shit = 0;
        }

        GetComponent<Rigidbody2D>().mass = weight * weightScale;
	}

    public void ChangeVal(int hungryVal, int shitVal, int weightVal) 
    {
        weight += weightVal;
        hungry -= hungryVal;
        shit += shitVal;
    }

    public void SetPee()
    {
        wantPee = true;
        waitPeeTime = Time.time;
    }

}

