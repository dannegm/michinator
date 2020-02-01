using UnityEngine;

public class Console : MonoBehaviour {

	public void iLog (string log) {
		Debug.Log (log);
	}

	public static void Log (string log) {
		Debug.Log (log);
	}
}
