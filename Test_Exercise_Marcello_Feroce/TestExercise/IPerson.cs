namespace TestExercise
{
    public interface IPerson
    {
        string PrintAll();
        void AssignRole(IRole role);
        string GetRole();
        string GetName();
    }
}