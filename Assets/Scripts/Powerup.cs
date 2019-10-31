﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType { TripleShot, SpeedBoost, Shield }

public class Powerup : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private PowerupType _type;
    [SerializeField] private float _speed = 3.0f;

    [SerializeField] private int _spawnChance = 10;
    public int spawnChance {
        get {
            return _spawnChance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // Destroy when it goes off-screen
        if (transform.position.y < -6.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                switch(_type)
                {
                    case PowerupType.TripleShot:
                        player.ActivateTripleShot();
                        break;
                    case PowerupType.SpeedBoost:
                        player.ActivateSpeedBoost();
                        break;
                    case PowerupType.Shield:
                        player.ActivateShield();
                        break;
                    default:
                        Debug.Log("Unspecified powerup type!");
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
