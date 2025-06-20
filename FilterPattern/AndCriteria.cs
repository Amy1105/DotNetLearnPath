
// 组合过滤器：AND操作
public class AndCriteria : ICriteria
{
    private ICriteria _criteria;
    private ICriteria _otherCriteria;

    public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
    {
        _criteria = criteria;
        _otherCriteria = otherCriteria;
    }

    public List<Person> MeetCriteria(List<Person> persons)
    {
        var firstCriteriaPersons = _criteria.MeetCriteria(persons);
        return _otherCriteria.MeetCriteria(firstCriteriaPersons);
    }
}
