#pragma strict

class Display7Seg extends MonoBehaviour
{
	var onColor : Color = Color.red;
	var offColor : Color = Color.black;

	var aFlag: boolean = false;
	var bFlag: boolean = false;
	var cFlag: boolean = false;
	var dFlag: boolean = false;
	var eFlag: boolean = false;
	var fFlag: boolean = false;
	var gFlag: boolean = false;
	var pFlag: boolean = false;	

	private var a : GameObject = null;
	private var b : GameObject = null;
	private var c : GameObject = null;
	private var d : GameObject = null;
	private var e : GameObject = null;
	private var f : GameObject = null;
	private var g : GameObject = null;
	private var p : GameObject = null;

	function Start()
	{
		a = transform.FindChild("a").gameObject;
		b = transform.FindChild("b").gameObject;
		c = transform.FindChild("c").gameObject;
		d = transform.FindChild("d").gameObject;
		e = transform.FindChild("e").gameObject;
		f = transform.FindChild("f").gameObject;
		g = transform.FindChild("g").gameObject;
		p = transform.FindChild("p").gameObject;		
	}

	function UpdateDisplay ()
	{
		if(aFlag) a.GetComponent.<Renderer>().material.color = onColor;
		else a.GetComponent.<Renderer>().material.color = offColor;
		
		if(bFlag) b.GetComponent.<Renderer>().material.color = onColor;
		else b.GetComponent.<Renderer>().material.color = offColor;
		
		if(cFlag) c.GetComponent.<Renderer>().material.color = onColor;
		else c.GetComponent.<Renderer>().material.color = offColor;
		
		if(dFlag) d.GetComponent.<Renderer>().material.color = onColor;
		else d.GetComponent.<Renderer>().material.color = offColor;
		
		if(eFlag) e.GetComponent.<Renderer>().material.color = onColor;
		else e.GetComponent.<Renderer>().material.color = offColor;
		
		if(fFlag) f.GetComponent.<Renderer>().material.color = onColor;
		else f.GetComponent.<Renderer>().material.color = offColor;
		
		if(gFlag) g.GetComponent.<Renderer>().material.color = onColor;
		else g.GetComponent.<Renderer>().material.color = offColor;
		
		if(pFlag) p.GetComponent.<Renderer>().material.color = onColor;
		else p.GetComponent.<Renderer>().material.color = offColor;
	}
	
	function setChar(ch:char, pointState:boolean)
	{
		//39
	
		switch(ch)
		{
			case ' ':
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = false;
				eFlag = false;
				fFlag = false;
				gFlag = false;
				break;
				
			case '-':
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = false;
				eFlag = false;
				fFlag = false;
				gFlag = true;
				break;
				
			case 'a':
			case 'A':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'b':
			case 'B':
				aFlag = false;
				bFlag = false;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'c':
			case 'C':
				aFlag = true;
				bFlag = false;
				cFlag = false;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = false;
				break;
				
			case 'd':
			case 'D':
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = false;
				gFlag = true;
				break;
				
			case 'e':
			case 'E':
				aFlag = true;
				bFlag = false;
				cFlag = false;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'f':
			case 'F':
				aFlag = true;
				bFlag = false;
				cFlag = false;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'g':
			case 'G':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'h':
			case 'H':
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'i':
			case 'I':
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = false;
				break;
				
			case 'j':
			case 'J':			
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = false;
				gFlag = false;
				break;
				
			case 'k':
			case 'K':
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'l':
			case 'L':
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = false;
				break;
				
			case 'm':
			case 'M':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = false;
				break;
				
			case 'n':
			case 'N':
				aFlag = false;
				bFlag = false;
				cFlag = true;
				dFlag = false;
				eFlag = true;
				fFlag = false;
				gFlag = true;
				break;
				
			case 'o':
			case 'O':		
				aFlag = false;
				bFlag = false;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = false;
				gFlag = true;
				break;
				
			case 'p':
			case 'P':		
				aFlag = true;
				bFlag = true;
				cFlag = false;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'q':
			case 'Q':		
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'r':
			case 'R':		
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = false;
				eFlag = true;
				fFlag = false;
				gFlag = true;
				break;
				
			case 's':
			case 'S':
				aFlag = true;
				bFlag = false;
				cFlag = true;
				dFlag = true;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			case 't':
			case 'T':
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'u':
			case 'U':			
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = false;
				break;
				
			case 'v':
			case 'V':		
				aFlag = false;
				bFlag = false;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = false;
				gFlag = false;
				break;
			
			case 'w':
			case 'W':		
				aFlag = false;
				bFlag = true;
				cFlag = false;
				dFlag = true;
				eFlag = false;
				fFlag = true;
				gFlag = false;
				break;
				
			case 'x':
			case 'X':
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'y':
			case 'Y':
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			case 'z':
			case 'Z':		
				aFlag = true;
				bFlag = true;
				cFlag = false;
				dFlag = true;
				eFlag = true;
				fFlag = false;
				gFlag = true;
				break;
			
			case '0':			
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = false;
				break;
				
			case '1':			
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = false;
				fFlag = false;
				gFlag = false;
				break;
		
			case '2':		
				aFlag = true;
				bFlag = true;
				cFlag = false;
				dFlag = true;
				eFlag = true;
				fFlag = false;
				gFlag = true;
				break;
				
			case '3':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = false;
				fFlag = false;
				gFlag = true;
				break;
				
			case '4':
				aFlag = false;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			case '5':
				aFlag = true;
				bFlag = false;
				cFlag = true;
				dFlag = true;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			case '6':
				aFlag = true;
				bFlag = false;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
				
			case '7':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = false;
				eFlag = false;
				fFlag = false;
				gFlag = false;
				break;
				
			case '8':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = true;
				fFlag = true;
				gFlag = true;
				break;
			
			case '9':
				aFlag = true;
				bFlag = true;
				cFlag = true;
				dFlag = true;
				eFlag = false;
				fFlag = true;
				gFlag = true;
				break;
				
			default:
				aFlag = false;
				bFlag = false;
				cFlag = false;
				dFlag = false;
				eFlag = false;
				fFlag = false;
				gFlag = false;
		}

		pFlag = pointState;

		UpdateDisplay ();
	}

}
