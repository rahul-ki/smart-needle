using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;


public class GameManager : MonoBehaviour {

	public GameObject panel1;
	public GameObject panel2;
	public GameObject panel12;

	public InputField parent1id;
	public InputField parent2id;
	public InputField childid;
	public InputField dob;
	public Text test;
	public Text submittxt;
	public GameObject Img;
	public GameObject loadingImg;
	public Canvas canva;
	public GameObject plane;
	public GameObject panel22;

	public Text fatherid;
	public Text motherid;
	public Text kidid;

	string p1id;
	string p2id;
	string cid;
	string cdob;
	string filePath;
	// Use this for initialization
	///StreamReader sr = new StreamReader("http://localhost/angelhack/GetUserData.php");
	void Start () {
	//	filePath = "http://localhost/angelhack/GetUserData.php";
		plane.gameObject.SetActive (false);
	}
	
	// = System.IO.Path.Combine(Application.absoluteURL,   Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			canva.gameObject.SetActive (true);
			plane.gameObject.SetActive (false);

		}
		if (Input.GetKeyDown (KeyCode.C)) {
			plane.gameObject.SetActive (true);
		
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			plane.gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			panel2.gameObject.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.O)) {
			panel12.gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			panel1.gameObject.SetActive (true);
		}


	}

	public void Submitbtn(){
		//WWW w = new WWW ("http://localhost/datasick/login.php");
		WWWForm form1= new WWWForm();
		form1.AddField ("Parent1id", parent1id.text.ToString());

		WWW urlData = new WWW("http://localhost/angelhack/PostUserData.php", form1);
		StartCoroutine(GetUserData(urlData));

		p1id = parent1id.text.ToString();

		p2id = parent2id.text.ToString ();
		cid = childid.text.ToString ();
		cdob = dob.text.ToString ();
		//submittxt.text = ("Submited!");

		WWWForm form2 = new WWWForm();
		form2.AddField ("Querys", "SELECT * FROM `table_childrecords` WHERE 1");

		StartCoroutine(GetText(form2));

		StartCoroutine (loadingscreen ());
	}

	IEnumerator GetText(WWWForm form) {
		
		WWW w = new WWW("http://localhost/angelhack/GetUserData.php",form);
		yield return w;
		if (w.error != null)
		{
			Debug.Log("Error .. " +w.error);
			// for example, often 'Error .. 404 Not Found'
		}
		else
		{
			Debug.Log(w.text);
			test.text = w.text;
		}
//		
	}


	IEnumerator GetUserData (WWW w2) {
		yield return w2;
		if (w2.error == null) {

			Debug.Log("goood");
		}
		else {
			//message += w2.text;
			Debug.Log("baaad");
		}
	}

	IEnumerator loadingscreen(){
		loadingImg.gameObject.SetActive (true);
		panel1.gameObject.SetActive (false);
		yield return new WaitForSeconds(3);
		loadingImg.gameObject.SetActive (false);
		Continuebtn ();
	}

	IEnumerator loadingscreen2(){
		loadingImg.gameObject.SetActive (true);
		panel12.gameObject.SetActive (false);
		yield return new WaitForSeconds(3);
		loadingImg.gameObject.SetActive (false);
		Continue3btn ();
	}
	public void Continuebtn(){
		panel1.gameObject.SetActive (false);
		fatherid.text = p1id.ToString();
		Debug.Log (p1id);
		motherid.text = p2id;
		Debug.Log (p2id);
		kidid.text = cid;
		panel12.gameObject.SetActive (true);


	}

	public void Continue3btn(){
		panel12.gameObject.SetActive (false);
		panel2.gameObject.SetActive (true);


	}

	public void showCertificate(){
		plane.gameObject.SetActive (false);
		Img.gameObject.SetActive (true);
		panel22.gameObject.SetActive (false);
	}

	public void hideCertificate(){
		plane.gameObject.SetActive (false);
		Img.gameObject.SetActive (false);
		panel22.gameObject.SetActive (true);

	}

	public void takepic(){
		plane.gameObject.SetActive (true);
		canva.gameObject.SetActive (false);


	}
	public void confirmbtn(){
		StartCoroutine (loadingscreen2 ());


	}

}
