
// 具体过滤器：过滤单身
public class CriteriaSingle : ICriteria
{
    public List<Person> MeetCriteria(List<Person> persons)
    {
        return persons.Where(p => p.MaritalStatus == "Single").ToList();
    }
}
