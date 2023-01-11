using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayAudioOnCollisionEnter : MonoBehaviour
{
    private AudioSource source;
	public AudioClip groundClip;
    public AudioClip rimClip;
	public AudioClip boardClip;
	public AudioClip scoreClip;
	public AudioClip netClip;
    public string groundTag;
	public string rimTag;
	public string boardTag;
	public string scoreTag;
	public string netTag;

	public ActionBasedController leftController;
	public ActionBasedController rightController;

    public bool useVelocity = true;
    public float minVelocity = 0;  
    public float maxVelocity = 2;

    public bool randomizePitch = true;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.collider.CompareTag(groundTag))
        {
			leftController.SendHapticImpulse(0.1f, 0.5f);
			rightController.SendHapticImpulse(0.1f, 0.5f);
            VelocityEstimator estimator = collision.collider.GetComponent<VelocityEstimator>();
            if(estimator && useVelocity){
                float v = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.InverseLerp(minVelocity, maxVelocity, v);
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(groundClip, volume);
            }
            else{
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(groundClip);
            }
        } else if(collision.collider.CompareTag(rimTag))
        {
			leftController.SendHapticImpulse(1.0f, 1.0f);
			rightController.SendHapticImpulse(1.0f, 1.0f);
            VelocityEstimator estimator = collision.collider.GetComponent<VelocityEstimator>();
            if(estimator && useVelocity){
                float v = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.InverseLerp(minVelocity, maxVelocity, v);
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(rimClip, volume);
            }
            else{
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(rimClip);
            }
        } else if(collision.collider.CompareTag(boardTag))
        {
			leftController.SendHapticImpulse(0.7f, 0.7f);
			rightController.SendHapticImpulse(0.7f, 0.7f);
            VelocityEstimator estimator = collision.collider.GetComponent<VelocityEstimator>();
            if(estimator && useVelocity){
                float v = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.InverseLerp(minVelocity, maxVelocity, v);
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(boardClip, volume);
            }
            else{
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(boardClip);
            }
        } else if(collision.collider.CompareTag(netTag))
        {
            VelocityEstimator estimator = collision.collider.GetComponent<VelocityEstimator>();
            if(estimator && useVelocity){
                float v = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.InverseLerp(minVelocity, maxVelocity, v);
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(netClip, volume);
            }
            else{
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(netClip);
            }
        }
    }

	public void OnTriggerEnter(Collider collider) {
		if(collider.CompareTag(scoreTag))
        {
			StartCoroutine(scorePattern());
            VelocityEstimator estimator = collider.GetComponent<VelocityEstimator>();
            if(estimator && useVelocity){
                float v = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.InverseLerp(minVelocity, maxVelocity, v);
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(scoreClip, volume);
            }
            else{
                if(randomizePitch){
                    source.pitch = Random.Range(minPitch, maxPitch);
                }
                source.PlayOneShot(scoreClip);
            }
        } 
	}

	IEnumerator scorePattern() {
		int num = 0;
		while(num < 3) {
			leftController.SendHapticImpulse(1.0f, 1.0f);
			rightController.SendHapticImpulse(1.0f, 1.0f);
			yield return num++;
		}
	}
}
