//-------------------------------------------------------------------------------------
//	MediatorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MediatorStructure : MonoBehaviour
{
    private void Start()
    {
        ConcreteMediator m = new ConcreteMediator();

        ConcreteColleague1 c1 = new ConcreteColleague1(m);
        ConcreteColleague2 c2 = new ConcreteColleague2(m);
        ConcreteColleague c3 = new ConcreteColleague(m);
        ConcreteColleague c4 = new ConcreteColleague(m);
        ConcreteColleague c5 = new ConcreteColleague(m);
        ConcreteColleague c6 = new ConcreteColleague(m);
        ConcreteColleague c7 = new ConcreteColleague(m);

        //m.Colleague1 = c1;
        //m.Colleague2 = c2;
        m.AddColleague(c1);
        m.AddColleague(c2);
        m.AddColleague(c3);
        m.AddColleague(c4);
        m.AddColleague(c5);
        m.AddColleague(c6);
        m.AddColleague(c7);

        c1.Send("How are you?");
        c2.Send("Fine, thanks");
    }
}

/// <summary>
/// The 'Mediator' abstract class
/// </summary>
internal abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

/// <summary>
/// The 'ConcreteMediator' class
/// </summary>
internal class ConcreteMediator : Mediator
{
    //private ConcreteColleague1 _colleague1;
    //private ConcreteColleague2 _colleague2;
    private List<Colleague> colleagues = new List<Colleague>();

    public void AddColleague(Colleague colleague)
    {
        colleagues.Add(colleague);
    }

    //public ConcreteColleague1 Colleague1
    //{
    //    set { _colleague1 = value; }
    //}

    //public ConcreteColleague2 Colleague2
    //{
    //    set { _colleague2 = value; }
    //}

    public override void Send(string message, Colleague colleague)
    {
        //if (colleague == _colleague1)
        //{
        //    _colleague2.Notify(message);
        //}
        //else
        //{
        //    _colleague1.Notify(message);
        //}
        foreach (var item in colleagues)
        {
            if (item != colleague)
            {
                item.Notify(message);
            }
        }
    }
}

/// <summary>
/// The 'Colleague' abstract class
/// </summary>
internal abstract class Colleague
{
    protected Mediator mediator;

    // Constructor
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Notify(string mes)
    {
    }
}

internal class ConcreteColleague : Colleague
{
    // Constructor
    public ConcreteColleague(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public override void Notify(string message)
    {
        Debug.Log("Colleague gets message: " + message);
    }
}

/// <summary>
/// A 'ConcreteColleague' class
/// </summary>
internal class ConcreteColleague1 : Colleague
{
    // Constructor
    public ConcreteColleague1(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public override void Notify(string message)
    {
        Debug.Log("Colleague1 gets message: " + message);
    }
}

/// <summary>
/// A 'ConcreteColleague' class
/// </summary>
internal class ConcreteColleague2 : Colleague
{
    // Constructor
    public ConcreteColleague2(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public override void Notify(string message)
    {
        Debug.Log("Colleague2 gets message: " + message);
    }
}