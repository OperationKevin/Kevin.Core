using System;
using System.Collections.Generic;

namespace Kevin.Core
{
	public class KevinCore
	{
		Output output;

		public KevinCore (Output output)
		{
			this.output = output;
		}

		string _state;

		public string State {
			get { return _state; }
			set { _state = value; }
		}

		public void tell(string message) {
			List<Plugin> plugins = new List<Plugin> ();
			List<Result> results = new List<Result> ();
			plugins.Add( new Test ());
			plugins.Add( new WhosThere ());
			plugins.Add (new KnockKnock ());
			foreach(Plugin plug in plugins) {
				Result result = plug.getResult (message, this);
				if (result != null) {
					results.Add (result);
				}
			}

			if (results.Count == 1) {
				results[0].execute (message, output);
				return;
			}
		
			if (results.Count == 0) {
				output.send ("sorry I dont understand that D:");
				return;
			}

			Result top = results[0];
			int topValue = results[0].Priority;

			foreach (Result res in results) {
				if (res.Priority > topValue) {
					top = res;
					topValue = res.Priority;
				}
			}

			top.execute (message, output);



		}


	}
}

