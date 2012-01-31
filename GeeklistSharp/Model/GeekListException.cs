using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeeklistSharp.Model
{
	public class GeekListException : Exception
	{
		public string Status { get; private set; }

        public Error Error { get; set; }

		public GeekListException(string status, Error error)
			: base(string.Format("API call resulted in status: {0}", status))
		{
			this.Status = status;
            this.Error = error;
		}

       
	}
}
