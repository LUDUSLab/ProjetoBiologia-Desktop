﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cipo : MonoBehaviour {

	public GameObject indio, cipoVerde, balaoDuvida,barraTempoObject, cipoSinlhueta, feedBackVision, fadeIn;
    private indiozinho personagem;
    bool visao = false, tato = false;
    public float forcinhaPraPular;

    void Start () {
        personagem = indio.GetComponent<indiozinho>();
    }
	
	void Update () {
        stopVerCipo();
        goVerCipo();
        stopPularCipo();
        goPularCipo();

	}

    void stopVerCipo()
    {
        if(indio.transform.position.x >= 20 && indio.transform.position.x <= 20.9)
        {
            if(visao == false)
            {	
				cipoSinlhueta.SetActive(true);
                barraTempoObject.SetActive(true);
				feedBackVision.SetActive(true);
				personagem.goOrStay = false;
				balaoDuvida.SetActive (true);
				indio.GetComponent<Animator>().SetBool("parar", true);
				visao = true;

            }
        }
    }

    void goVerCipo()
    {
		if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
                feedBackVision.SetActive(false);
                cipoSinlhueta.SetActive(false);
                cipoVerde.SetActive(true);
                personagem.goOrStay = true;
                barraTempoObject.SetActive(false);
                indio.GetComponent<Animator>().SetBool("parar", false);
                GetComponent<Score>().Addscore();
        }
		else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (indio.transform.position.x >= 20 && indio.transform.position.x <= 20.9)
            {
				fadeIn.SetActive(true);
				Invoke("goGameOver", 1.5f);
            }
        }
    }

    void stopPularCipo()
    {
        if (indio.transform.position.x >= 23.5 && indio.transform.position.x <= 23.9)
        {
            if (tato == false)
            {
				barraTempoObject.SetActive(true);
				balaoDuvida.SetActive (true);
                personagem.goOrStay = false;
                tato = true;
				//indio.GetComponent<Animator>().SetBool("parar", true);
				indio.GetComponent<Animator>().SetBool("levantar", true);
            }
        }
    }

    void goPularCipo()
    {
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (tato == true)
            {
				
				balaoDuvida.SetActive (false);
				barraTempoObject.SetActive(false);
				indio.GetComponent<Animator>().SetBool("levantar", false);
                tato = false;
                Vector2 direcaoPulo = new Vector2(0.8f, 0.9f);
                direcaoPulo.Normalize();
                indio.GetComponent<Rigidbody2D>().AddForce(direcaoPulo * forcinhaPraPular);
                this.GetComponent<Cipo>().enabled = false;
				//personagem.goOrStay = true;
				//indio.GetComponent<Animator>().SetBool("levantar", false);
				indio.GetComponent<Animator>().SetBool("pulando", true);
				Invoke("VoltaraAndar", 0.8f);
                GetComponent<Score>().Addscore();
            }
        }
		else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) 
			|| Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (indio.transform.position.x >= 23.5 && indio.transform.position.x <= 23.9)
            {
				fadeIn.SetActive(true);
				Invoke("goGameOver", 1.5f);
            }
        }
    }
	void VoltaraAndar(){
		personagem.goOrStay = true;
		indio.GetComponent<Animator>().SetBool("parar", false);
		indio.GetComponent<Animator>().SetBool("pulando", false);
	}

	void goGameOver()
	{
		SceneManager.LoadScene("gameOver");
	}
}
