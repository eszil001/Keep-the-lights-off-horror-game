using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableCamera : MonoBehaviour {
	public Animation _Animation;
	public AnimationClip AnimatClipUpCam, AnimatClipDownCam;
	private int perkl;
	public GameObject Battery, TextRec, CameraGame, _Camera;
	public Battery _Battery;
	public Image _BlackImage; 
	private float _a;
	public AudioSource _AudioSource;
	public AudioClip ClipEnableCam, ClipDisableCam;
	public UnityStandardAssets.ImageEffects.Bloom _Bloom;
	public UnityStandardAssets.ImageEffects.ContrastEnhance _ContrastEnhance;
	public UnityStandardAssets.ImageEffects.Grayscale _Grayscale;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (_Battery.Capacity > 0) {
			if(perkl == 5)
			{
				perkl = 0;
			}
		}
		if (_Battery.Capacity <= 0) {
			_Battery.enabled = false;
			_Battery.Capacity = 0;
			if(perkl == 2)
			{
				CameraGame.SetActive(true);
				_Camera.GetComponent<Camera>().cullingMask &= ~(6 << 6);
				_Animation.clip = AnimatClipDownCam;
				_Animation.Play();
				Battery.SetActive(false);
				TextRec.SetActive(false);
				_Battery.enabled = false;
				_BlackImage.color = new Color(0,0,0,0.5f);
				_a = 0.5f;
				_AudioSource.clip = ClipDisableCam;
				_AudioSource.Play();
				_Bloom.enabled = false;
				_ContrastEnhance.enabled = false;
				_Grayscale.enabled = false;
				perkl = 4;
			}
		}
		if(perkl == 0)
		if (Input.GetKeyDown (KeyCode.E)) {
			CameraGame.SetActive(true);
			_Animation.clip = AnimatClipUpCam;
			_Animation.Play();
			_AudioSource.clip = ClipEnableCam;
			_AudioSource.Play();
			perkl = 1;
		}
		if (perkl == 1) {
			if(_a < 0.6f)
			_a += Time.deltaTime / 3;
			_BlackImage.color = new Color(0,0,0,_a);
			if(!_Animation.isPlaying)
			{
				_Bloom.enabled = true;
				_ContrastEnhance.enabled = true;
				_Grayscale.enabled = true;
				Battery.SetActive(true);
				TextRec.SetActive(true);
				_Battery.enabled = true;
				_Camera.GetComponent<Camera>().cullingMask = ~(1 << 6);
				CameraGame.SetActive(false);
				_BlackImage.color = new Color(0,0,0,0);
				perkl = 2;
			}
		}
		if(perkl == 2)
		if (Input.GetKeyDown (KeyCode.E)) {
			CameraGame.SetActive(true);
			_Camera.GetComponent<Camera>().cullingMask &= ~(6 << 6);
			_Animation.clip = AnimatClipDownCam;
			_Animation.Play();
			Battery.SetActive(false);
			TextRec.SetActive(false);
			_Battery.enabled = false;
			_BlackImage.color = new Color(0,0,0,0.5f);
			_a = 0.5f;
			_AudioSource.clip = ClipDisableCam;
			_AudioSource.Play();
			_Bloom.enabled = false;
			_ContrastEnhance.enabled = false;
			_Grayscale.enabled = false;
			perkl = 3;
		}
		if (perkl == 3) {
			if(_a > 0)
				_a -= Time.deltaTime / 2;
			_BlackImage.color = new Color(0,0,0,_a);
			if(!_Animation.isPlaying)
			{
				perkl = 0;
			}
		}
		if (perkl == 4) {
			if(_a > 0)
				_a -= Time.deltaTime / 2;
			_BlackImage.color = new Color(0,0,0,_a);
			if(!_Animation.isPlaying)
			{
				perkl = 5;
			}
		}
	}
}