using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeaShooterGame.Utils
{
    public class Faction
    {
        private Dictionary<string, Actor> _memberList;

        public string Name { get; private set; }

        public Faction(string name)
        {
            this.Name = name;
            this._memberList = new Dictionary<string,Actor>();
        }
    }
}
