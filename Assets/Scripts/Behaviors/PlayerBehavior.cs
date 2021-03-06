﻿using JetBrains.Annotations;
using UnityEngine;


public class PlayerBehavior : CreaturesBehavior
{

	

	//Obiekt odpowiedzialny za ruch gracza.
	public CharacterController characterControler;
	public WeaponBehavior weapon;
	//Wysokość skoku.
	public float wysokoscSkoku = 7.0f;
	//Aktualna wysokosc skoku.
	public float aktualnaWysokoscSkoku = 0f;
	//Predkosc biegania.
	public float predkoscBiegania = 7.0f;
	public int money = 0;
	//Czulość myszki (Sensitivity)
	public float czuloscMyszki = 3.0f;
	public float myszGoraDol = 0.0f;
	//Zakres patrzenia w górę i dół.
	public float zakresMyszyGoraDol = 90.0f;
	private float coolDown = 0f;
	private float maxSpeed;
	

	// Use this for initialization
	void Start()
	{
		Init();
		characterControler = GetComponent<CharacterController>();
		weapon = GetComponentInChildren<WeaponBehavior>();
		maxSpeed = speed;
		money = 0;
		// Debug.Log(characterControler);
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.timeScale != 0)
		{
			klawiatura();
			myszka();
			if (Input.GetButtonDown("Fire1") && curramo > 0)
			{
				weapon.Shoot();
				curramo--;
			}
			if (Input.GetAxis("Mouse ScrollWheel") != 0 && Time.time > coolDown)
			{
				weapon.AttackTypeSwitch();
				coolDown = Time.time + 2f;
			}
			if (Time.time > slowTime)
			{
				speed = maxSpeed;
			}
		}
	}

	/**
	 * Metoda odpowiedzialna za poruszanie się na klawiaturze.
	 */
	private void klawiatura()
	{
		//Pobranie prędkości poruszania się przód/tył.
		// jeżeli wartość dodatnia to poruszamy się do przodu,
		// jeżeli wartość ujemna to poruszamy się do tyłu.
		float rochPrzodTyl = Input.GetAxis("Vertical") * speed;
		//Pobranie prędkości poruszania się lewo/prawo.
		// jeżeli wartość dodatnia to poruszamy się w prawo,
		// jeżeli wartość ujemna to poruszamy się w lewo.
		float rochLewoPrawo = Input.GetAxis("Horizontal") * speed;
		//Debug.Log (rochLewoPrawo);

		//Skakanie
		// Jeżeli znajdujemy się na ziemi i została naciśnięta spacja (skok)
		if (characterControler.isGrounded && Input.GetButton("Jump"))
		{
			aktualnaWysokoscSkoku = wysokoscSkoku;
		}
		else if (!characterControler.isGrounded)
		{//Jezeli jestesmy w powietrzu(skok)
		 //Fizyka odpowiadająca za grawitacje (os Y).
			aktualnaWysokoscSkoku += Physics.gravity.y * Time.deltaTime;
		}

		// Debug.Log(Physics.gravity.y);

		//Bieganie
		if (Input.GetKeyDown("left shift"))
		{
			maxSpeed += predkoscBiegania;
		}
		else if (Input.GetKeyUp("left shift"))
		{
			maxSpeed -= predkoscBiegania;
		}

		//Tworzymy wektor odpowiedzialny za ruch.
		//rochLewoPrawo - odpowiada za ruch lewo/prawo,
		//aktualnaWysokoscSkoku - odpowiada za ruch góra/dół,
		//rochPrzodTyl - odpowiada za ruch przód/tył.
		Vector3 ruch = new Vector3(rochLewoPrawo, aktualnaWysokoscSkoku, rochPrzodTyl);
		//Aktualny obrót gracza razy kierunek w którym sie poruszamy (poprawka na obrót myszką abyśmy szli w kierunku w którym patrzymy).
		ruch = transform.rotation * ruch;

		characterControler.Move(ruch * Time.deltaTime);
	}

	/**
	 * Metoda odpowiedzialna za ruch myszką.
	 */
	private void myszka()
	{
		//Pobranie wartości ruchu myszki lewo/prawo.
		// jeżeli wartość dodatnia to poruszamy w prawo,
		// jeżeli wartość ujemna to poruszamy w lewo.
		float myszLewoPrawo = Input.GetAxis("Mouse X") * czuloscMyszki;
		transform.Rotate(0, myszLewoPrawo, 0);

		//Pobranie wartości ruchu myszki góra/dół.
		// jeżeli wartość dodatnia to poruszamy w górę,
		// jeżeli wartość ujemna to poruszamy w dół.
		myszGoraDol -= Input.GetAxis("Mouse Y") * czuloscMyszki;

		//Funkcja nie pozwala aby wartość przekroczyła dane zakresy.
		myszGoraDol = Mathf.Clamp(myszGoraDol, -zakresMyszyGoraDol, zakresMyszyGoraDol);
		//Ponieważ CharacterController nie obraca się góra/dół obracamy tylko kamerę.
		Camera.main.transform.localRotation = Quaternion.Euler(myszGoraDol, 0, 0);
		/*weapon.Updown(myszGoraDol);*/
	}
}