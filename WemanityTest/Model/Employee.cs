
using System.ComponentModel;
using System.Text;

namespace WemanityTest.Model
{
    public static class Employee
    {
        public enum Position
        {
            [Description("Agile Coach")]
            Agile =1,
            [Description("Developer")]
            Dev =2 ,
            [Description("Succes facilitator")]
            Facilitator =3               
        }

    }
}
