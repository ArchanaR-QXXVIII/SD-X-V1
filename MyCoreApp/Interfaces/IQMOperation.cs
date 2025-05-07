using System;

public interface IQMOperation
{
	public IEnumerable<QMPerson> GetQMOperations();
	public IEnumerable<QMPerson> AddQMOperation(IEnumerable<QMPerson> person);
}
