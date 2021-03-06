﻿/***************************************************
    Kinematics.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace Web.Iot.Models.MongoDB
{
    /// <summary>
    /// Serialized device kinematics
    /// </summary>
    public sealed class KinematicsModel
    {
        /// <summary>
        /// DateTime of when the kinematics of the device we're read
        /// </summary>
        [BsonElement("dateTime")]
        public DateTime DateTime { get; set; }


        /// <summary>
        /// The altitude of the device
        /// </summary>
        [BsonElement("altitude")]
        public double Altitude { get; set; }


        /// <summary>
        /// The latitude of the device
        /// </summary>
        [BsonIgnore]
        public double Latitude { get; set; }


        /// <summary>
        /// The longitude of the device
        /// </summary>
        [BsonIgnore]
        public double Longitude { get; set; }


        /// <summary>
        /// The GeoJson Coord of the device
        /// </summary>
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; }


        /// <summary>
        /// The azimuth of the device
        /// </summary>
        [BsonElement("azimuth")]
        public double Azimuth { get; set; }


        /// <summary>
        /// The pitch of the device
        /// </summary>
        [BsonElement("pitch")]
        public double Pitch { get; set; }


        /// <summary>
        /// The roll of the device
        /// </summary>
        [BsonElement("roll")]
        public double Roll { get; set; }


        /// <summary>
        /// The acceleration of the device on the X axis
        /// </summary>
        [BsonElement("accelerationX")]
        public double AccelerationX { get; set; }


        /// <summary>
        /// THe acceleration of the device on the Y axis
        /// </summary>
        [BsonElement("accelerationY")]
        public double AccelerationY { get; set; }


        /// <summary>
        /// The acceleration of the device on the z axis
        /// </summary>
        [BsonElement("accelerationZ")]
        public double AccelerationZ { get; set; }
    }
}
