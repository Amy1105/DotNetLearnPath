
class ManagerMediator : Mediator
{
    public Customer Customer { get; set; }
    public Programmer Programmer { get; set; }
    public Tester Tester { get; set; }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == Customer)
        {
            Programmer.Notify(message);
        }
        else if (colleague == Programmer)
        {
            Tester.Notify(message);
        }
        else Customer.Notify(message);
    }
}
