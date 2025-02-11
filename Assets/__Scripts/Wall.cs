using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private int count;
    private float velocity;
    public float radius = 100.0F;
    public float power = 10.0F;

    public float resistance = 150.0F;
    public Rigidbody rb;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject engine_rev_obj;
    private AudioSource engine_rev;
    public GameObject crash_obj;
    private AudioSource crash;
    public GameObject music_obj;
    private AudioSource music;
    public GameObject door_hit_obj;
    private AudioSource door_hit;
    public GameObject alarm_obj;
    private AudioSource alarm;
    public GameObject birds_obj;
    private AudioSource birds;
    public GameObject heavenly_music_obj;
    private AudioSource heavenly_music;
    public GameObject headlights1;
    public GameObject headlights2;
    public GameObject headlights3;
    public GameObject smoke;
    public GameObject sparks1_obj;
    private ParticleSystem sparks1;
    public GameObject sparks2_obj;
    private ParticleSystem sparks2;
    public GameObject sparks3_obj;
    private ParticleSystem sparks3;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        engine_rev = engine_rev_obj.GetComponent<AudioSource>();
        crash = crash_obj.GetComponent<AudioSource>();
        music = music_obj.GetComponent<AudioSource>();
        door_hit = door_hit_obj.GetComponent<AudioSource>();
        alarm = alarm_obj.GetComponent<AudioSource>();
        birds = birds_obj.GetComponent<AudioSource>();
        heavenly_music = heavenly_music_obj.GetComponent<AudioSource>();
        sparks1 = sparks1_obj.GetComponent<ParticleSystem> ();
        sparks2 = sparks2_obj.GetComponent<ParticleSystem> ();
        sparks3 = sparks3_obj.GetComponent<ParticleSystem> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.name == "Player")
        {
            rb = other.GetComponent<Rigidbody>();
            velocity = rb.velocity.magnitude;

            if(velocity >= 10) {
                count++;
                door_hit.Play();
                sparks1.Play();
                sparks2.Play();
                sparks3.Play();

                switch(count)
                {
                    case 1:
                        door1.SetActive(false);
                        door2.SetActive(true);
                        engine_rev.Stop();
                        headlights1.SetActive(false);
                        headlights2.SetActive(true);
                        smoke.SetActive(true);
                        break;
                    case 2:
                        door2.SetActive(false);
                        door3.SetActive(true);
                        engine_rev.Stop();
                        headlights2.SetActive(false);
                        headlights3.SetActive(true);
                        alarm.Play();
                        break;
                    case 3:
                        music.Stop();
                        crash.Play();
                        birds.Play();
                        heavenly_music.Play();
                        rb.AddForce(new Vector3(0,0,resistance * -1), ForceMode.Impulse);
                        door3.SetActive(false);
                        door4.SetActive(true);
                        Vector3 explosionPos = transform.position - new Vector3(0,0,10);
                        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                        foreach (Collider hit in colliders)
                        {
                            Debug.Log(hit.gameObject.name);
                            Rigidbody rb = hit.GetComponent<Rigidbody>();

                            if (rb != null)
                                rb.AddExplosionForce(power, explosionPos, radius, 0);
                        }
                        gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
