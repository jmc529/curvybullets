using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Toggle_Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject onObj;

    [SerializeField]
    private GameObject offObj;

    [SerializeField]
    private State_Handler[] other_signs;

    [SerializeField]
    private bool trigger_state = false;
    // Start is called before the first frame update
    void Start()
    {
        onObj.SetActive(trigger_state);
        offObj.SetActive(!trigger_state);
    }

    void OnTriggerEnter(Collider other){
        State_Handler object_state = GetComponent<State_Handler>();
        if(!trigger_state && other.tag == "Bullet"){
            // if bullet has hit, then toggle objects
            Activate_State();
        }
    }

    void Activate_State(){
        trigger_state = true;
        onObj.SetActive(trigger_state);
        offObj.SetActive(!trigger_state);
        // toggle states
        if(other_signs.Length > 0){
            for(int i = 0; i < other_signs.Length; i++){
                other_signs[i].turn_on();
            }
        }
    }

}