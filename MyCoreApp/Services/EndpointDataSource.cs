using System;
using System.Reflection;

public class ApiControllerInspector
{
	//private readonly EndpointDataSource _endpointDataSource;

	//public ApiEndpointInfo(EndpointDataSource endpointDataSource)
	//{
	//	_endpointDataSource = endpointDataSource;
	//}

	public static void ListApiEndpoints(Type controllerTy)
	{

		TypeInfo controllerTypeInfo = typeof(QMController).GetTypeInfo();
		MethodInfo[] methods = controllerTypeInfo.DeclaredMethods.ToArray();

		//var controllerType = typeof(QMController);
		//var methods = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
			//.Where(m => m.IsPublic && !m.IsDefined(typeof(NonActionAttribute)));
		foreach (var method in methods)
		{
			Console.WriteLine(method.Name);
		}

		//foreach (var method in methods)
		//{
		//	var routeAttributes = method.GetCustomAttributes<RouteAttribute>();
		//	var httpMethodAttributes = method.GetCustomAttributes<HttpMethodAttribute>();

		//	foreach (var route in routeAttributes)
		//	{
		//		foreach (var httpMethod in httpMethodAttributes)
		//		{
		//			Console.WriteLine($"{httpMethod.HttpMethods.First()} {route.Template}");
		//		}
		//	}
		//}
	}
}

public class QMController
{
	public void GetData() { }
	public void PostData() { }
}
