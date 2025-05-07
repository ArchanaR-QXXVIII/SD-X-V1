using System;

public class QMPerson
{
	public string _Name { get; set; }
	public int _Age { get; set; }

	public QMPerson(String name, int age)
	{
		_Name = name;
		_Age = age;
	}


	public override string ToString()
	{
		return $"Name: {_Name}, Age: {_Age}";
	}
}
