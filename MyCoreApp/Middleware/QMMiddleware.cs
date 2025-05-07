using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;


namespace WebAppMiddleware.Middlewares
{
	public class CustomMiddleware
	{
		private QMOperation opeartions;
		private RequestDelegate _next;
		public void QMCustomMiddleware(RequestDelegate next)
		{
			_next = next;


		}

		private Func<RequestDelegate, RequestDelegate> Middleware1 = next =>
		{
			return async context =>
			{
				context.Items["mw-message1"] = "Name";
				await next(context);
			};
		};




		private async Task ThreadTask(int taskNum)
		{

			List<QMPerson> personRead = new List<QMPerson>();
			QMPerson[] peopleTemp = new QMPerson[4];
			if (taskNum < 4)
			{

				QMPerson[] people = new QMPerson[4];
				people[0] = new QMPerson("Ali", 30);
				people[1] = new QMPerson("Bindu", 25);
				people[2] = new QMPerson("Sidhu", 35);
				people[3] = new QMPerson("Sid", 36);

				foreach (QMPerson personItem in people)
				{
					for (int i = 0; i < people.length; i++)
					{
						peopleTemp[i] = new QMPerson(personItem?._Name, personItem._Age);
						personRead.Add(peopleTemp[i]);
					}
				}

			}
			await personRead;
		}



		static void Main()
		{

			int numberOfThreads = 4;

			// Create an array to hold the threads
			Thread[] threads = new Thread[numberOfThreads];
			for (int i = 0; i < numberOfThreads; i++)
			{
				threads[i] = new Thread(new ThreadStart(ThreadTask(i)));
				ThreadMsgTask();
				threads[i].Start();
			}
			foreach (Thread thread in threads)
			{
				thread.Join();
			}

			Console.WriteLine("All threads have completed.");
		}

		// The task that each thread will execute
		static void ThreadMsgTask()
		{
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is running.");
			// Simulate work with a sleep
			Thread.Sleep(1000);
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished.");
		}
	}
}
	

		
