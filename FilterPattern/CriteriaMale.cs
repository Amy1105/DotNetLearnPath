
// 具体过滤器：过滤男性
public class CriteriaMale : ICriteria
{
    public List<Person> MeetCriteria(List<Person> persons)
    {
        return persons.Where(p => p.Gender == "Male").ToList();
    }
}
