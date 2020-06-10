using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddBatteryTrigger : MonoBehaviour {
	public string NameTagBattery;
	public Image InfoImage;
	private int YesNo;
	private GameObject bat;
	public Battery _Battery;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (YesNo == 1) {
			if(Input.GetKeyDown(KeyCode.R))
			{
				_Battery.Capacity += bat.GetComponent<BatCapacity>().BattCapacity;
				if(_Battery.Capacity > _Battery.BatteryCapacity)
				{
					_Battery.Capacity = _Battery.BatteryCapacity;
					Destroy(bat);
					InfoImage.enabled = false;
					bat = null;
					YesNo = 0;
				}
			}
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == NameTagBattery) {
			bat = collider.gameObject;
			InfoImage.enabled = true;
			YesNo = 1;
		}
	}
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.tag == NameTagBattery) {
			bat = null;
			InfoImage.enabled = false;
			YesNo = 0;
		}
	}
}
