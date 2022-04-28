using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Builder design pattern separate the construction of a complex object from its representation
    /// so that the same constructional can create different representations.
    /// </summary>
    class BuilderPattern
    {
        public void CallBuilder()
        {
            PlayerBuilder pb = new PlayerBuilder();
            var player = pb.SetName("Manish").SetCharacter("X").Build();
            Console.WriteLine(player);
        }
    }

    class Player
    {
        public string Name { get; set; }
        public string Character { get; set; }

        public Player()
        {

        }

        private Player(string name, string character)
        {
            Name = name;
            Character = character;
        }

        public override string ToString()
        {
            return $"Player Name : {this.Name} and Player Character : {Character}";
        }
    }

    class PlayerBuilder
    {
        Player player = new Player();

        public PlayerBuilder SetName(string name)
        {
            this.player.Name = name;
            return this;
        }

        public PlayerBuilder SetCharacter(string character)
        {
            this.player.Character = character;
            return this;
        }

        public Player Build()
        {
            return player;
        }
    }
}
