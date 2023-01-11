using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnCollisionEnter : MonoBehaviour
{
    private AudioSource source;
	public AudioClip groundClip;
    public AudioClip rimClip;
	public AudioClip boardClip;
    public string groundTag;
	public string rimTag;
	public string boardTag;

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
        }
    }
}
