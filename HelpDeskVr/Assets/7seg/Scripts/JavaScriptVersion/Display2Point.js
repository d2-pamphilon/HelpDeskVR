#pragma strict

class Display2Point extends MonoBehaviour
{
	var on : boolean = false;
	var onColor : Color = Color.red;
	var offColor : Color = Color.black;
	
	private var p : GameObject = null;

	function Start ()
	{
		p = transform.FindChild("p2").gameObject;
	}

	function Update ()
	{
		if(on) p.GetComponent.<Renderer>().material.color = onColor;
		else p.GetComponent.<Renderer>().material.color = offColor;
	}

}
