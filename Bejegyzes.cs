using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
	internal class Bejegyzes
	{
		private string szerzo;
		private string tartalom;
		private int likeok;
		private DateTime letrejott;
		private DateTime szerkesztve;

		public Bejegyzes(string szerzo, string tartalom)
		{
			this.szerzo = szerzo;
			this.tartalom = tartalom;
			this.likeok = 0;
			this.letrejott = DateTime.Now;
			this.szerkesztve = DateTime.Now;
		}

		public string Szerzo { get => szerzo; }
		public string Tartalom
		{
			get {
				return this.tartalom;
			}
			set
			{
				this.tartalom = value;
				this.szerkesztve = DateTime.Now;
			}
		}
		public int Likeok { get => likeok; }
		public DateTime Letrejott { get => letrejott; }
		public DateTime Szerkesztve { get => szerkesztve; }

		public override string ToString()
		{
			return $"{szerzo}   -   {likeok} Like    -   {letrejott}\nSzerkesztve: {szerkesztve}\n{tartalom}";
		}

		public void Like()
		{
			likeok++;
		}
    }
}
