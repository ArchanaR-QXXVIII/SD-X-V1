using System;


public class QMOperation : IQMOperation
{
	private readonly List<QMPerson> _person = new List<QMPerson>();

	public QMOperation(List<QMPerson> person)
	{
		_person = person;	

	}
	
	public IEnumerable<QMPerson> AddQMOperation(IEnumerable<QMPerson> person)
	{
		QMPerson[] people = new QMPerson[4];
		List<QMPerson> personImg = new List<QMPerson>();
		try
		{
			
			foreach (QMPerson personItem in person)
			{
				for (int i = 0; i <= people.Length - 1; i++)
				{
					people[i] = new QMPerson(personItem?._Name, personItem._Age);
					personImg.Add(people[i]);
				}

			}

			return personImg;
		}
		catch(Exception ex) 
		{
			return _person;
			throw ex.InnerException;
			Console.WriteLine("Inner Exception caused in Add");
			
		}

		
		
	}
	public IEnumerable<QMPerson> GetQMOperations()
	{
		// array of Person objects
		QMPerson[] people = new QMPerson[4];
		List<QMPerson> personRead = new List<QMPerson>();
		try
		{
			people[0] = new QMPerson("Ali", 30);
			people[1] = new QMPerson("Bindu", 25);
			people[2] = new QMPerson("Sidhu", 35);
			people[3] = new QMPerson("Sid", 36);


			foreach (QMPerson personItem in people)
			{
				for (int i = 0; i <= people.Length - 1; i++)
				{
					people[i] = new QMPerson(personItem?._Name, personItem._Age);
					personRead.Add(people[i]);
				}

			}

			return personRead;
		}
		catch
		{
			return _person;
		}
		

		
	}
}
