using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorGaussScript : CarDetectorScript {
	public float stdDev = 1.0f; 
	public float mean = 0.0f; 
	
	// Returns the gaussian output value.
	public override float GetOutput(){
		float output1;

		if(ApplyThresholds){
			if(output > MaxX || output < MinX){
				output1 = 0;
			}
			else{
				output1 = (1.0f / (stdDev * Mathf.Sqrt(2.0f * Mathf.PI))) * Mathf.Exp((-1.0f/2.0f) * Mathf.Pow(((output - mean)/stdDev), 2.0f));
			}
		}
		else{
			output1 = (1.0f / (stdDev * Mathf.Sqrt(2.0f * Mathf.PI))) * Mathf.Exp((-1.0f/2.0f) * Mathf.Pow(((output - mean)/stdDev), 2.0f));
		}

		if(ApplyLimits){
			if(output1 > MaxY){
				output1 = MaxY;
			}
			
			if(output1 < MinY){
				output1 = MinY;
			}
		}

		return output1;
	}
}
