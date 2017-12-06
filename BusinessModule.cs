/*
********************************************************************************
** MODULE:       BusinessModule
** FILENAME:     BusinessModule.cs
** AUTHOR:       Chris Gallucci
** COPYRIGHT:    Copyright 2003 Chris Gallucci. All Rights Reserved.
**               http://www.dotnetconsultant.com
**               Author grants royalty-free rights to use this code within
**               compiled applications. Selling or otherwise distributing
**               this source code is not allowed without author's express
**               permission.
*********************************************************************************
**
** DESCRIPTION:
** Template for designing a business logic code module for use in a Windows Service
** application project. This facilitates the ability to debug and test this code
** without having to first install the Windows Service and then attach to the 
** process with a debugger.
** Created using Microsoft Visual C#.
**
*********************************************************************************
*/
using System;

namespace WindowsServiceSample
{
	/// <summary>
	/// Summary description for BusinessModule.
	/// </summary>
	public class BusinessModule
	{
		public BusinessModule()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private bool _Busy = false;
		private bool _Stop = false;

		public void ExecuteBackground()
		{
			while ( !_Stop )
			{
				_Busy = true;

				try
				{
					// do business logic
				}
				catch (Exception ex)
				{
					// handle error
				}
				finally
				{
					_Busy = false;
					// other process cleanup
				}
			}

			return;
		}

		public void StopMonitoring()
		{
			_Stop = true;
		}

		public bool Stopped
		{
			get
			{
				// monitoring has been safely stopped if the stop flag is set and busy flag is not
				return (_Stop && !_Busy);
			}
		}
	}
}
