﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;

namespace Counter
{
	[Export(typeof(IToolPlugin))]
	public class KanColleCounter : IToolPlugin
	{
		private readonly CounterViewModel viewmodel = new CounterViewModel
		{
			Counters = new ObservableCollection<CounterBase>
			{
				new SupplyCounter(KanColleClient.Current.Proxy),
				new ItemDestroyCounter(KanColleClient.Current.Proxy),
				new MissionCounter(KanColleClient.Current.Proxy),
			}
		};

		public string ToolName
		{
			get { return "Counter"; }
		}

		public object GetSettingsView()
		{
			return null;
		}

		public object GetToolView()
		{
			return new CounterView { DataContext = this.viewmodel, };
		}
	}
}
