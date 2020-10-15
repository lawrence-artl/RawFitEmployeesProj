using System;

class Employee
{
	private string fname = "John";
	private string lname = "Doe";
	private string name = "John Doe";
	private int empid = 100000;
	private double payrate = 5.00;
	private double hoursworked = 0.00;	

	public string Name
	{
		get {return name;}
		set {name = value;}
	}

	public string Fname
	{
		get { return fname; }
		set { fname = value; }
	}

	public string Lname
    {
		get { return lname; }
		set { lname = value; }
    }
	
	public int Empid
	{
		get { return empid; }
		set { empid = value; }
	}

	public double Payrate
    {
		get { return payrate; }
		set { payrate = value; }
		
	}

	public double Hoursworked
    {
		get { return hoursworked; }
        set { hoursworked = value; }
    }
	
	
}
