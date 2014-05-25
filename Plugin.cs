using System;

namespace Kevin.Core
{
	public delegate void Handle(string message, Output output);

	public class Plugin
	{
		public virtual Result getResult (string message)
		{
			throw new NotImplementedException ();
		}

		public virtual Result getResult(string mess, KevinCore core)
		{
			return getResult (mess);
		}
	}
}

