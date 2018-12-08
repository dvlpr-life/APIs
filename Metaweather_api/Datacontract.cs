using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;


namespace Metaweather
{
    [DataContract]
    class Location
    {
        [DataMember(Name = "title")] public string Title { get; set; }
        [DataMember(Name = "location_type")] public string Location_Type { get; set; }
        [DataMember(Name = "woeid")] public string WoeID { get; set; }
        [DataMember(Name = "latt_long")] public string Latt_Long { get; set; }

    }

    [DataContract]
    class LocationWeather
    {
        [DataMember(Name = "title")] public string Title { get; set; }
        [DataMember(Name = "location_type")] public string Location_Type { get; set; }
        [DataMember(Name = "woeid")] public string WoeID { get; set; }
        [DataMember(Name = "latt_long")] public string Latt_Long { get; set; }
        [DataMember(Name = "time")] public string Time { get; set; }
        [DataMember(Name = "sun_rise")] public string Sun_Rise { get; set; }
        [DataMember(Name = "sun_set")] public string Sun_Set { get; set; }
        [DataMember(Name = "timezone_name")] public string TimeZone_Name { get; set; }
        [DataMember(Name = "consolidated_weather")] public IList<Consolidated_Weather> Consolidated_Weather { get; set; }
        [DataMember(Name = "parent")] public Location Parent { get; set; }
        [DataMember(Name = "sources")] public IList<Sources> Sources { get; set; }

    }

    [DataContract]
    class Consolidated_Weather
    {
        [DataMember(Name = "id")] public string ID { get; set; }
        [DataMember(Name = "weather_state_name")] public string Weather_State_Name { get; set; }
        [DataMember(Name = "weather_state_abbr")] public string Weather_State_Abbr { get; set; }
        [DataMember(Name = "wind_direction_compass")] public string Wind_Direction_Compass { get; set; }
        [DataMember(Name = "created")] public string Created { get; set; }
        [DataMember(Name = "applicable_date")] public string Applicable_Date { get; set; }
        [DataMember(Name = "min_temp")] public float Min_Temp { get; set; }
        [DataMember(Name = "max_temp")] public float Max_Temp { get; set; }
        [DataMember(Name = "the_temp")] public float The_Temp { get; set; }
        [DataMember(Name = "wind_speed")] public float Wind_Speed { get; set; }
        [DataMember(Name = "wind_direction")] public string Wind_Direction { get; set; }
        [DataMember(Name = "air_pressure")] public string Air_Pressure { get; set; }
        [DataMember(Name = "humidity")] public string Humidity { get; set; }
        [DataMember(Name = "visibility")] public string Visibility { get; set; }
        [DataMember(Name = "predictability")] public string Predictability { get; set; }
    }

    [DataContract]
    class Sources
    {
        [DataMember(Name = "title")] public string Title { get; set; }
        [DataMember(Name = "url")] public string URL { get; set; }
    }
}
