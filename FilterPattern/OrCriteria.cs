
// 组合过滤器：OR操作
public class OrCriteria : ICriteria
{
    private ICriteria _criteria;
    private ICriteria _otherCriteria;

    public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
    {
        _criteria = criteria;
        _otherCriteria = otherCriteria;
    }

    public List<Person> MeetCriteria(List<Person> persons)
    {
        var firstCriteriaItems = _criteria.MeetCriteria(persons);
        var secondCriteriaItems = _otherCriteria.MeetCriteria(persons);

        foreach (var person in secondCriteriaItems)
        {
            if (!firstCriteriaItems.Contains(person))
            {
                firstCriteriaItems.Add(person);
            }
        }

        return firstCriteriaItems;
    }
}
