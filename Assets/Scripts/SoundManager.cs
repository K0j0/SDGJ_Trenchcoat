using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource  bg;
	public AudioSource atmos;
	public AudioSource byz;
	public AudioSource east;
	public AudioSource enem_ded;
	public AudioSource ene_s;
	public AudioSource runn;
	public AudioSource sw_imp;
	public AudioSource sw_sing;
	public AudioSource title;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(Snd sound){
		switch(sound){
		case Snd.bg:
			bg.Play();
			break;
		case Snd.atmos:
			atmos.Play();
			break;
		case Snd.byz:
			byz.Play();
			break;
		case Snd.east:
			east.Play();
			break;
		case Snd.enem_ded:
			enem_ded.Play();
			break;
		case Snd.ene_s:
			ene_s.Play();
			break;
		case Snd.runn:
			runn.Play();
			break;
		case Snd.sw_imp:
			sw_imp.Play();
			break;
		case Snd.sw_sing:
			sw_sing.Play();
			break;
		case Snd.title:
			title.Play();
			break;
		}
	}

	public void StopSound(Snd sound){
		switch(sound){
		case Snd.bg:
			bg.Stop();
			break;
		case Snd.atmos:
			atmos.Stop();
			break;
		case Snd.byz:
			byz.Stop();
			break;
		case Snd.east:
			east.Stop();
			break;
		case Snd.enem_ded:
			enem_ded.Stop();
			break;
		case Snd.ene_s:
			ene_s.Stop();
			break;
		case Snd.runn:
			runn.Stop();
			break;
		case Snd.sw_imp:
			sw_imp.Stop();
			break;
		case Snd.sw_sing:
			sw_sing.Stop();
			break;
		case Snd.title:
			title.Stop();
			break;
		}
	}
}
