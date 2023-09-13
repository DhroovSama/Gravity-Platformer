using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public float speed = 200;
	
	public void Update ()
	{
		this.transform.localEulerAngles = new Vector3
		(
			this.transform.localEulerAngles.x,
			this.transform.localEulerAngles.y,
			this.transform.localEulerAngles.z + speed * Time.deltaTime
		);
	}
}
