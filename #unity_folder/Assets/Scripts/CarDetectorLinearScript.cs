using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorLinearScript : CarDetectorScript {

	// Returns the linear output value.
	public override float GetOutput(){
		float output1;

		if(ApplyThresholds){
			if(output > MaxX || output < MinX){
				output1 = 0;
			}
			else{
				output1 = output;
			}
		}
		else{
			output1 = output;
		}

		if(ApplyLimits){
			if(output1 > MaxY){
				output1 = MaxY;
			}
			
			if(output1 < MinY){
				output1 = MinY;
			}
		}

		//print(output1);
		return output1;
	}

}
