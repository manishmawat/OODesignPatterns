using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    class MediatorPattern
    {
        public void LetsChat()
        {
            ConcreteMeditor m = new ConcreteMeditor();
            ConcreteUser user = new ConcreteUser(m, "user1");
            ConcreteUser user2 = new ConcreteUser(m, "user2");
            ConcreteUser user3 = new ConcreteUser(m, "manish");
            m.AddUser(user);
            m.AddUser(user2);
            m.AddUser(user3);
            user.Send("Hello");
        }

    }


    /// <summary>
    /// Mediator - this is like a chat room who receive the request from one user and send the message to all the users
    /// </summary>
    interface Mediator
    {
        void AddUser(Collegaue user);
        void Send(string message, Collegaue sender);
    }

    /// <summary>
    /// Concrete mediator - this is the implementation of mediator
    /// </summary>
    class ConcreteMeditor : Mediator
    {
        List<Collegaue> users = new List<Collegaue>();
        public ConcreteMeditor()
        {
            //users.Add(user);
        }

        public void AddUser(Collegaue user)
        {
            users.Add(user);
        }

        public void Send(string message, Collegaue sender)
        {
            foreach(Collegaue user in users)
            {
                if (user != sender)
                    user.Notify(message,sender.username);
            }
        }
    }

    /// <summary>
    /// Colleague - this is user in the chat room (mediator)
    /// </summary>
    abstract class Collegaue
    {
        protected Mediator mediator;

        public Collegaue(Mediator m,string username)
        {
            this.mediator = m;
            this.username = username;
        }
        public string username;
        public abstract void Send(string message);
        public abstract void Notify(string message,string senderName);
    }

    /// <summary>
    /// Concrete colleague class which implements the colleague class
    /// </summary>
    class ConcreteUser : Collegaue
    {
        private Mediator _m;
        public ConcreteUser(Mediator m,string username):base(m,username)
        {
            _m = m;
        }
        public override void Notify(string message,string senderName)
        {
            Console.WriteLine($"User Notified with {message} from {senderName}");
        }

        public override void Send(string message)
        {
            _m.Send(message, this);
        }
    }


}
