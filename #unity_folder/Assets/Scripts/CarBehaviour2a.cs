using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {
	
	void LateUpdate()
	{
		// YOUR CODE HERE
		float leftSensor = 0, rightSensor = 0;

		//Read sensor values
		if (DetectLights)
        {
			leftSensor = LeftLD.GetOutput();
			rightSensor = RightLD.GetOutput();
		}

		if (DetectCars)
        {
			leftSensor = LeftCD.GetOutput();
			rightSensor = RightCD.GetOutput(); 
		}
		

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}

	private void OnTriggerEnter(Collider other){
        // Se o player colidir com a pickup
        if (other.gameObject.CompareTag("Coin")){
            other.gameObject.SetActive(false); // desaparece
        }
    }
}
