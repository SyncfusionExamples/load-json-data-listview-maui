﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMAUI
{
	public class ViewModel : INotifyPropertyChanged
	{
		#region Fields

		private dynamic itemsSource;
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Properties
		public dynamic ItemsSource
		{
			get
			{
				return itemsSource;
			}

			set
			{
				itemsSource = value;
				RaisepropertyChanged("ItemsSource");
			}
		}

		private void RaisepropertyChanged(string v)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
		}
		#endregion

		#region Constructor
		public ViewModel()
		{
			var assembly = typeof(MainPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("ListViewMAUI.Data.Data.json");
			using (StreamReader sr = new StreamReader(stream))
			{
				var jsonText = sr.ReadToEnd();
				ItemsSource = JsonConvert.DeserializeObject<dynamic>(jsonText);
			}

		}
		#endregion

	}
}
