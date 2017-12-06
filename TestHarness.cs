/*
********************************************************************************
** MODULE:       TestHarness
** FILENAME:     TestHarness.cs
** AUTHOR:       Chris Gallucci
*********************************************************************************
**
** DESCRIPTION:
** Console application template for debugging and testing BusinessModule template.
** Created using Microsoft Visual C#.
**
*********************************************************************************
*/
using System;

namespace WindowsServiceSample
{
	// This is the delegate to use to execute the process asynchronously
	public delegate void ExecuteBackgroundDelegate();

	/// <summary>
	/// Summary description for TestHarness.
	/// </summary>
	class TestHarness
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// create an instance of our process engine
			BusinessModule process = new BusinessModule();

			// create an instance of our execution delegate
			ExecuteBackgroundDelegate asynchExec = new ExecuteBackgroundDelegate(process.ExecuteBackground);

			// execute this asynchronously
			asynchExec.BeginInvoke(null, null);

			Console.Write("Press any key to quit...");
			Console.Read();

			// tell process to stop
			process.StopMonitoring();
			Console.Write(Environment.NewLine + "Quiting.");

			// wait up to 100 iterations for the process to stop
			int i = 0;
			while ( i++ < 100 && !process.Stopped ) 
				Console.Write(".");

			if ( process.Stopped )
				Console.WriteLine(Environment.NewLine + "Process successfully shutdown.");
			else
				Console.WriteLine(Environment.NewLine + "Process failed to successfully shutdown.");
		}
	}
}
