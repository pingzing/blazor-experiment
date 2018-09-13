﻿using System;

namespace LatestBlazor.APIs
{
    public class TransitStop
    {
        /// <summary>
        /// A unique stop ID that contains information about the service that administrates the stop, and a unique identifier (e.g. HSL:1130432).
        /// </summary>
        public string GtfsId { get; set; }
        /// <summary>
        /// The stop's human-friendly name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The numeric identifier for a given stop.
        /// </summary>
        public string Code { get; set; }
        public BasicLatLon Coords { get; set; }
        public string NameAndCode
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Code))
                {
                    return $"{Name}, {Code}";
                }
                else
                {
                    return Name;
                }
            }
        }
    }
}