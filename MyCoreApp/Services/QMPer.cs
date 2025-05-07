using System;

public class QMPer
{
	public string _Name { get; set; }
	public int _Age { get; set; }

	public QMPer(String name, int age)
	{
		_Name = name;
		_Age = age;
	}


	public override string ToString()
	{
		return $"Name: {_Name}, Age: {_Age}";
	}
}
