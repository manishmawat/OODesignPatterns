using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    class PrototypePattern
    {
        public void CallProtoTypePattern()
        {
            BlockFactory bfactory = new BlockFactory();
            List<IBlock> list = new List<IBlock>();
            list.Add(bfactory.Create("Manish"));
            list.Add(bfactory.Create("01/12/2022"));
            list.Add(bfactory.Create("21"));
            
            foreach (var item in list)
                Console.WriteLine(item.Render);

            Console.WriteLine("Starting with Prototyping");

            DateBlock dbproto1 = list[1].Clone() as DateBlock;
            dbproto1.DateTime = new DateTime(2025, 01, 01);
            list.Add(dbproto1);

            NumberBlock nbProto1 = list[2].Clone() as NumberBlock;
            nbProto1.Number = 35;
            list.Add(nbProto1);

            TextBlock tBlockProto1 = list[0].Clone() as TextBlock;
            tBlockProto1.Content = "New Content";
            list.Add(tBlockProto1);

            foreach (var item in list)
                Console.WriteLine(item.Render);


        }
    }

    public class BlockFactory
    {
        public IBlock Create(string content)
        {
            if (DateTime.TryParse(content, out var dt))
                return new DateBlock()
                {
                    DateTime = dt,
                    Format = "dd/MM/yyyy"
                };

            if (int.TryParse(content, out var num))
                return new NumberBlock()
                {
                    Number = num
                };

            return new TextBlock()
            {
                Content = content
            };
        }
    }

    public interface IBlock
    {
        string Render { get; }
        IBlock Clone();
    }

    class TextBlock : IBlock
    {
        private string _content;
        public string Content { get { return _content; } set { _content = value; } }
        public string Render => Content;

        public IBlock Clone()
        {
            return new TextBlock() { Content = Content };
        }
    }

    class DateBlock : IBlock
    {
        public DateTime DateTime { get; set; }
        public string Format { get; set; }
        public string Render => DateTime.ToString(Format);

        public IBlock Clone()
        {
            return new DateBlock() { DateTime = DateTime, Format = Format };
        }
    }

    class NumberBlock : IBlock
    {
        public int Number { get; set; }

        public string Render => Number.ToString();

        public IBlock Clone()
        {
            return new NumberBlock() { Number = Number };
        }
    }

}
