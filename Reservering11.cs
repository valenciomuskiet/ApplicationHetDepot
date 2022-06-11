using System;
namespace HetDepotApplication
{
	public class Reservering
	{
		public int Code { get; set; }
		public string Tijd { get; set; }


		public Reservering()
		{
					
		}


        public override string ToString()
        {
            return String.Format("Student Information:\n\tCode: {0}, Tijd: {1} ", Code, Tijd);
        }


    }
}
