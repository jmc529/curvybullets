using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Handler : MonoBehaviour
{
     // on and off materials to set to when in game (and triggered)
    [SerializeField]
    private Material offMat;
    
    [SerializeField]
    private Material onMat;

    // boolean value to hold whether the sign is on or off
    [SerializeField]
    private bool trigger_state;

    // Start is called before the first frame update
    void Start()
    {
        trigger_state = false;
        if(!(offMat == null)) {
            GetComponent<Renderer>().material = offMat;
        }
    }

    public void turn_on(){
        trigger_state = true;
        GetComponent<Renderer>().material = onMat;
    }

    public bool get_trigger_state(){
        return trigger_state;
    }
}
