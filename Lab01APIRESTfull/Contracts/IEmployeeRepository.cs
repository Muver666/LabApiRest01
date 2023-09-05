using Entities.Models;

namespace Contracts;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees(bool trackChanges);
    Employee GetEmployeesById(Guid Id, bool trackChanges);
    IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
    void CreateEmployeeForCompany(Guid companyId, Employee employee);
    void DeleteEmployee(Employee employee);
}
