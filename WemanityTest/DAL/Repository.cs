using System;
using System.Collections.Generic;
using System.Text;
using WemanityTest.Model;

namespace WemanityTest.DAL
{
    internal class Repository
    {

        public Dictionary<string, string> Directory { get; set; }

        public Repository()
        {
            // we feed data here 
            // Dictionary : to avoid duplicate keys
            // Key: employee's name , Value: employee's position
            Directory = new Dictionary<string, string>
            {
                { "Jonathan",Employee.Position.Dev.ToString() },
                { "Stéphanie", Employee.Position.Dev.ToString() },

                { "Hans",Employee.Position.Agile.ToString() },
                { "Nabil",Employee.Position.Agile.ToString() },
                { "Danny", Employee.Position.Agile.ToString() },
                { "Monique", Employee.Position.Agile.ToString() },
                { "Marc", Employee.Position.Agile.ToString() },              

                { "Valentin", Employee.Position.Facilitator.ToString() },
                { "Yacine", Employee.Position.Facilitator.ToString() },
                { "Michaël", Employee.Position.Facilitator.ToString() }
            };
        }



    }
}
