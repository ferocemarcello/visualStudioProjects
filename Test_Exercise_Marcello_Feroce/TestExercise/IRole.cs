namespace TestExercise
{
    public interface IRole
    {
        string GetRoleType();
        string ShowAll();
        void AddPerson(IPerson person);
        void RemovePerson(IPerson person);
        int GetSalary();
    }
}