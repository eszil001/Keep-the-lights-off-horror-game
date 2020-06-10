
using UnityEngine;
using System.Collections;

public class DelObj : MonoBehaviour {
	public GameObject NachObject, Trigger;
	public int count = 0;
	public float tim = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(count == 1)
		{
			tim += Time.deltaTime;
			if(tim > 5)
			{
				Destroy(Trigger);
				Destroy(NachObject);
				tim = 0;
				count = 0;
			}
		}
		
	}
	void OnTriggerEnter (Collider other) {
		if(NachObject != null)
			if(other.gameObject.name == Trigger.name)
		{
			if(count == 0)
				NachObject.SetActive(true);
		}
	}
	
	void OnTriggerExit (Collider other) {
		if(NachObject != null)
			if(other.gameObject.name == Trigger.name)
		{
			count = 1;
		}
	}
}
