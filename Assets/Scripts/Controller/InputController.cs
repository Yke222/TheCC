using UnityEngine;
using System;
using System.Collections;
using Plugins.SimpleInput.Scripts.AxisInputs;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class Repeater
{
	const float threshold = 0.5f;
	const float rate = 0.25f;
	float _next;
	bool _hold;
	string _axis;
	public int theValue;
	
	public Repeater (string axisName)
	{
		_axis = axisName;
	}
	
	public int Update ()
	{
		int retValue = 0;
		int value = Mathf.RoundToInt(CrossPlatformInputManager.GetAxisRaw(_axis));
		
		if (value != 0 || theValue != 0)
		{
			if (Time.time > _next)
			{
				if (theValue != 0)
				{
					retValue = theValue;
				}
				else
				{
					retValue = value;
				}

				_next = Time.time + (_hold ? rate : threshold);
				_hold = true;
			}
		}
		else
		{
			_hold = false;
			_next = 0;
		}
		
		return retValue;
	}
}

public class InputController : MonoBehaviour 
{
	public static event EventHandler<InfoEventArgs<Point>> moveEvent;
	public static event EventHandler<InfoEventArgs<int>> fireEvent;
	public int xZin;
	public int yZin;
	public int Triggervalue;
	

	public int LeftValue;
	public int UpValue;

	public Repeater _hor = new Repeater("Horizontal");
	public Repeater _ver = new Repeater("Vertical");
	
	string[] _buttons = {"Fire1", "Fire2", "Fire3"};

	void Update () 
	{
		xZin = _hor.Update();
		yZin = _ver.Update();

		
		if (xZin != 0 || yZin != 0)
		{
			if (moveEvent != null)
			{
				moveEvent(this, new InfoEventArgs<Point>(new Point(xZin, yZin)));
			}
		}

		if (LeftValue != 0)
		{
			moveEvent(this, new InfoEventArgs<Point>(new Point(LeftValue, yZin)));
		}

		for (int i = 0; i < 3; ++i)
		{
			if (Input.GetButtonUp(_buttons[i]) || Triggervalue != -1) 
			{
				if (Triggervalue != -1)
				{
					if (fireEvent != null)
                    					fireEvent(this, new InfoEventArgs<int>(Triggervalue));
					Triggervalue = -1;
				} else if (fireEvent != null)
				{
					fireEvent(this, new InfoEventArgs<int>(i));
				}
			}
		}
	}
	
	public void TriggerSubmit()
	{
		Triggervalue = 0;
	}
	
	public void TriggerCancel()
	{
		Triggervalue = 1;
	}

	public void TriggerLeft()
	{
		_ver.theValue = -1;
	}

	public void TriggerUp()
	{
		_hor.theValue = 1;
	}
	
	public void TriggerDown()
	{
		_hor.theValue = -1;
	}
	
	public void TriggerRight()
	{
		_ver.theValue = 1;
		
	}
}
