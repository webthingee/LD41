using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Character : MonoBehaviour, IDamageable 
{
    #region     Properties
    [Header("Character Stats")]
    [SerializeField] string charName;
    [SerializeField] float charStrength;
    [SerializeField] float charHealth;
    [SerializeField] float charMaxHealth;

    [Header("Damage")]
    //public GameObject damageEffect;
    public AudioEvent damageSound;

    [Header("Death")]
    public GameObject deathEffect;
    public AudioEvent deathSound;

    SpriteRenderer sr;
    bool isQuitting;

    public float CharHealth
    {
        get
        {
            return charHealth;
        }

        set
        {
            charHealth = value;
        }
    }

    public float CharMaxHealth
    {
        get
        {
            return charMaxHealth;
        }

        set
        {
            charMaxHealth = value;
        }
    }
    #endregion

    protected virtual void Start () 
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        charHealth = charMaxHealth;
	}

    public void TakeDamage(float _amount)
    {
        CharHealth -= _amount;
        StartCoroutine(Flash(0.05f, 3));
        DamageResults(this.gameObject.tag);

        if (CharHealth <= 0)
        {
            DeathResults(this.gameObject.tag);
            Destroy(this.gameObject);
        }
    }

     IEnumerator Flash(float _wait, int _flashes) 
     {
        Color origColor = sr.color;
        for (int i = 0; i < _flashes; i++) 
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(_wait);
            sr.color = origColor;
            yield return new WaitForSeconds(_wait);
        }
        sr.color = origColor;
    }

    void DamageResults (string _tag)
    {   
        damageSound.Play(SoundManager.Instance.GetOpenAudioSource()); 
    }   
    
    void DeathResults (string _tag)
    {
        // GameObject deathParticle = Instantiate(deathEffect, transform.position, Quaternion.identity, null);
        damageSound.Play(SoundManager.Instance.GetOpenAudioSource()); 
        deathSound.Play(SoundManager.Instance.GetOpenAudioSource()); 

        // if (_tag == "Player")
        // {
        //     GameMaster.Instance.GameOverManager();
        // }

        // if (_tag == "Enemy")
        // {
        //     ManagePrefs.Instance.AddKillCount(1);
        // }

        // GameMaster.Instance.ShakeCamera();
    }
}
