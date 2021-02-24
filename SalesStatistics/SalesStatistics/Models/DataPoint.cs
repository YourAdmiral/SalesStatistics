﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SalesStatistics.Models
{
	[DataContract]
	public class DataPoint
    {
		[DataMember(Name = "x")]
		public Nullable<double> X = null;

		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

		public DataPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
