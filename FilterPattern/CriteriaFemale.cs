
// 具体过滤器：过滤女性
public class CriteriaFemale : ICriteria
{
    public List<Person> MeetCriteria(List<Person> persons)
    {
        return persons.Where(p => p.Gender == "Female").ToList();
    }
}
