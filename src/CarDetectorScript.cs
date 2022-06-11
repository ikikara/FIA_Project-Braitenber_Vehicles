using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {
	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public bool inverse = false; // If enabled returns the inverse of output
	public float output;
	public int numObjects;

	void Start(){
		output = 0;
		numObjects = 0;

		if (angle > 360){
			useAngle = false;
		}
	}

	void Update() {
		int i = GetClosestCar();

		output = 0;	
		GameObject[] cars = GetAllCars();
		
		if(cars.Length != 0){
			Vector3 r = cars[i].transform.position - transform.position; // calculates the distance between this car and the closest car
			output = 1.0f/(r.sqrMagnitude/10 + 1); // formula to calculate the output

			if(inverse)
				output = 1.0f - output;
		}
		else{
			output = 0.0f;
		}
	}

	public virtual float GetOutput() { 
		throw new NotImplementedException(); 
	}

	// Returns all "CarToFollow" tagged objects.
	GameObject[] GetAllCars(){
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// Returns index of the closest car that contains the "CarToFollow" tag.
    int GetClosestCar(){
		GameObject[] cars = GetAllCars();
		Vector3 d = new Vector3(0,0,0);
		int first = 1;
		int min = 0;

		for(int i = 0; i < cars.Length; i++){
			if(first == 1){ // At first, the closest car is at index 0.
				d = (cars[i].transform.position - transform.position);
				first = 0;
			}
			else{ // Rest of the indexes
				Vector3 distance = (cars[i].transform.position - transform.position);
				
				if(distance.sqrMagnitude < d.sqrMagnitude){ // If car at index i is closer than the one saved, update index 
					d = distance;
					min = i;
				}
			}
        }

        return min;
    }
}
