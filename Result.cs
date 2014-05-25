using System;

namespace Kevin.Core
{
	public class Result
	{
		Handle handler;
		int _priority;

		public int Priority {
			get { 
				return _priority;
			}
		}

		public Result ()
		{
		}

		public Result (Handle handler) {
			this.handler = handler;
		}

		public Result (Handle handler, int priority) {
			this.handler = handler;
			this._priority = priority;
		}

		public void execute(String message, Output output) {
			handler (message, output);
		}


	}
}

