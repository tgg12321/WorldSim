using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChangeText : MonoBehaviour {


	public void changeText(string s){
		GetComponent<Text> ().text = s;
	}
}
