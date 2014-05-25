using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kevin.Core
{
	public class KnockKnock : Plugin
	{
		public override Result getResult(string mess, KevinCore core) {
			if (Regex.IsMatch (mess, @"joke\b")) {
				return new Result ((string message, Output output) => {
					output.send("ok");
					output.send("Knock Knock");
					core.State = "joke:knockknock";
				});
			}

			if (Regex.IsMatch (mess, @"whos there\b") && core.State == "joke:knockknock") {
				return new Result ((string message, Output output) => {
					output.send("Orange");
					core.State = "joke:orange";
				}, 2);
			}

			if (Regex.IsMatch (mess, @"orange who\b") && core.State == "joke:orange") {
				return new Result ((string message, Output output) => {
					output.send("Orange you going to let me in?");
					core.State = "joke:done";
				}, 2);
			}

			if (Regex.IsMatch (mess, @"ha") && core.State == "joke:done") {
				return new Result ((string message, Output output) => {
					output.send("glade you found my joke funny");
					core.State = "";
				}, 2);
			}



			return null;
		}
	}
}

