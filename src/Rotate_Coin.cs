using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Coin : MonoBehaviour{
    Vector3 rotation = new Vector3(15, 30, 45);

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        this.transform.Rotate(rotation * Time.deltaTime);
    }
    /*
    private void OnTriggerEnter(Collider other){
        if (other.name == "Searcher"){         // Se o player colidir com a pickup
            Destroy(gameObject);
        }
    }
*/
}
