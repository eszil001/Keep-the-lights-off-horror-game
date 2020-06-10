using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Battery : MonoBehaviour {
	public float BatteryCapacity;
	public Sprite Batt1, Batt2, Batt3, Batt4;
	public Image _Battery;
	public float Capacity;
	private float Delit;
	public Text TextRec;
	public float Hours, Minutes, Seconds;
	private float TimeRec;
	// Use this for initialization
	void Start () {
		Delit = BatteryCapacity / 4;
		Capacity = BatteryCapacity;
	}
	
	// Update is called once per frame
	void Update () {
		Seconds += Time.deltaTime;
		if (Seconds >= 60) {
			Seconds = 0;
			Minutes ++;
			if(Minutes >= 60)
			{
				Minutes = 0;
				Hours ++;
				/*if(Hours > 23)
				{
					Hours = 0;
				}*/
			}
		}
		TextRec.text = "REC: " + Hours + ":" + Minutes + ":" + Mathf.FloorToInt(Seconds);

		Capacity -= Time.deltaTime;
		if (Capacity <= BatteryCapacity && Capacity > BatteryCapacity - Delit) {
			_Battery.sprite = Batt4;
		}
		if (Capacity <= BatteryCapacity - Delit && Capacity > BatteryCapacity - Delit*2) {
			_Battery.sprite = Batt3;
		}
		if (Capacity <= BatteryCapacity - Delit*2 && Capacity > BatteryCapacity - Delit*3) {
			_Battery.sprite = Batt2;
		}
		if (Capacity <= BatteryCapacity - Delit*3 && Capacity > 0) {
			_Battery.sprite = Batt1;
		}
	}
}
