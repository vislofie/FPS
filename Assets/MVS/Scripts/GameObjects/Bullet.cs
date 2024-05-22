using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _decalPrefab;
    [SerializeField]
    private AudioClip[] _impactSounds;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject decalObject = Instantiate(_decalPrefab, transform.position,Quaternion.identity, null);
        decalObject.transform.rotation = Quaternion.FromToRotation(decalObject.transform.forward, collision.contacts[0].normal);

        AudioSource decalAudio = decalObject.AddComponent<AudioSource>();
        decalAudio.spatialBlend = 1;
        decalAudio.clip = _impactSounds[Random.Range(0, _impactSounds.Length)];
        decalAudio.Play();
        
        Destroy(this.gameObject);
    }
}
