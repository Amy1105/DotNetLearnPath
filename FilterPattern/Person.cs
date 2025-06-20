
// 实体类：人员
public class Person
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }

    public Person(string name, string gender, string maritalStatus)
    {
        Name = name;
        Gender = gender;
        MaritalStatus = maritalStatus;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Gender: {Gender}, MaritalStatus: {MaritalStatus}";
    }
}
