using System;
using System.Collections.Generic;
using System.Text;

namespace ObstacleApp
{
    class ObsRec
    {
		private string study;
		private string otype;
		private string status;
		private double latitude;
		private double longitude;
		private string latitude_hemisphere;
		private string longitude_hemisphere;
		private int agl_height;
		private int msl_height;
		private double latitude_DD;
		private double  longitude_DD;

		public double  Longitude_DD
		{
			get { return longitude_DD; }
			set { longitude_DD = value; }
		}
		public double LatitudeDD
		{
			get { return latitude_DD; }
			set { latitude_DD = value; }
		}
		public int MSL_Height
		{
			get { return msl_height; }
			set { msl_height = value; }
		}
		public int Agl_Height
		{
			get { return agl_height; }
			set { agl_height = value; }
		}
		public string Longitude_hemisphere
		{
			get { return longitude_hemisphere; }
			set { longitude_hemisphere = value; }
		}
		public string Latitude_Hemisphere
		{
			get { return latitude_hemisphere; }
			set { latitude_hemisphere = value; }
		}
		public double Longitude_DMS
		{
			get { return longitude; }
			set { longitude = value; }
		}
		public double Latitude_DMS
		{
			get { return latitude; }
			set { latitude = value; }
		}
		public string Status
		{
			get { return status; }
			set { status = value; }
		}
		public string Otype
		{
			get { return otype; }
			set { otype = value; }
		}
		public string Study
		{
			get { return study; }
			set { study = value; }
		}
	}
}
