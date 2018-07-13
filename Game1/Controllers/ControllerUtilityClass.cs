using System;

public class ControllerUtilityClass
{
    private float xSensativity = 0.2f;
    private float ySensativity = 0.6f;
	public ControllerUtilityClass()
	{
	}

    public float XSensativity { get => xSensativity; set => xSensativity = value; }
    public float YSensativity { get => ySensativity; set => ySensativity = value; }
}
